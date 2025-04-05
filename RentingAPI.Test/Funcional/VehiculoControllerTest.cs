using System.Net;
using System.Text;
using Newtonsoft.Json;
using RentingAPI.Application.Commands;
using RentingAPI.Test.Factories;

namespace RentingAPI.Test.Funcional;

public class VehiculoControllerTest : IClassFixture<CustomWebapiFactory>
{
    private readonly HttpClient _client;

    public VehiculoControllerTest(CustomWebapiFactory factory)
    {
        _client = factory.CreateClient();
    }
    
    [Fact]
    public async Task CrearVehiculo_OK()
    {
        // Creamos una solicitud con identificadores vacíos (inválidos)
        var command = new CrearVehiculoCommand("1234ABC", "Seat", "Ibiza", 2024);

        // Creamos el JSON de la llamada
        var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

        // Hacemos la llamada al Controller
        var response = await _client.PostAsync("/api/vehiculo", content).ConfigureAwait(false);

        // Verificamos que la respuesta es OK, querrá decir que se ha creado el registro a BD
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
