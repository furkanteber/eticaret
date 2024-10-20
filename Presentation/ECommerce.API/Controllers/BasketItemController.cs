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
        => ControllerResponse(await service.GetListAsync(x => x.BasketId == basketId,null, i => i.Include(x => x.Product)));
    
    [HttpPost]
    public async Task<IActionResult> Create(BasketItemDto basketItem)
        => ControllerResponse(await service.CreateAsync(basketItem));
    
    [HttpPut]
    public async Task<IActionResult> Update(BasketItemDto basketItem)
        => ControllerResponse(await service.UpdateAsync(basketItem));
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]Guid basketItemId)
        => ControllerResponse(await service.DeleteAsync(basketItemId));
}