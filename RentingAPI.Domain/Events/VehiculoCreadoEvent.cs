using RentingAPI.Domain.Common;

namespace RentingAPI.Domain.Events;

public class VehiculoCreadoEvent : IDomainEvent
{
    /// <summary>
    /// Id del vehículo creado
    /// </summary>
    public Guid IdVehiculo { get; private set; }
    
    /// <summary>
    /// Fecha de creación
    /// </summary>
    public DateTime Fecha { get; } = DateTime.UtcNow;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="idVehiculo">Id del vehículo creado</param>
    public VehiculoCreadoEvent(Guid idVehiculo)
    {
        IdVehiculo = idVehiculo;
    }
}
