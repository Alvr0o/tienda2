using MediatR;
using tienda.Application.Features.Productos.Dtos;

namespace tienda.Application.Features.Productos.Queries.GetProductos;

public record ObtenerProductosQuery() : IRequest<IEnumerable<ProductoDto>>;
