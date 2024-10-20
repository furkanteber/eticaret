using ECommerce.Application.Dtos;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface IOrderService : IApplicationCrudService<Order, OrderDto>
{
    Task<ServiceResponse<List<OrderDto>>> GetByUserAsync(Guid userId);
    
    
    
}