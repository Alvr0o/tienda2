// Features/Productos/Commands/CrearProducto/CrearProductoHandler.cs
using MediatR;
using tienda.Application.Contracts.Persistence; // <-- CAMBIADO: Ahora apunta a Application
using tienda.Domain.Entities;

namespace tienda.Application.Features.Productos.Commands.CrearProducto;

public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CrearProductoHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
    {
        // 1. Delegar validación y creación al Dominio (Regla de negocio pura)
        var producto = Product.Create(
            request.Nombre, 
            request.Descripcion, 
            request.Precio, 
            request.Stock);

        // 2. Persistir a través de la interfaz (DIP)
        await _repository.AgregarAsync(producto, cancellationToken);

        // 3. Retornar el ID (Nunca la entidad completa)
        return producto.Id;
    }
}