using ECommerce.Application.Dtos;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IBasketItemService : IApplicationCrudService<BasketItem, BasketItemDto>
{
    
}