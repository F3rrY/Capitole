namespace RentingAPI.Domain.Exceptions;

public class MatriculaVaciaException : Exception
{
    #region Constructores
    
    /// <summary>
    /// Excepción en caso que no tengamos la matrícula informada
    /// </summary>
    public MatriculaVaciaException() : base("La matrícula no puede estar vacía.") { }
    
    #endregion
}