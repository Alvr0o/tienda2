using tienda.Domain.Entities;

namespace tienda.Application.Contracts.Persistence;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid userId);
    Task SaveChangesAsync();
}
