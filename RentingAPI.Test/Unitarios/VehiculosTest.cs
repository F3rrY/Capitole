using FluentAssertions;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Exceptions;

namespace RentingAPI.Test.Unitarios;

public class VehiculosTest
{
    [Fact]
    public void CrearVehiculo_Ok()
    {
        // Arrange
        var vehiculo = new Vehiculo("Opel", "Corsa", 2024, "1111ABC");
        
        // Act && Assert
        vehiculo.Id.Should().NotBeEmpty();
        vehiculo.Marca.Should().Be("Opel");
        vehiculo.Modelo.Should().Be("Corsa");
        vehiculo.AñoFabricacion.Should().Be(2024);
        vehiculo.Matricula.Should().Be("1111ABC");
    }
    
    [Fact]
    public void CrearVehiculo_VehiculoAntiguoException()
    {
        FluentActions.Invoking(() => new Vehiculo("Opel", "Corsa", 2005, "1111ABC")).Should()
            .Throw<VehiculoAntiguoException>();
    }
}