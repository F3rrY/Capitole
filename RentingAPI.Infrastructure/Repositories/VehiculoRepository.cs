using Microsoft.EntityFrameworkCore;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.Data;

namespace RentingAPI.Infrastructure.Repositories;

public class VehiculoRepository: IVehiculoRepository
{
    /// <summary>
    /// Contexto de la aplicación
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    public VehiculoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Vehiculo?> ObtenerPorIdAsync(Guid id)
    {
        return await _context.Vehiculos.FindAsync(id).ConfigureAwait(false);
    }
    
    public async Task<Vehiculo?> ObtenerPorMatriculaAsync(string matricula)
    {
        return await _context.Vehiculos.FirstOrDefaultAsync(vehiculo => vehiculo.Matricula.Equals(matricula)).ConfigureAwait(false);
    }

    public async Task<List<Vehiculo>> ObtenerAsync()
    {
        return await _context.Vehiculos.ToListAsync().ConfigureAwait(false);
    }

    public async Task AgregarAsync(Vehiculo vehiculo)
    {
        await _context.Vehiculos.AddAsync(vehiculo).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task ActualizarAsync(Vehiculo vehiculo)
    {
        _context.Vehiculos.Update(vehiculo);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}
