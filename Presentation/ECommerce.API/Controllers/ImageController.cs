using ECommerce.API.Controllers.Base;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

public class ImageController(IImageService service) : AbstractBaseController
{
    [HttpGet]
    public IActionResult Get(string path)
        => ControllerResponse(service.GetFiles(path));

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id,string path, string fileName)
        => ControllerResponse(await service.DeleteAsync(id, fileName, path));
}