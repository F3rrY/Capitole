using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentingAPI.Application.Commands;
using RentingAPI.Application.DTOs;
using RentingAPI.Application.Queries;

namespace RentingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        /// <summary>
        /// Mediator
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public VehiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Endpoint para obtener los vehículos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObtenerVehiculos()
        {
            var query = new ObtenerVehiculosQuery();
            var vehiculosDto = await _mediator.Send(query).ConfigureAwait(false);

            return Ok(vehiculosDto);
        }
        
        /// <summary>
        /// Endpoint para crear los vehículos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CrearVehiculos([FromBody] CrearVehiculoCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok($"Guid del vehículo: {result}");
        }
    }
}
