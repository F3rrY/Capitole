using RentingAPI.Domain.Common;

namespace RentingAPI.Domain.Events;

public class AlquilerDevueltoEvent : IDomainEvent
{
    /// <summary>
    /// Id del alquiler devuelto;
    /// </summary>
    public Guid IdAlquiler { get; }
    
    /// <summary>
    /// Fecha de devolución
    /// </summary>
    public DateTime Fecha { get; } = DateTime.UtcNow;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="idAlquiler">Id del alquiler devuelto</param>
    public AlquilerDevueltoEvent(Guid idAlquiler)
    {
        IdAlquiler = idAlquiler;
    }
}