using Microsoft.EntityFrameworkCore;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.Data;

namespace RentingAPI.Infrastructure.Repositories;

public class AlquilerRepository : IAlquilerRepository
{
    /// <summary>
    /// Contexto de la aplicación
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    public AlquilerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Alquiler?> ObtenerAlquilerActivoPorClienteAsync(Guid idCliente)
    {
        return await _context.Alquileres
            .FirstOrDefaultAsync(a => a.IdCliente.Equals(idCliente) && a.FechaDevolucion == null);
    }
    
    public async Task<Alquiler?> ObtenerAlquilerActivoPorIdVehiculoAsync(Guid idVehiculo)
    {
        return await _context.Alquileres
            .FirstOrDefaultAsync(a => a.IdVehiculo.Equals(idVehiculo) && a.FechaDevolucion == null);
    }

    public async Task AgregarAsync(Alquiler alquiler)
    {
        await _context.Alquileres.AddAsync(alquiler).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task ActualizarAsync(Alquiler alquiler)
    {
        _context.Alquileres.Update(alquiler);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}