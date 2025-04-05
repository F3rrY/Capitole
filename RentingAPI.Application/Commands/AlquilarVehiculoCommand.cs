using MediatR;

namespace RentingAPI.Application.Commands;

public record AlquilarVehiculoCommand(Guid IdVehiculo, Guid IdCliente) : IRequest<Guid>;
