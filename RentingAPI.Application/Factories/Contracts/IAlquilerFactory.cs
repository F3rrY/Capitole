using RentingAPI.Domain.Entities;

namespace RentingAPI.Application.Factories;

public interface IAlquilerFactory
{
    /// <summary>
    /// Función encargada de crear un alquiler 
    /// </summary>
    /// <param name="idVehiculo">Id del vehículo a alquilar</param>
    /// <param name="idCliente">Id del cliente a alquilar</param>
    /// <returns>Objeto Alquiler</returns>
    Task<Alquiler> CrearAlquiler(Guid idCliente, Guid idVehiculo);
}