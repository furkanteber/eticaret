using ECommerce.Application.Response;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services;

public interface IImageService
{
    ServiceResponse<List<string>> GetFiles(string path);

    Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files);
    Task<ServiceResponse<NoContent>> DeleteAsync(Guid id, string fileName, string path);
}