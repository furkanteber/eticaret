using ECommerce.Application.Dtos;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IBasketItemService : IApplicationCrudService<BasketItem, BasketItemDto>
{
    Task<ServiceResponse<NoContent>> AddAsync(BasketItemDto basketItemDto);
    Task<ServiceResponse<NoContent>> UpdateQuantityAsync(Guid id, int quantity);
}