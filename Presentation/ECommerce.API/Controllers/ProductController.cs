using ECommerce.API.Controllers.Base;
using ECommerce.Application.Dtos;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers;

public class ProductController(IProductService service) : AbstractBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(int page, int size)
        => ControllerResponse(await service.GetPagedListAsync(page, size, null, null, i => i.Include(i => i.Categories).Include(x => x.Image)));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute]Guid id)
        => ControllerResponse(await service.GetFirstOrDefaultAsync(x => x.Id == id, null, x => x.Include(p => p.Categories).Include(x => x.Image)));

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