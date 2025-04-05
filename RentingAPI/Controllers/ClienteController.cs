using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentingAPI.Application.Commands;
using RentingAPI.Application.DTOs;
using RentingAPI.Application.Queries;

namespace RentingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : Controller
{
    /// <summary>
    /// Mediator
    /// </summary>
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Endpoint para obtener los clientes
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var query = new ObtenerClientesQuery();
        var clientesDto = await _mediator.Send(query).ConfigureAwait(false);
        
        return Ok(clientesDto);
    }
    
    /// <summary>
    /// Endpoint para crear los clientes
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CrearClientes([FromBody] CrearClienteCommand command)
    {
        var result = await _mediator.Send(command).ConfigureAwait(false);
        return Ok($"Id del cliente: {result}");
    }
}