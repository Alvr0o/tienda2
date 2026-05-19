// Interfaces/IProductRepository.cs 
using tienda.Domain.Entities; 
 
namespace tienda.Domain.Interfaces; 
 
public interface IProductRepository : IRepository<Product> 
{ 
    Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default); 
    Task<IReadOnlyList<Product>> GetActiveProductsAsync(CancellationToken cancellationToken = 
default); 
    Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default); 
}