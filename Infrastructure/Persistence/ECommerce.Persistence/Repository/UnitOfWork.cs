using ECommerce.Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repository;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Commit()
    {
        context.SaveChanges();
    }
}