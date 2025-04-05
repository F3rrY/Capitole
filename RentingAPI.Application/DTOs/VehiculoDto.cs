namespace RentingAPI.Application.DTOs;

public record VehiculoDto
{
    /// <summary>
    /// Id del vehículo
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Matrícula del vehículo
    /// </summary>
    public string Matricula { get; init; }
    
    /// <summary>
    /// Marca del vehículo
    /// </summary>
    public string Marca { get; init; }
    
    /// <summary>
    /// Modelo del vehículo
    /// </summary>
    public string Modelo { get; init; }
    
    /// <summary>
    /// Año de fabricación del vehículo
    /// </summary>
    public int AñoFabricacion { get; init; }
    
    /// <summary>
    /// Indica el estado del vehículo
    /// </summary>
    public string Estado { get; init; }
}
