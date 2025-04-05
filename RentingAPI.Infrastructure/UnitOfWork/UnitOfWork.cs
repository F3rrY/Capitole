using Microsoft.EntityFrameworkCore.Storage;
using RentingAPI.Infrastructure.Data;

namespace RentingAPI.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// Contexto de la aplicación
    /// </summary>
    private readonly ApplicationDbContext _context;
    
    /// <summary>
    /// interfaz de transacción
    /// </summary>
    private IDbContextTransaction _transaction;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <summary>
    /// Método para manejar el comienzo de las transacciones
    /// </summary>
    /// <returns></returns>
    public Task BeginTransactionAsync()
    {
        if(_transaction == null)
            _transaction = _context.Database.BeginTransaction();
        
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Método para comitear las transacciones
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
            throw new InvalidOperationException("La transacción no se ha inicializado");

        try
        {
            await _context.SaveChangesAsync(cancellationToken);

            await _transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Se ha producido un error al commitear", ex);
        }
        finally
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    /// <summary>
    /// Método para manejar en caso de error en las transacciones
    /// </summary>
    /// <returns></returns>
    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
            _transaction = null;
        }
    }
}