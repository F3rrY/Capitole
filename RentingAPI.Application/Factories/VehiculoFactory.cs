using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Exceptions;
using RentingAPI.Domain.Repositories;

namespace RentingAPI.Application.Factories;

public class VehiculoFactory : IVehiculoFactory
{
    /// <summary>
    /// Interfaz del repositorio
    /// </summary>
    private readonly IVehiculoRepository _vehiculoRepository;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="vehiculoRepository">Interfaz del repositorio</param>
    public VehiculoFactory(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository;
    }
    
    /// <summary>
    /// Función encargada de crear el vehículo
    /// </summary>
    /// <param name="matricula">Matrícula del vehículo</param>
    /// <param name="marca">Marca del vehículo</param>
    /// <param name="modelo">Modelo del vehículo</param>
    /// <param name="añoFabricacion">Año de fabricación del vehículo</param>
    /// <returns>Objeto Vehículo</returns>
    public async Task<Vehiculo> CrearVehiculo(string matricula, string marca, string modelo, int añoFabricacion)
    {
        // Verificamos que esa matricula no la tenemos en base de datos
        var vehiculoExistente = await _vehiculoRepository.ObtenerPorMatriculaAsync(matricula).ConfigureAwait(false);
        if (vehiculoExistente is not null)
            throw new VehiculoExistenteException();
        
        return new Vehiculo(marca, modelo, añoFabricacion, matricula);
    }
}