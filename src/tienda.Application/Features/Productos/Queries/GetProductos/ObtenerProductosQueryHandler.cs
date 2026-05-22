using MediatR;
using tienda.Application.Contracts.Persistence;
using tienda.Application.Features.Productos.Dtos;

namespace tienda.Application.Features.Productos.Queries.GetProductos;

public class ObtenerProductosQueryHandler : IRequestHandler<ObtenerProductosQuery, IEnumerable<ProductoDto>>
{
    private readonly IProductRepository _repository;

    public ObtenerProductosQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductoDto>> Handle(ObtenerProductosQuery request, CancellationToken cancellationToken)
    {
        var productos = await _repository.ObtenerTodosAsync(cancellationToken);

        // El handler mapea las entidades de dominio a DTOs antes de devolverlas
        return productos.Select(p => new ProductoDto
        {
            Id = p.Id,
            Nombre = p.Name,
            Descripcion = p.Description,
            Precio = p.Price,
            Stock = p.Stock,
            EstaActivo = p.IsActive
        });
    }
}
