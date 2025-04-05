using RentingAPI.Domain.Common;

namespace RentingAPI.Domain.Events;

public class AlquilerCreadoEvent : IDomainEvent
{
    /// <summary>
    /// Id del alquiler
    /// </summary>
    public Guid IdAlquiler { get; }
    
    /// <summary>
    /// Fecha del alquiler
    /// </summary>
    public DateTime Fecha { get; } = DateTime.UtcNow;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="idAlquiler">Id del alquiler</param>
    public AlquilerCreadoEvent(Guid idAlquiler)
    {
        IdAlquiler = idAlquiler;
    }
}
