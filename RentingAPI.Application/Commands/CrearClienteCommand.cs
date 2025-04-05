using MediatR;

namespace RentingAPI.Application.Commands;

public record CrearClienteCommand(string Dni, string Nombre, string Apellido) : IRequest<Guid>;