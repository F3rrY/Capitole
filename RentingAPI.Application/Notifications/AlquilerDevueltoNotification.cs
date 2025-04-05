using MediatR;
using RentingAPI.Domain.Events;

namespace RentingAPI.Application.Notifications;

public class AlquilerDevueltoNotification : INotification
{
    /// <summary>
    /// Id del alquiler devuelto;
    /// </summary>
    public Guid IdAlquiler { get; }
    
    /// <summary>
    /// Fecha de devolución
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="evento">Evento de alquiler devuelto</param>
    public AlquilerDevueltoNotification(AlquilerDevueltoEvent evento)
    {
        IdAlquiler = evento.IdAlquiler;
        Fecha = evento.Fecha;
    }
}