using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RentingAPI.Domain.Entities;

namespace RentingAPI.Infrastructure.Configurations;

public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("Vehiculos");
        
        builder.HasKey(vehiculo => vehiculo.Id);
        
        builder.Property(vehiculo => vehiculo.Id).ValueGeneratedNever();
        
        builder.Property(vehiculo => vehiculo.Marca).HasMaxLength(50).IsRequired();
        
        builder.Property(vehiculo => vehiculo.Modelo).HasMaxLength(100).IsRequired();
        
        builder.Property(vehiculo => vehiculo.Estado).HasConversion<string>().IsRequired();
        
        builder.Property(vehiculo => vehiculo.AñoFabricacion).IsRequired();
        
        builder.Property(vehiculo => vehiculo.Matricula).IsRequired();
    }
}
