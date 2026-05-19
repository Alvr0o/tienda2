// Features/Productos/Commands/CrearProducto/CrearProductoCommand.cs
using MediatR;

namespace tienda.Application.Features.Productos.Commands.CrearProducto;

public record CrearProductoCommand(
    string Nombre,
    string Descripcion,
    decimal Precio,
    int Stock) : IRequest<Guid>; // Retornamos el ID del nuevo producto