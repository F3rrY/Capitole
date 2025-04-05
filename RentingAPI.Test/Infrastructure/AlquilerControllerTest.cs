using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using RentingAPI.Application.Commands;
using RentingAPI.Controllers;

namespace RentingAPI.Test.Infrastructure;

public class AlquilerControllerTest
{
    /// <summary>
    /// Controller de Alquile
    /// </summary>
    private readonly AlquilerController _controller;
    
    /// <summary>
    /// Mock con el Mediator
    /// </summary>
    private readonly Mock<IMediator> _mediator;

    /// <summary>
    /// Constructor
    /// </summary>
    public AlquilerControllerTest()
    {
        // Creamos el mock de mediator
        _mediator = new Mock<IMediator>();
        
        // Instanciamos el controller de Alquiler
        _controller = new AlquilerController(_mediator.Object);
    }
    
    [Fact]
    public async Task AlquilarVehiculo_InvalidModel_BadRequest()
    {
        // Creamos una solicitud con datos inválidos (identificadores vacíos)
        var command = new AlquilarVehiculoCommand(Guid.Empty, Guid.Empty);

        var result = await _controller.AlquilarVehiculo(command).ConfigureAwait(false);

        // Verificamos que la respuesta es un error de validación (Bad Request)
        Assert.IsType<BadRequestObjectResult>(result);
    }
}