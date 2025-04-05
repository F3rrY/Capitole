using MediatR;

namespace RentingAPI.Application.Commands;

public record DevolverVehiculoCommand(Guid IdVehiculo) : IRequest<bool>;