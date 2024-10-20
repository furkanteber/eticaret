using ECommerce.Application.Dtos;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IProductService : IApplicationCrudService<Product, ProductDto>
{
    Task<ServiceResponse<List<ProductDto>>> GetAsync(int page, int size);
    Task<ServiceResponse<ProductDto>> GetByIdAsync(Guid id);
    Task<ServiceResponse<List<ProductDto>>> GetByUserIdAsync(Guid userId);

}