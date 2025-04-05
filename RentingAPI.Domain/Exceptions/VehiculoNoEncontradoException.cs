namespace RentingAPI.Domain.Exceptions;

public class VehiculoNoEncontradoException : Exception
{
    /// <summary>
    /// Excepción que se lanzará en caso de no encontrar el vehículo
    /// </summary>
    /// <param name="id"></param>
    public VehiculoNoEncontradoException(Guid id) :base($"No se encontró el vehículo con ID {id}") { }
}