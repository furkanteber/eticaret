using ECommerce.API.Controllers.Base;
using ECommerce.Application.Dtos;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

public class ProductController(IProductService service) : AbstractBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(int page, int size)
        => ControllerResponse(await service.GetAsync(page, size));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute]Guid id)
        => ControllerResponse(await service.GetByIdAsync(id));

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUser([FromRoute] Guid userId)
        => ControllerResponse(await service.GetByUserIdAsync(userId));

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto product)
        => ControllerResponse(await service.CreateAsync(product));

    [HttpPut]
    public async Task<IActionResult> Update(ProductDto product)
        => ControllerResponse(await service.UpdateAsync(product));
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]Guid id)
        => ControllerResponse(await service.DeleteAsync(id));

}