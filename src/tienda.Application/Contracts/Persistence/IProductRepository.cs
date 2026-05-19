// Contracts/Persistence/IProductRepository.cs 
using tienda.Domain.Entities;
namespace tienda.Application.Contracts.Persistence;

public interface IProductRepository 
{ 
	Task<Product?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default);
	Task<IEnumerable<Product>> ObtenerTodosAsync(CancellationToken ct = 
default); 
	Task<bool> ExistePorNombreAsync(string nombre, CancellationToken ct = 
default); 
	Task AgregarAsync(Product producto, CancellationToken ct = default); 
	Task ActualizarAsync(Product producto, CancellationToken ct = default); 
} 