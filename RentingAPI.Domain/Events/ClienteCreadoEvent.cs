using RentingAPI.Domain.Common;

namespace RentingAPI.Domain.Events;

public class ClienteCreadoEvent : IDomainEvent
{
    /// <summary>
    /// Id del cliente creado
    /// </summary>
    public Guid IdCliente { get; }
    
    /// <summary>
    /// Fecha de creación del cliente
    /// </summary>
    public DateTime Fecha { get; } = DateTime.UtcNow;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="idCliente">Id del cliente creado</param>
    public ClienteCreadoEvent(Guid idCliente)
    {
        IdCliente = idCliente;
    }
}