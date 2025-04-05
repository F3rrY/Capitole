using RentingAPI.Domain.Entities;

namespace RentingAPI.Domain.Repositories;

public interface IClienteRepository
{
    /// <summary>
    /// Función que obtendrá el cliente por id
    /// </summary>
    /// <param name="id">Id del cliente</param>
    /// <returns>Cliente en caso de que se encuentre</returns>
    Task<Cliente?> ObtenerPorIdAsync(Guid id);
    
    /// <summary>
    /// Función que obtendrá la lista de clientes
    /// </summary>
    /// <returns>Lista de clientes</returns>
    Task<List<Cliente>> ObtenerAsync();
    
    /// <summary>
    /// Método que agregará un cliente
    /// </summary>
    /// <param name="cliente">Cliente a agregar</param>
    /// <returns></returns>
    Task AgregarAsync(Cliente cliente);
}
