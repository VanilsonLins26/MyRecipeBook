using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastucture.Context;
using MyRecipeBook.Infrastucture.DataAccess;
using MyRecipeBook.Infrastucture.DataAccess.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Infrastucture;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    { 

        AddRepositories(services);
        AddDbContext(services, configuration);

    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(DbContextOptions =>
        {
            var connectionString = configuration.GetConnectionString("MySql");
            DbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        } );

    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();  
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}
