using Microsoft.EntityFrameworkCore;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.Data;

namespace RentingAPI.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    /// <summary>
    /// Contexto de la aplicación
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Cliente?> ObtenerPorIdAsync(Guid id)
    {
        return await _context.Clientes.FindAsync(id).ConfigureAwait(false);
    }

    public async Task<List<Cliente>> ObtenerAsync()
    {
        return await _context.Clientes.ToListAsync().ConfigureAwait(false);
    }

    public async Task AgregarAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}