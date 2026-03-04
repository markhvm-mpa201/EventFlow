using EventFlow.Business.Services.Abstractions;
using EventFlow.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EventFlow.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();

        services.AddAutoMapper(_ => { }, typeof(BusinessServiceRegistration).Assembly);
    } 
}
