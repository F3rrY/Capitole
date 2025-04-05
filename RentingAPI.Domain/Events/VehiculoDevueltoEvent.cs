using RentingAPI.Domain.Common;

namespace RentingAPI.Domain.Events;

public class VehiculoDevueltoEvent : IDomainEvent
{
    /// <summary>
    /// IdVehiculo
    /// </summary>
    public Guid IdVehiculo { get; }
    
    /// <summary>
    /// Fecha de la devolución
    /// </summary>
    public DateTime Fecha { get; } = DateTime.UtcNow;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="idVehiculo">Id del vehículo a devolver</param>
    public VehiculoDevueltoEvent(Guid idVehiculo)
    {
        IdVehiculo = idVehiculo;
    }
}