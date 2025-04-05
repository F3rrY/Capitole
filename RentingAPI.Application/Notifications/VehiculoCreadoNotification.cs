using MediatR;
using RentingAPI.Domain.Events;

namespace RentingAPI.Application.Notifications;

public class VehiculoCreadoNotification : INotification
{
    /// <summary>
    /// Id del vehículo creado
    /// </summary>
    public Guid IdVehiculo { get; private set; }

    /// <summary>
    /// Fecha de creación
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="evento">Evento del vehículo creado</param>
    public VehiculoCreadoNotification(VehiculoCreadoEvent evento)
    {
        IdVehiculo = evento.IdVehiculo;
        Fecha = evento.Fecha;
    }
}