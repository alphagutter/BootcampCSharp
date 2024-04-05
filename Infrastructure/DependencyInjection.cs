using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddServices();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Bootcamp");

        services.AddDbContext<BootcampContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }
    
    /// <summary>
    /// Adds all the repositories for the tables, then are called for the services
    /// </summary>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();


        return services;
    }

    /// <summary>
    /// Adds all the services for the tables
    /// </summary>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<ICustomerService, CustomerService>();


        return services;
    }
}
