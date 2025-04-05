using FluentAssertions;
using RentingAPI.Domain.Entities;

namespace RentingAPI.Test.Unitarios;

public class ClientesTest
{
    [Fact]
    public void CrearCliente_Ok()
    {
        // Arrange
        var cliente = new Cliente("12345678H", "Ferran", "Muñoz");
        
        // Act && Assert
        cliente.Id.Should().NotBeEmpty();
        cliente.DNI.Should().Be("12345678H");
        cliente.Nombre.Should().Be("Ferran");
        cliente.Apellido.Should().Be("Muñoz");
    }
}