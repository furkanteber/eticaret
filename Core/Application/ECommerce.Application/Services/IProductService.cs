using ECommerce.Application.Dtos;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IProductService : IApplicationCrudService<Product, ProductDto>
{
}