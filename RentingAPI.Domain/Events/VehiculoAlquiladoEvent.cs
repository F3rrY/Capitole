using RentingAPI.Domain.Common;

namespace RentingAPI.Domain.Events;

public class VehiculoAlquiladoEvent : IDomainEvent
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
    public DateTime Fecha { get; } = DateTime.UtcNow;

    /// <summary>
    /// Constructor del evento
    /// </summary>
    /// <param name="idVehiculo">Id del vehículo</param>
    /// <param name="idCliente">Id del cliente</param>
    public VehiculoAlquiladoEvent(Guid idVehiculo, Guid idCliente)
    {
        IdVehiculo = idVehiculo;
        IdCliente = idCliente;
    }
}
