using MediatR;
using RentingAPI.Domain.Events;

namespace RentingAPI.Application.Notifications;

public class AlquilerCreadoNotification : INotification
{
    /// <summary>
    /// Id del alquiler
    /// </summary>
    public Guid IdAlquiler { get; }
    
    /// <summary>
    /// Fecha del alquiler
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="evento">Evento del alquiler creado</param>
    public AlquilerCreadoNotification(AlquilerCreadoEvent evento)
    {
        IdAlquiler = evento.IdAlquiler;
        Fecha = evento.Fecha;
    }
}