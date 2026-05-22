using MediatR;
using tienda.Application.Contracts.Persistence;
using tienda.Domain.Entities;

namespace tienda.Application.Features.Productos.Queries.GetProductos;

public class ObtenerProductosQueryHandler : IRequestHandler<ObtenerProductosQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _repository;

    // Inyectamos el repositorio que creamos antes
    public ObtenerProductosQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> Handle(ObtenerProductosQuery request, CancellationToken cancellationToken)
    {
        // Usamos el método de la interfaz para traer la lista completa
        var productos = await _repository.ObtenerTodosAsync(cancellationToken);
        
        return productos;
    }
}