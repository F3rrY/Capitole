using RentingAPI.Domain.Entities;

namespace RentingAPI.Domain.Repositories;

public interface IVehiculoRepository
{
    /// <summary>
    /// Función que obtendrá el vehículo por id
    /// </summary>
    /// <param name="id">Id del vehículo</param>
    /// <returns>Vehiculo en caso de que se encuentre</returns>
    Task<Vehiculo?> ObtenerPorIdAsync(Guid id);
    
    /// <summary>
    /// Función que obtendrá el vehículo por matrícula
    /// </summary>
    /// <param name="matricula">Matrícula del vehículo</param>
    /// <returns>Vehiculo en caso de que se encuentre</returns>
    Task<Vehiculo?> ObtenerPorMatriculaAsync(string matricula);
    
    /// <summary>
    /// Función que obtendrá la lista de vehiculos
    /// </summary>
    /// <returns>Lista de vehículos</returns>
    Task<List<Vehiculo>> ObtenerAsync();
    
    /// <summary>
    /// Método que agregará un vehículo
    /// </summary>
    /// <param name="vehiculo">Vehículo a agregar</param>
    /// <returns></returns>
    Task AgregarAsync(Vehiculo vehiculo);
    
    /// <summary>
    /// Método que actualizará un vehículo
    /// </summary>
    /// <param name="vehiculo">Vehículo a actualizar</param>
    /// <returns></returns>
    Task ActualizarAsync(Vehiculo vehiculo);
}
