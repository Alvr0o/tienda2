using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using tienda.Application.Common.Behaviors;

namespace tienda.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => {
            // Registra todos los Handlers de MediatR en este proyecto
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            
            // CONECTA EL GUARDIA DE SEGURIDAD (Pipeline Behavior)
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        
        // REGISTRA AUTOMÁTICAMENTE TU CrearProductoCommandValidator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}