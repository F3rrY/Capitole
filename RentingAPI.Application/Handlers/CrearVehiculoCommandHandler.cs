using MediatR;
using RentingAPI.Application.Commands;
using RentingAPI.Application.Factories;
using RentingAPI.Application.Notifications;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Events;
using RentingAPI.Domain.Exceptions;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.UnitOfWork;

namespace RentingAPI.Application.Handlers;

public class CrearVehiculoCommandHandler : IRequestHandler<CrearVehiculoCommand, Guid>
{
    /// <summary>
    /// _mediator
    /// </summary>
    private readonly IMediator _mediator;
    
    /// <summary>
    /// Interfaz con el repositorio
    /// </summary>
    private readonly IVehiculoRepository _vehiculoRepository;
    
    /// <summary>
    /// Interfaz de Unit Of Work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;
    
    /// <summary>
    /// Factory del vehículo
    /// </summary>
    private readonly IVehiculoFactory _vehiculoFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="vehiculoRepository">Interfaz del repositorios</param>
    /// <param name="mediator">Mediator, para publicar los eventos</param>
    /// <param name="unitOfWork">Interfaz de Unit of Work</param>
    /// <param name="vehiculoFactory">Interfaz de la factory</param>
    public CrearVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IMediator mediator, IUnitOfWork unitOfWork, IVehiculoFactory vehiculoFactory)
    {
        _vehiculoRepository = vehiculoRepository;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _vehiculoFactory = vehiculoFactory;
    }

    /// <summary>
    /// Función que manejará la creación del vehículo
    /// </summary>
    /// <param name="request">CrearVehiculoCommand con la petición</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Guid del vehículo creado</returns>
    public async Task<Guid> Handle(CrearVehiculoCommand request, CancellationToken cancellationToken)
    {
        // Inicializamos la transacción
        await _unitOfWork.BeginTransactionAsync();
        
        try
        {
            // Llamamos a la Factory para crear el vehículo
            var vehiculo = await _vehiculoFactory.CrearVehiculo(request.Matricula, request.Marca, request.Modelo, request.AñoFabricacion);

            // Se agrega al repositorio
            await _vehiculoRepository.AgregarAsync(vehiculo);
            
            // Commiteamos los cambios
            await _unitOfWork.CommitAsync(cancellationToken);

            // Publicamos el evento y limpiamos los eventos
            foreach (var evento in vehiculo.DomainEvents)
            {
                if (evento is VehiculoCreadoEvent vehiculoCreado)
                {
                    await _mediator.Publish(new VehiculoCreadoNotification(vehiculoCreado), cancellationToken);
                }
            }
            vehiculo.ClearDomainEvents();
            
            // Devolvemos el Id del vehículo creado
            return vehiculo.Id;
        }
        catch (Exception ex)
        {
            // Deshacemos los cambios
            await _unitOfWork.RollbackAsync();
            
            Console.WriteLine($"Se ha producido un error creando el vehículo: {ex.Message}");
            throw;
        }
    }
}