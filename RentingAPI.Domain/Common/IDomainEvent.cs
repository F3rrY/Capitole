namespace RentingAPI.Domain.Common;

/// <summary>
/// Interfaz IDomainEvent para los eventos de dominio
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Fecha cuando ocurrirá el evento
    /// </summary>
    DateTime Fecha { get; }
}