using System.Linq.Expressions;
using AutoMapper;
using ECommerce.Application.Dtos;
using ECommerce.Application.Repository;
using ECommerce.Application.Response;
using ECommerce.Application.Services.Base;
using ECommerce.Domain.Entities.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Common.Services.Concrete;

public class ApplicationCrudService<T, TDto>(IRepository<T> repository, IMapper mapper, IUnitOfWork unitOfWork) 
    : IApplicationCrudService<T, TDto> where T : BaseEntity where TDto : BaseDto
{
    public async Task<ServiceResponse<List<TDto>>> GetListAsync(Expression<Func<T?, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true)
    {
        var list = await repository.GetListAsync(predicate, orderBy, includeProperties, disableTracking);
        var dto = mapper.Map<List<TDto>>(list);
        return ServiceResponse<List<TDto>>.Success(dto, StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<TDto>> GetFirstOrDefaultAsync(Expression<Func<T?, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
        bool disableTracking = true)
    {
        var entity = await repository.GetFirstOrDefaultAsync(predicate, orderBy, includeProperties, disableTracking);
        var dto = mapper.Map<TDto>(entity);
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<List<TDto>>> GetPagedListAsync(int page, int size, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IQueryable<T>>? includeProperties = null, bool disableTracking = true)
    {
        var list = await repository.GetPagedListAsync(page, size, predicate, orderBy, includeProperties, disableTracking);
        var dto = mapper.Map<List<TDto>>(list);
        return ServiceResponse<List<TDto>>.Success(dto, StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<TDto>> CreateAsync(TDto dto)
    {
        await repository.CreateAsync(mapper.Map<T>(dto));
        await unitOfWork.CommitAsync();
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status201Created);
    }

    public async Task<ServiceResponse<TDto>> UpdateAsync(TDto dto)
    {
        var entity = await repository.GetFirstOrDefaultAsync(x => x.Id == dto.Id);
        repository.Update(entity);
        await unitOfWork.CommitAsync();
        return ServiceResponse<TDto>.Success(dto, StatusCodes.Status200OK);
    }

    public async Task<ServiceResponse<NoContent>> DeleteAsync(Guid id)
    {
        var entity = await repository.GetFirstOrDefaultAsync(x => x.Id == id);
        repository.Delete(entity);
        await unitOfWork.CommitAsync();
        return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
    }
    
    private IQueryable<T> GetCommon(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IQueryable<T>> include = null, bool disableTracking = true)
    {
        IQueryable<T?> query = repository.GetQueryable();
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if (include != null)
        {
            query = include(query);
        }
        if (orderBy != null)
        {
            query = orderBy(query!);
        }

        return query;
    }
}