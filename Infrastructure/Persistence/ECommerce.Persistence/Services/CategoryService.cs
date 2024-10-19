using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repository;
using ECommerce.Application.Services;
using ECommerce.Common.Services.Concrete;
using ECommerce.Domain.Entities;

namespace ECommerce.Persistence.Services;

public class CategoryService(IRepository<Category> repository, IMapper mapper, IUnitOfWork unitOfWork) :
    ApplicationCrudService<Category, CategoryDto>(repository, mapper, unitOfWork), ICategoryService
{
}