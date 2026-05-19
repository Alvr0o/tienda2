using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace tienda.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registra todos los Handlers que se encuentren en este proyecto (Application)
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}