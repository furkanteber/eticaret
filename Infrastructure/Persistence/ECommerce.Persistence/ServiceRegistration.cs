using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services;
    }
}