using EventFlow.Core.Entities;
using EventFlow.DataAccess.Abstractions;
using EventFlow.DataAccess.ContextInitializer;
using EventFlow.DataAccess.Contexts;
using EventFlow.DataAccess.Interceptors;
using EventFlow.DataAccess.Repositories.Abstractions;
using EventFlow.DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventFlow.DataAccess.ServiceRegistraions;

public static class DataAccessServiceRegistraion
{
    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContextInitializer, DbContextInitializer>();

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequiredLength = 5;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;

            options.User.RequireUniqueEmail = true;

        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<BaseAuditableInterceptor>();
    }
}
