namespace RentingAPI.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    /// <summary>
    /// Método para manejar el comienzo de las transacciones
    /// </summary>
    /// <returns></returns>
    Task BeginTransactionAsync();
    
    /// <summary>
    /// Método para comitear las transacciones
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CommitAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Método para manejar en caso de error en las transacciones
    /// </summary>
    /// <returns></returns>
    Task RollbackAsync();
}