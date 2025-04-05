using RentingAPI.Domain.Entities;

namespace RentingAPI.Domain.Repositories;

public interface IAlquilerRepository
{
    /// <summary>
    /// Función que obtendrá el alquiler activo por cliente
    /// </summary>
    /// <param name="idCliente">Id del cliente</param>
    /// <returns></returns>
    Task<Alquiler?> ObtenerAlquilerActivoPorClienteAsync(Guid idCliente);
    
    /// <summary>
    /// Función que obtendrá el alquiler activo por vehículo
    /// </summary>
    /// <param name="idVehiculo">Id del vehículo</param>
    /// <returns></returns>
    Task<Alquiler?> ObtenerAlquilerActivoPorIdVehiculoAsync(Guid idVehiculo);
    
    /// <summary>
    /// Método que agregará un alquiler
    /// </summary>
    /// <param name="alquiler">Alquiler a agregar</param>
    /// <returns></returns>
    Task AgregarAsync(Alquiler alquiler);
    
    /// <summary>
    /// Método que actualizará un alquiler
    /// </summary>
    /// <param name="alquiler">Alquiler a actualizar</param>
    /// <returns></returns>
    Task ActualizarAsync(Alquiler alquiler);
}
