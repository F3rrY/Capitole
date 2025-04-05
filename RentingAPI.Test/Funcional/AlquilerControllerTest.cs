using System.Net;
using System.Text;
using Newtonsoft.Json;
using RentingAPI.Application.Commands;
using RentingAPI.Test.Factories;

namespace RentingAPI.Test.Funcional;

public class AlquilerControllerTest(CustomWebapiFactory factory) : IClassFixture<CustomWebapiFactory>
{
    [Fact]
    public async Task AlquilarVehiculo_BadRequest()
    {
        // Creamos una solicitud con identificadores vacíos (inválidos)
        var command = new AlquilarVehiculoCommand(Guid.Empty, Guid.Empty);

        // Creamos el JSON de la llamada
        var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

        // Hacemos la llamada al Controller
        var response = await factory.CreateClient().PostAsync("/api/alquiler/alquilar", content);

        // Verificamos que la respuesta es un BadRequest
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}