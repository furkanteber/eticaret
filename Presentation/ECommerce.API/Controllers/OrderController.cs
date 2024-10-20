using ECommerce.API.Controllers.Base;
using ECommerce.Application.Dtos;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

public class OrderController(IOrderService service) : AbstractBaseController
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get([FromRoute] Guid userId)
        => ControllerResponse(await service.GetByUserAsync(userId));

    [HttpPost]
    public async Task<IActionResult> Create(OrderDto order)
        => ControllerResponse(await service.CreateAsync(order));
    
    [HttpPut]
    public async Task<IActionResult> Update(OrderDto order)
        => ControllerResponse(await service.UpdateAsync(order));
    
    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(Guid userId)
        => ControllerResponse(await service.DeleteAsync(userId));
}