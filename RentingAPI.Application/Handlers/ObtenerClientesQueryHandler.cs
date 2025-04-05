using MediatR;
using RentingAPI.Application.DTOs;
using RentingAPI.Application.Queries;
using RentingAPI.Domain.Repositories;

namespace RentingAPI.Application.Handlers;

public class ObtenerClientesQueryHandler : IRequestHandler<ObtenerClientesQuery, List<ClienteDto>>
{
    /// <summary>
    /// Interfaz del repositorio
    /// </summary>
    private readonly IClienteRepository _clienteRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="clienteRepository">Interfaz del repositorio</param>
    public ObtenerClientesQueryHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    /// <summary>
    /// Función que procesará la obtención de clientes
    /// </summary>
    /// <param name="request">Petición</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<List<ClienteDto>> Handle(ObtenerClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _clienteRepository.ObtenerAsync().ConfigureAwait(false);

        var clientesDto = clientes.Select(cliente => new ClienteDto
        {
            Id = cliente.Id,
            DNI = cliente.DNI,
            Nombre = cliente.Nombre,
            Apellido = cliente.Apellido
        }).ToList();

        return clientesDto;
    }
}