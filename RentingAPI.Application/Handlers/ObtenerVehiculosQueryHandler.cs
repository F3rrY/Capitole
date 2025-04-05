using MediatR;
using RentingAPI.Application.DTOs;
using RentingAPI.Application.Queries;
using RentingAPI.Domain.Repositories;

namespace RentingAPI.Application.Handlers;

public class ObtenerVehiculosQueryHandler : IRequestHandler<ObtenerVehiculosQuery, List<VehiculoDto>>
{
    /// <summary>
    /// Repositorio de vehículos
    /// </summary>
    private readonly IVehiculoRepository _vehiculoRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="vehiculoRepository">Interfaz del repositorio</param>
    public ObtenerVehiculosQueryHandler(IVehiculoRepository vehiculoRepository)
    {
        _vehiculoRepository = vehiculoRepository;
    }

    /// <summary>
    /// Función que procesará la obtención del vehículo
    /// </summary>
    /// <param name="request">Petición</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task<List<VehiculoDto>> Handle(ObtenerVehiculosQuery request, CancellationToken cancellationToken)
    {
        var vehiculos = await _vehiculoRepository.ObtenerAsync().ConfigureAwait(false);

        var vehiculosDto = vehiculos.Select(vehiculo => new VehiculoDto
        {
            Id = vehiculo.Id,
            Matricula = vehiculo.Matricula,
            Marca = vehiculo.Marca,
            Modelo = vehiculo.Modelo,
            AñoFabricacion = vehiculo.AñoFabricacion,
            Estado = vehiculo.Estado.ToString()
        }).ToList();

        return vehiculosDto;
    }
}
