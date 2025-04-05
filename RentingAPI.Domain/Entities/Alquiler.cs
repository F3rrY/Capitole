using RentingAPI.Domain.Common;
using RentingAPI.Domain.Events;
using RentingAPI.Domain.Exceptions;

namespace RentingAPI.Domain.Entities;

public class Alquiler : AggregateRoot
{
    /// <summary>
    /// Id del alquiler
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Id del cliente que realiza el alquiler
    /// </summary>
    public Guid IdCliente { get; private set; }
    
    /// <summary>
    /// Id del vehículo a alquilar
    /// </summary>
    public Guid IdVehiculo { get; private set; }
    
    /// <summary>
    /// Fecha de alquiler
    /// </summary>
    public DateTime FechaAlquiler { get; private set; }
    
    /// <summary>
    /// Fecha de devolución
    /// </summary>
    public DateTime? FechaDevolucion { get; private set; }
    
    /// <summary>
    /// Constructor vacío
    /// </summary>
    private Alquiler() { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="idCliente">Id del cliente</param>
    /// <param name="idVehiculo">Id del vehículo</param>
    public Alquiler(Guid idCliente, Guid idVehiculo)
    {
        Id = Guid.NewGuid();
        IdCliente = idCliente;
        IdVehiculo = idVehiculo;
        FechaAlquiler = DateTime.UtcNow;
        
        AddDomainEvent(new AlquilerCreadoEvent(Id));
    }

    /// <summary>
    /// Método que devolverá el vehículo
    /// </summary>
    /// <exception cref="VehiculoDevueltoException">En caso de que el vehículo ya haya sido devuelto</exception>
    public void Devolver()
    {
        // Si tiene fecha de devolución, el alquiler ya ha sido devuelto previamente
        if (FechaDevolucion.HasValue)
            throw new VehiculoDevueltoException();
        
        FechaDevolucion = DateTime.UtcNow;
        
        AddDomainEvent(new AlquilerDevueltoEvent(Id));
    }
}
