namespace RentingAPI.Domain.Exceptions;

public class AlquilerNoEncontradoException : Exception
{
    public AlquilerNoEncontradoException(string matricula) : base($"No se ha encontrado ningún alquiler para el vehículo {matricula}.") { }
}