namespace RentingAPI.Domain.Exceptions;

public class MatriculaExistenteException : Exception
{
    /// <summary>
    /// Excepción en caso de que ya tengamos un vehículo con la matrícula informadda
    /// </summary>
    public MatriculaExistenteException() : base("Ya existe un vehículo con esta matricula.") { }
}