using RentingAPI.Domain.Common;
using RentingAPI.Domain.Events;

namespace RentingAPI.Domain.Entities;

public class Cliente : AggregateRoot
{
    /// <summary>
    /// Id del cliente
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// DNI del cliente
    /// </summary>
    public string DNI { get; private set; }
    
    /// <summary>
    /// Nombre del cliente
    /// </summary>
    public string Nombre { get; private set; }
    
    /// <summary>
    /// Apellido del cliente
    /// </summary>
    public string Apellido { get; private set; }
    
    /// <summary>
    /// Constructor vacío
    /// </summary>
    private Cliente() { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="dni">DNI del cliente</param>
    /// <param name="nombre">Nombre del cliente</param>
    /// <param name="apellido">Apellido del cliente</param>
    public Cliente(string dni, string nombre, string apellido)
    {
        Id = Guid.NewGuid();
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        
        // Añadimos el evento de dominio
        AddDomainEvent(new ClienteCreadoEvent(Id));
    }
}
