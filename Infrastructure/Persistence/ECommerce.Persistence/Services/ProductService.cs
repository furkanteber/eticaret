using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repository;
using ECommerce.Application.Response;
using ECommerce.Application.Services;
using ECommerce.Common.Services.Concrete;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Services;

public class ProductService(IRepository<Product> repository,IImageService imageService,IRepository<Image> imageRepository,IMapper mapper, IUnitOfWork unitOfWork):
    ApplicationCrudService<Product, ProductDto>(repository, mapper, unitOfWork), IProductService
{
    public async Task<ServiceResponse<List<ProductDto>>> GetAsync(int page, int size)
    {
        var products = await repository.GetPagedListAsync(page, size, null, null,
            i => i.Include(i => i.Categories).Include(x => x.Image));
        var dto = mapper.Map<List<ProductDto>>(products);
        return ServiceResponse<List<ProductDto>>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<ProductDto>> GetByIdAsync(Guid id)
    {
        var products = await repository.GetFirstOrDefaultAsync(x => x.Id == id, null,
            i => i.Include(i => i.Categories).Include(x => x.Image));
        var dto = mapper.Map<ProductDto>(products);
        return ServiceResponse<ProductDto>.Success(dto, StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<List<ProductDto>>> GetByUserIdAsync(Guid userId)
    {
        var products = await repository.GetListAsync(x => x.UserId == userId.ToString(), null, i => i.Include(i => i.Categories).Include(x => x.Image));
        var dto = mapper.Map<List<ProductDto>>(products);
        return ServiceResponse<List<ProductDto>>.Success(dto, StatusCodes.Status200OK);
    }
    
    public async Task<ServiceResponse<NoContent>> SaveImageAsync(Guid id, IFormFileCollection files)
    {
        var productImages = await imageService.UploadAsync("photo-images",files);
        var product = await repository.GetFirstOrDefaultAsync(x => x.Id == id);
        
        if(product == null)
            return ServiceResponse<NoContent>.Failure("Product not found", StatusCodes.Status404NotFound);
        
        var images = productImages.Select(d => new Image { FileName = d.fileName, Path = d.pathOrContainerName, }).ToList();
        
        foreach (var image in images)
            await imageRepository.CreateAsync(image);
        
        await unitOfWork.CommitAsync();

        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
} 












































