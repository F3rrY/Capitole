namespace RentingAPI.Domain.Exceptions;

public class VehiculoExistenteException : Exception
{
    /// <summary>
    /// Excepción en caso de que la matrícula ya exista en nuestra base de datos
    /// </summary>
    public VehiculoExistenteException() : base("Ya existe un vehículo con esta matricula.") { }
}