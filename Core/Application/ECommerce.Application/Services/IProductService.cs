using ECommerce.Application.Dtos;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Services;

public interface IProductService : IApplicationCrudService<Product, ProductDto>
{
    Task<ServiceResponse<List<ProductDto>>> GetAsync(int page, int size);
    Task<ServiceResponse<ProductDto>> GetByIdAsync(Guid id);
    Task<ServiceResponse<List<ProductDto>>> GetByUserIdAsync(Guid userId);
    Task<ServiceResponse<NoContent>> SaveImageAsync(Guid id, IFormFileCollection files);

}