using RentingAPI.Domain.Common;
using RentingAPI.Domain.Events;
using RentingAPI.Domain.Exceptions;

namespace RentingAPI.Domain.Entities;

public class Vehiculo : AggregateRoot
{
    /// <summary>
    /// Años de antiguedad del vehículo
    /// </summary>
    private const int AñosAntiguedadVehiculo = 5;
    
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Matrícula del vehículo
    /// </summary>
    public string Matricula { get; private set; }
    
    /// <summary>
    /// Marca del vehículo
    /// </summary>
    public string Marca { get; private set; }
    
    /// <summary>
    /// Modelo del vehículo
    /// </summary>
    public string Modelo { get; private set; }
    
    /// <summary>
    /// Año de fabricación
    /// </summary>
    public int AñoFabricacion { get; private set; }
    
    /// <summary>
    /// Indica el estado del vehículo
    /// </summary>
    public EstadoVehiculo Estado { get; private set; }
    
    /// <summary>
    /// Constructor vacío
    /// </summary>
    private Vehiculo() { }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="marca">Marca del vehículo</param>
    /// <param name="modelo">Modelo del vehículo</param>
    /// <param name="añoFabricacion">Año de fabricación del vehículo</param>
    /// <param name="matricula">Matrícula del vehículo</param>
    /// <exception cref="VehiculoAntiguoException">En caso de que el vehículo tenga más de 5 años</exception>
    public Vehiculo(string marca, string modelo, int añoFabricacion, string matricula)
    {
        // Si el año de fabricación es superior a 5 años, lanzamos excepción
        if (añoFabricacion < DateTime.UtcNow.Year - AñosAntiguedadVehiculo)
            throw new VehiculoAntiguoException();

        Id = Guid.NewGuid();
        Marca = marca;
        Modelo = modelo;
        AñoFabricacion = añoFabricacion;
        Matricula = matricula;
        Estado = EstadoVehiculo.Disponible;
        
        // Añadimos el evento de dominio
        AddDomainEvent(new VehiculoCreadoEvent(Id));
    }

    /// <summary>
    /// Método que alquilará el vehículo
    /// </summary>
    /// <exception cref="VehiculoAlquiladoException">En caso de que el vehículo esté alquilado</exception>
    public void Alquilar(Guid idCliente)
    {
        // Verificar si el vehiculo está disponible para alquilar
        if (Estado != EstadoVehiculo.Disponible)
            throw new VehiculoAlquiladoException();
        
        Estado = EstadoVehiculo.Alquilado;
        
        // Añadimos el evento de dominio
        AddDomainEvent(new VehiculoAlquiladoEvent(Id, idCliente));
    }

    /// <summary>
    /// Método que devolverá el vehículo
    /// </summary>
    public void Devolver()
    {
        Estado = EstadoVehiculo.Disponible;
        
        // Añadimos el evento de dominio
        AddDomainEvent(new VehiculoDevueltoEvent(Id));
    }
}
