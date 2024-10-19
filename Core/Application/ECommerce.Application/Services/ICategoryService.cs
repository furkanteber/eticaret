using ECommerce.Application.Dtos;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services;

public interface ICategoryService : IApplicationCrudService<Category, CategoryDto>
{
}