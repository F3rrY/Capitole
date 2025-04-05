namespace RentingAPI.Domain.Exceptions;

public class ClienteAlquilerVigenteException : Exception
{
    /// <summary>
    /// Excepción que se lanzará cuando la persona tenga un alquiler vigente
    /// </summary>
    public ClienteAlquilerVigenteException() : base("La persona ya tiene un vehículo alquilado.") { }
}