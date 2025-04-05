using MediatR;
using RentingAPI.Application.DTOs;

namespace RentingAPI.Application.Queries;

public class ObtenerVehiculosQuery() : IRequest<List<VehiculoDto>>;
