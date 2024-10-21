using ECommerce.Application.Repository;
using ECommerce.Application.Response;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace ECommerce.Persistence.Services;

public class ImageService(IWebHostEnvironment webHostEnvironment, IRepository<Image> repository, IUnitOfWork unitOfWork) : IImageService
{
    public ServiceResponse<List<string>> GetFiles(string path)
    {
        DirectoryInfo directory = new(path);
        return ServiceResponse<List<string>>.Success(directory.GetFiles().Select(f => f.Name).ToList(), StatusCodes.Status200OK);
    }


    public async Task<ServiceResponse<NoContent>> DeleteAsync(Guid id, string fileName, string path)
    { 
        File.Delete($"{path}\\{fileName}");
        await DeleteImageAsync(id);
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
    public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path,
        IFormFileCollection files)
    {
        var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        List<(string fileName, string path)> data = new();
        List<bool> results = new();
        foreach (var file in files)
        {
            var fileNewName = await FileRenameAsync(uploadPath, file.Name);
            var result = await CopyFileAsync(Path.Combine(uploadPath, fileNewName), file);
            results.Add(result);
            data.Add((fileNewName, $"{path}\\{fileNewName}"));
        }
        if (!results.TrueForAll(r => r.Equals(true)))
            throw new Exception();
        return data;

    }
    private async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024,
                useAsync: false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
    }
    
    private async Task DeleteImageAsync(Guid imageId)
    {
        repository.Delete(await repository.GetFirstOrDefaultAsync(x => x.Id == imageId));
        await unitOfWork.CommitAsync();
    }
    private async Task<string> FileRenameAsync(string path, string fileName, int num = 0)
    {
        var newFileName = await Task.Run<string>(async () =>
        {
            string newFileName;
            var extension = Path.GetExtension(fileName);
            if (num == 0)
                newFileName = NameOperation.CharacterRegulatory(Path.GetFileNameWithoutExtension(fileName)) + extension;
            else
                newFileName = fileName;
            if (File.Exists($"{path}\\{newFileName}"))
                return await FileRenameAsync(path, $"{Path.GetFileNameWithoutExtension(newFileName)}-{num}{extension}",
                    ++num);
            return newFileName;
        });
        return newFileName;
    }
}