using MediatR;

namespace RentingAPI.Application.Commands;

public record CrearVehiculoCommand(string Matricula, string Marca, string Modelo, int AñoFabricacion) : IRequest<Guid>;