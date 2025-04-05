namespace RentingAPI.Domain.Exceptions;

public class ClienteNoEncontradoException : Exception
{
    /// <summary>
    /// Excepción que se lanzará en caso de no encontrar el cliente
    /// </summary>
    /// <param name="id"></param>
    public ClienteNoEncontradoException(Guid id) :base($"No se encontró el cliente con ID {id}") { }
}