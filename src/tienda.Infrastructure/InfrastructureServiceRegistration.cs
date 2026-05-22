using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tienda.Application.Contracts.Persistence;
using tienda.Infrastructure.Repositories;

namespace tienda.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Dejamos solo el repositorio, ya que el DbContext lo maneja el Program.cs directo de la API
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}