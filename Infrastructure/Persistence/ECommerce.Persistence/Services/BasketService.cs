using AutoMapper;
using ECommerce.Application.Dtos.Basket;
using ECommerce.Application.Repository;
using ECommerce.Application.Response;
using ECommerce.Application.Services;
using ECommerce.Common.Services.Concrete;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Services;

public class BasketService(IRepository<Basket> repository, IMapper mapper, IUnitOfWork unitOfWork) : ApplicationCrudService<Basket, BasketDto>(repository, mapper, unitOfWork), IBasketService
{
    public async Task<ServiceResponse<BasketDto>> GetAsync(Guid userId)
    {
        var basket = await repository.GetFirstOrDefaultAsync(
            x => x.Id == userId
            , null,
            i => i
                .Include(x => x.User)
                .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product));
        
        var dto = mapper.Map<BasketDto>(basket);
        return ServiceResponse<BasketDto>.Success(dto, StatusCodes.Status200OK);
    }
    public async Task<ServiceResponse<NoContent>> CreateAsync(Guid userId)
    {
        Basket basket = new(){UserId = userId.ToString(), Id = Guid.NewGuid()};
        await repository.CreateAsync(basket);
        await unitOfWork.CommitAsync();
        
        return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
    }
    
}