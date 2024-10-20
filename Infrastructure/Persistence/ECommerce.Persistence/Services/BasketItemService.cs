using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repository;
using ECommerce.Application.Response;
using ECommerce.Application.Services;
using ECommerce.Common.Services.Concrete;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Persistence.Services;

public class BasketItemService(IRepository<BasketItem> repository, IMapper mapper, IUnitOfWork unitOfWork) : 
    ApplicationCrudService<BasketItem, BasketItemDto>(repository, mapper, unitOfWork), IBasketItemService
{
    public async Task<ServiceResponse<NoContent>> AddAsync(BasketItemDto basketItemDto)
    {
        var basketItem = await repository.GetFirstOrDefaultAsync(b => b.ProductId == basketItemDto.ProductId);
        if (basketItem != null)
        {
            basketItem.Quantity += 1;
            repository.Update(basketItem);
        }
        else
            await repository.CreateAsync(mapper.Map<BasketItemDto, BasketItem>(basketItemDto));
        
        await unitOfWork.CommitAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<NoContent>> UpdateQuantityAsync(Guid id, int quantity)
    {
        var basketItem = await repository.GetFirstOrDefaultAsync(b => b.Id == id);
        
        if(basketItem == null)
            return ServiceResponse<NoContent>.Failure("Basket Item not found", StatusCodes.Status404NotFound);
        
        basketItem.Quantity = quantity;
        repository.Update(basketItem);
        await unitOfWork.CommitAsync();
        
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
    
}