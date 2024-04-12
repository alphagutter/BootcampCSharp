using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddServices();
        services.AddMapping();
        services.AddValidation();

        return services;
    }

    /// <summary>
    /// Adds the database to the connection, necessary to use migration lines first
    /// </summary>
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
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();

        //added recently
        services.AddScoped<IAccountRepository, AccountRepository>();

        return services;
    }

    /// <summary>
    /// Adds all the services for the tables
    /// </summary>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICreditCardServices, CreditCardService>();
        services.AddScoped<IAccountService, AccountService>();
        
        //token service with Jwt
        services.AddScoped<IJwtProvider, JwtProvider>();



        return services;
    }

    /// <summary>
    /// It adds the mapping of the objects, to create them without many code
    /// </summary
    public static IServiceCollection AddMapping (this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
    /// <summary>
    /// It adds the validations that need to check out for creation of classes
    /// </summary
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {

        //check the obsolete service with the teacher
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

}


