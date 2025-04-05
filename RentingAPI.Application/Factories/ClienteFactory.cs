using RentingAPI.Domain.Entities;

namespace RentingAPI.Application.Factories;

public class ClienteFactory : IClienteFactory
{
    /// <summary>
    /// Función encargada de crear un cliente 
    /// </summary>
    /// <param name="dni">DNI del cliente</param>
    /// <param name="nombre">Nombre del cliente</param>
    /// <param name="apellido">Apellido del cliente</param>
    /// <returns>Objeto Cliente</returns>
    public Cliente CrearCliente(string dni, string nombre, string apellido)
    {
        return new Cliente(dni, nombre, apellido);
    }
}