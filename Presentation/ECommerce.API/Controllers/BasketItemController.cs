using ECommerce.API.Controllers.Base;
using ECommerce.Application.Dtos;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers;

public class BasketItemController(IBasketItemService service) : AbstractBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(Guid basketId)
        => ControllerResponse(await service.GetWithIncludes(basketId));
    
    [HttpPost]
    public async Task<IActionResult> Add(BasketItemDto basketItem)
        => ControllerResponse(await service.AddAsync(basketItem));
    
    [HttpPut]
    public async Task<IActionResult> Update(BasketItemDto basketItem)
        => ControllerResponse(await service.UpdateAsync(basketItem));
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]Guid basketItemId)
        => ControllerResponse(await service.DeleteAsync(basketItemId));
}