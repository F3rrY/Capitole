using Microsoft.EntityFrameworkCore;
using RentingAPI.Domain.Entities;
using RentingAPI.Infrastructure.Configurations;

namespace RentingAPI.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Constructor vacío para instanciar y hacer las migraciones
    /// </summary>
    public ApplicationDbContext() { }
    
    /// <summary>
    /// Constructor donde definimos las opciones del DbContext
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    /// <summary>
    /// DbSet de Vehiculos
    /// </summary>
    public DbSet<Vehiculo> Vehiculos { get; set; }
    
    /// <summary>
    /// DbSet de Alquileres
    /// </summary>
    public DbSet<Alquiler> Alquileres { get; set; }
    
    /// <summary>
    /// DbSet de Clientes
    /// </summary>
    public DbSet<Cliente> Clientes { get; set; }

    /// <summary>
    /// Al crear el modelo, se crearán las bases de datos con las propiedades de las configurations
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AlquilerConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new VehiculoConfiguration());
    }
}
