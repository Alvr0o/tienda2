using MediatR;
using tienda.Domain.Entities;

namespace tienda.Application.Features.Productos.Queries.GetProductos;

// Le indicamos a MediatR que esta consulta devuelve una lista de Product
public record ObtenerProductosQuery() : IRequest<IEnumerable<Product>>;