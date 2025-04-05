namespace RentingAPI.Domain.Exceptions;

public class VehiculoAlquiladoException : Exception
{
    /// <summary>
    /// Excepción en caso de que el vehículo esté alquilado
    /// </summary>
    public VehiculoAlquiladoException() : base("El vehículo ya está alquilado.") {}    
}