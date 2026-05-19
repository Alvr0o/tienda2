// Exceptions/ProductNotFoundException.cs 
namespace tienda.Domain.Exceptions; 
 
public class ProductNotFoundException : DomainException 
{ 
    public ProductNotFoundException(Guid id) 
        : base($"Producto con Id '{id}' no encontrado.") { } 
}