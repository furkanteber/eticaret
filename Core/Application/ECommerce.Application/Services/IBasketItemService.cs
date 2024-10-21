using ECommerce.Application.Dtos;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IBasketItemService : IApplicationCrudService<BasketItem, BasketItemDto>
{
    Task<ServiceResponse<List<BasketItemDto>>> GetWithIncludes(Guid basketId);
    Task<ServiceResponse<NoContent>> AddAsync(BasketItemDto model);
}