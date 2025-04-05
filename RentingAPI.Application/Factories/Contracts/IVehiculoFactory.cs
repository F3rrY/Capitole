using RentingAPI.Domain.Entities;

namespace RentingAPI.Application.Factories;

public interface IVehiculoFactory
{
    /// <summary>
    /// Función encargada de crear el vehículo
    /// </summary>
    /// <param name="matricula">Matrícula del vehículo</param>
    /// <param name="marca">Marca del vehículo</param>
    /// <param name="modelo">Modelo del vehículo</param>
    /// <param name="añoFabricacion">Año de fabricación del vehículo</param>
    /// <returns>Objeto Vehículo</returns>
    Task<Vehiculo> CrearVehiculo(string matricula, string marca, string modelo, int añoFabricacion);
}