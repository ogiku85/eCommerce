using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure service to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //TO DO: Add Services to the IOC container
        // Infrastructure service usually include low level data access, caching and other low level
        //components
        
       // services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<DapperDbContext>();
        return services;
    }
}