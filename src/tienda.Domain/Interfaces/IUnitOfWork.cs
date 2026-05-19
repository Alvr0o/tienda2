// Interfaces/IUnitOfWork.cs 
namespace tienda.Domain.Interfaces; 
 
public interface IUnitOfWork 
{ 
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 
}