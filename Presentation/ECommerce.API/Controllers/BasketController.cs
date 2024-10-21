using ECommerce.API.Controllers.Base;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

public class BasketController(IBasketService service) : AbstractBaseController
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get([FromRoute] Guid userId)
        => ControllerResponse(await service.GetAsync(userId));
}