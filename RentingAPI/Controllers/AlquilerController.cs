using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentingAPI.Application.Commands;

namespace RentingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlquilerController : ControllerBase
{
    /// <summary>
    /// Mediator
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public AlquilerController(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    /// <summary>
    /// Endpoint para alquilar un vehículo
    /// </summary>
    /// <returns></returns>
    [HttpPost("alquilar")]
    public async Task<IActionResult> AlquilarVehiculo([FromBody] AlquilarVehiculoCommand command)
    {
        // Validamos que tenemos todos los datos
        if (command.IdVehiculo == Guid.Empty || command.IdCliente == Guid.Empty)
        {
            return BadRequest("Los identificadores no pueden estar vacíos.");
        }
        
        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok($"Id del alquiler: {result}");
    }
        
    /// <summary>
    /// Endpoint para devolver un vehículo
    /// </summary>
    /// <returns></returns>
    [HttpPost("devolver")]
    public async Task<IActionResult> DevolverVehiculo([FromBody] DevolverVehiculoCommand command)
    {
        // Validamos que tenemos todos los datos
        if (command.IdVehiculo == Guid.Empty)
        {
            return BadRequest("El identificador del vehículo no puede estar vacío.");
        }
        
        await _mediator.Send(command).ConfigureAwait(false);
        return Ok($"Alquiler del vehiculo {command.IdVehiculo} finalizado correctamente");
    }
}