using MediatR;
using RentingAPI.Domain.Events;

namespace RentingAPI.Application.Notifications;

public class VehiculoDevueltoNotification : INotification
{
    /// <summary>
    /// IdVehiculo
    /// </summary>
    public Guid IdVehiculo { get; }
    
    /// <summary>
    /// Fecha de la devolución
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Fecha
    /// </summary>
    /// <param name="evento">Evento de la devolución del vehículo</param>
    public VehiculoDevueltoNotification(VehiculoDevueltoEvent evento)
    {
        IdVehiculo = evento.IdVehiculo;
        Fecha = evento.Fecha;
    }
}