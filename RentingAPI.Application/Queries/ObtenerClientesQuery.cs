using MediatR;
using RentingAPI.Application.DTOs;

namespace RentingAPI.Application.Queries;

public class ObtenerClientesQuery() : IRequest<List<ClienteDto>>;