using MediatR;
using RentingAPI.Domain.Events;

namespace RentingAPI.Application.Notifications;

public class VehiculoAlquiladoNotification : INotification
{
    /// <summary>
    /// IdVehiculo
    /// </summary>
    public Guid IdVehiculo { get; }
    
    /// <summary>
    /// IdCliente
    /// </summary>
    public Guid IdCliente { get; }

    /// <summary>
    /// Fecha
    /// </summary>
    public DateTime Fecha { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="evento">Evento del vehículo alquilado</param>
    public VehiculoAlquiladoNotification(VehiculoAlquiladoEvent evento)
    {
        IdVehiculo = evento.IdVehiculo;
        IdCliente = evento.IdCliente;
        Fecha = evento.Fecha;
    }
}