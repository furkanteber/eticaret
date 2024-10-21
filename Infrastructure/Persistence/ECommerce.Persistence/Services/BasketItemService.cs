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

public class BasketItemService(IRepository<BasketItem> repository, IMapper mapper, IUnitOfWork unitOfWork) : 
    ApplicationCrudService<BasketItem, BasketItemDto>(repository, mapper, unitOfWork), IBasketItemService
{

    public async Task<ServiceResponse<List<BasketItemDto>>> GetWithIncludes(Guid basketId)
    {
        var basketItems = await repository.GetListAsync(x => x.BasketId == basketId, null, i => i.Include(x => x.Product));
        var dto = mapper.Map<List<BasketItemDto>>(basketItems);
        return ServiceResponse<List<BasketItemDto>>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> AddAsync(BasketItemDto model)
    {
        var basketItem = await repository.GetFirstOrDefaultAsync(x => x.Id == model.Id);
        if (basketItem != null)
        {
            basketItem.Quantity += 1;
            repository.Update(basketItem);
        }
        else
        {
            var entity = mapper.Map<BasketItemDto, BasketItem>(model);
            await repository.CreateAsync(entity);
        }
        await unitOfWork.CommitAsync();
        
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }
}