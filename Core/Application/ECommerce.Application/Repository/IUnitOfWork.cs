namespace ECommerce.Application.Repository;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Commit();
}