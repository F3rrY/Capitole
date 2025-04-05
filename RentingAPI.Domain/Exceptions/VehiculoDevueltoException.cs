namespace RentingAPI.Domain.Exceptions;

public class VehiculoDevueltoException : Exception
{
    /// <summary>
    /// Excepción en caso de que el vehículo ya haya sido devuelto
    /// </summary>
    public VehiculoDevueltoException() : base("El vehículo ya fue devuelto.") { }
}