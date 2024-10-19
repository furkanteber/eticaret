using ECommerce.API.Controllers.Base;
using ECommerce.Application.Dtos;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers;

public class CategoryController(ICategoryService service) : AbstractBaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => ControllerResponse(await service.GetListAsync(null,null,i => i.Include(x => x.Products).ThenInclude(x => x.Image)));
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute]Guid id)
        => ControllerResponse(await service.GetFirstOrDefaultAsync(x => x.Id == id, null,i => i.Include(x => x.Products).ThenInclude(x => x.Image)));

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto category)
        => ControllerResponse(await service.CreateAsync(category));
    
    [HttpPut]
    public async Task<IActionResult> Update(CategoryDto category)
        => ControllerResponse(await service.UpdateAsync(category));
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]Guid id)
        => ControllerResponse(await service.DeleteAsync(id));


}