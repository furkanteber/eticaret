using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repository;
using ECommerce.Application.Response;
using ECommerce.Application.Services;
using ECommerce.Common.Services.Concrete;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Services;

public class OrderService(IRepository<Order> repository, UserManager<User> userRepository,IMapper mapper, IUnitOfWork unitOfWork) : ApplicationCrudService<Order, OrderDto>(repository, mapper, unitOfWork), IOrderService
{
    public async Task<ServiceResponse<List<OrderDto>>> GetByUserAsync(Guid userId)
    {
        var userExist = await userRepository.Users.AnyAsync(x => x.Id == userId.ToString());
        
        if(!userExist)
            return ServiceResponse<List<OrderDto>>.Failure("User does not exist",StatusCodes.Status404NotFound);

        var orders = repository.GetListAsync(x => x.Basket.UserId == userId.ToString(), null,
            i => i.Include(x => x.Basket).ThenInclude(x => x.User));
        var dto = mapper.Map<List<OrderDto>>(orders);
        
        return ServiceResponse<List<OrderDto>>.Success(dto, StatusCodes.Status200OK);
    }
}