using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using tienda.Domain.Entities;

namespace tienda.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products"); // Nombre que tendrá la tabla
        
        builder.HasKey(p => p.Id); // Clave primaria
        builder.Property(p => p.Id).ValueGeneratedNever(); // Los GUID los asignamos desde C#

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200); // El nombre es obligatorio y de máximo 200 caracteres

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.Stock)
            .IsRequired()
            .HasDefaultValue(0); // Si no se define stock, inicia en 0
    }
}