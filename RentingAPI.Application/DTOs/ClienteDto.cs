namespace RentingAPI.Application.DTOs;

public class ClienteDto
{
    /// <summary>
    /// Id del cliente
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// DNI
    /// </summary>
    public string DNI { get; set; }
    
    /// <summary>
    /// Nombre del cliente
    /// </summary>
    public string Nombre { get; set; }
    
    /// <summary>
    /// Apellido del cliente
    /// </summary>
    public string Apellido { get; set; }
}