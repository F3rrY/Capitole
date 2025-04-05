using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentingAPI.Domain.Entities;

namespace RentingAPI.Infrastructure.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        
        builder.HasKey(cliente => cliente.Id);
        
        builder.Property(cliente => cliente.Id).ValueGeneratedNever();
        
        builder.Property(cliente => cliente.DNI).HasMaxLength(10).IsRequired().HasColumnName("DNI");
        
        builder.Property(cliente => cliente.Nombre).HasMaxLength(50).IsRequired();
        
        builder.Property(cliente => cliente.Apellido).HasMaxLength(100).IsRequired(false);
    }
}