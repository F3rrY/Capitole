using RentingAPI.Domain.Entities;

namespace RentingAPI.Application.Factories;

public interface IClienteFactory
{
    /// <summary>
    /// Función encargada de crear un cliente 
    /// </summary>
    /// <param name="dni">DNI del cliente</param>
    /// <param name="nombre">Nombre del cliente</param>
    /// <param name="apellido">Apellido del cliente</param>
    /// <returns>Objeto Cliente</returns>
    Cliente CrearCliente(string dni, string nombre, string apellido);
}