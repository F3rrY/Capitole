using MediatR;
using RentingAPI.Domain.Events;

namespace RentingAPI.Application.Notifications;

public class ClienteCreadoNotification : INotification
{
    /// <summary>
    /// Id del cliente creado
    /// </summary>
    public Guid IdCliente { get; }
    
    /// <summary>
    /// Fecha de creación del cliente
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="evento">Evento del cliente creado</param>
    public ClienteCreadoNotification(ClienteCreadoEvent evento)
    {
        IdCliente = evento.IdCliente;
        Fecha = evento.Fecha;
    }
}