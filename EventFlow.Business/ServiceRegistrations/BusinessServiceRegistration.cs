using EventFlow.Business.Services.Abstractions;
using EventFlow.Business.Services.Implementations;
using EventFlow.Business.Validators.EventValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EventFlow.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<EventCreateDtoValidator>();

        services.AddScoped<IJWTService, JWTService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddAutoMapper(_ => { }, typeof(BusinessServiceRegistration).Assembly);

        JWTOptionsDto options = configuration.GetSection("JWTOptions").Get<JWTOptionsDto>() ?? new();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(config =>
        {
            config.TokenValidationParameters = new()
            {
                RoleClaimType = "Role",
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = options.Issuer,
                ValidAudience = options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey))
            };
        });
    }
}
