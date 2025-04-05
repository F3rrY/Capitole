using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Exceptions;
using RentingAPI.Domain.Repositories;

namespace RentingAPI.Application.Factories;

public class AlquilerFactory : IAlquilerFactory
{
    /// <summary>
    /// Interfaz con el repositorio de alquileres
    /// </summary>
    private readonly IAlquilerRepository _alquilerRepository;
    
    /// <summary>
    /// Interfaz con el repositorio de cliente
    /// </summary>
    private readonly IClienteRepository _clienteRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="alquilerRepository">Interfaz con el repositorio de alquiler</param>
    /// <param name="clienteRepository">Interfaz con el repositorio de cliente</param>
    public AlquilerFactory(IAlquilerRepository alquilerRepository, IClienteRepository clienteRepository)
    {
        _alquilerRepository = alquilerRepository;
        _clienteRepository = clienteRepository;
    }
    
    /// <summary>
    /// Función encargada de crear un alquiler 
    /// </summary>
    /// <param name="idVehiculo">Id del vehículo a alquilar</param>
    /// <param name="idCliente">Id del cliente a alquilar</param>
    /// <returns>Objeto Alquiler</returns>
    public async Task<Alquiler> CrearAlquiler(Guid idCliente, Guid idVehiculo)
    {
        // Verificar el cliente que realizará el alquiler
        var cliente = await _clienteRepository.ObtenerPorIdAsync(idCliente).ConfigureAwait(false);
        if (cliente is null)
            throw new ClienteNoEncontradoException(idCliente);
        
        // Verificar si el cliente ya tiene un alquiler activo
        var alquilerActivo = await _alquilerRepository.ObtenerAlquilerActivoPorClienteAsync(cliente.Id).ConfigureAwait(false);
        if (alquilerActivo != null)
            throw new ClienteAlquilerVigenteException();
        
        return new Alquiler(cliente.Id, idVehiculo);
    }
}