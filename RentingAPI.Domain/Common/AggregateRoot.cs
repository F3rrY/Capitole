namespace RentingAPI.Domain.Common;

public abstract class AggregateRoot
{
    /// <summary>
    /// _domainEvents
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// DomainEvents
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Método para añadir los eventos de dominio
    /// </summary>
    /// <param name="domainEvent">Evento de dominio a agregar</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Método para eliminar los eventos de dominio
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
