using EventFlow.DataAccess.Contexts;
using EventFlow.DataAccess.Repositories.Abstractions;
using EventFlow.DataAccess.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventFlow.DataAccess.ServiceRegistraions;

public static class DataAccessServiceRegistraion
{
    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IEventRepository, EventRepository>();
    }
}
