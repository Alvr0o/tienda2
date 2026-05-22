namespace tienda.WebApi.Controllers.Requests;

public record CrearProductoRequest(
    string Nombre,
    string Descripcion,
    decimal Precio,
    int Stock);
