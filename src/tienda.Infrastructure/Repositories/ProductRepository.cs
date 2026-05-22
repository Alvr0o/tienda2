using Microsoft.EntityFrameworkCore;
using tienda.Application.Contracts.Persistence;
using tienda.Domain.Entities;
using tienda.Infrastructure.Persistence;

namespace tienda.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    // Inyectamos el DbContext que maneja la base de datos
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AgregarAsync(Product product, CancellationToken ct = default)
    {
        await _context.Products.AddAsync(product, ct);
        await _context.SaveChangesAsync(ct); // Guarda los cambios de verdad en el archivo SQLite
    }

    public async Task<bool> ExistePorNombreAsync(string name, CancellationToken ct = default)
    {
        // Buscamos si ya existe algún producto con ese Name (en inglés)
        return await _context.Products.AnyAsync(p => p.Name == name, ct);
    }

    public async Task<IEnumerable<Product>> ObtenerTodosAsync(CancellationToken ct = default)
    {
        // Trae la lista completa de productos desde la base de datos
        return await _context.Products.ToListAsync(ct);
    }

    public async Task<Product?> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Products.FindAsync(new object[] { id }, ct);
    }

    public async Task ActualizarAsync(Product product, CancellationToken ct = default)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);
    }
}