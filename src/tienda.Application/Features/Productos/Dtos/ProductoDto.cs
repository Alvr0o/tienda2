namespace tienda.Application.Features.Productos.Dtos;

public class ProductoDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool EstaActivo { get; set; }
}
