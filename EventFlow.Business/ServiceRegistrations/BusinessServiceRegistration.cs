using CaegoryFlow.Business.Services.Abstractions;
using EventFlow.Business.Services.Abstractions;
using EventFlow.Business.Services.Implementations;
using EventFlow.Business.Validators.EventValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventFlow.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<EventCreateDtoValidator>();

        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();

        services.AddAutoMapper(_ => { }, typeof(BusinessServiceRegistration).Assembly);
    } 
}
