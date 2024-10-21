using ECommerce.Application.Dtos.Basket;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IBasketService : IApplicationCrudService<Basket, BasketDto>
{
    Task<ServiceResponse<BasketDto>> GetAsync(Guid userId);
    Task<ServiceResponse<NoContent>> CreateAsync(Guid userId);
}