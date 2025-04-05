using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentingAPI.Domain.Entities;

namespace RentingAPI.Infrastructure.Configurations;

public class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
{
    /// <summary>
    /// Configuración de la tabla de Alquileres
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Alquiler> builder)
    {
        builder.ToTable("Alquileres");
        
        builder.HasKey(alquiler => alquiler.Id);
        
        builder.Property(alquiler => alquiler.Id).ValueGeneratedNever();

        builder.Property(alquiler => alquiler.IdCliente).IsRequired();
        
        builder.Property(alquiler => alquiler.IdVehiculo).IsRequired();
        
        builder.Property(alquiler => alquiler.FechaAlquiler).IsRequired();
        
        builder.Property(alquiler => alquiler.FechaDevolucion).IsRequired(false);
    }
}