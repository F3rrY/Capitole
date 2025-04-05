namespace RentingAPI.Domain.Exceptions;

public class VehiculoAntiguoException : Exception
{
    /// <summary>
    /// Excepción en caso de que el vehículo tenga mas de 5 años
    /// </summary>
    public VehiculoAntiguoException() : base("El vehículo no puede tener más de 5 años.") { }
}