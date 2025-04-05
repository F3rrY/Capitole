using MediatR;
using RentingAPI.Application.Commands;
using RentingAPI.Application.Notifications;
using RentingAPI.Domain.Events;
using RentingAPI.Domain.Exceptions;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.UnitOfWork;

namespace RentingAPI.Application.Handlers;

public class DevolverVehiculoCommandHandler : IRequestHandler<DevolverVehiculoCommand, bool>
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
    /// Interfaz con el repositorio de alquileres
    /// </summary>
    private readonly IAlquilerRepository _alquilerRepository;
    
    /// <summary>
    /// Interfaz de Unit Of Work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="vehiculoRepository">Interfaz del repositorio</param>
    /// <param name="alquilerRepository">Interfaz del repositorio</param>
    /// <param name="mediator">Mediator, para publicar los eventos</param>
    /// <param name="unitOfWork">Interfaz de Unit Of Work</param>
    public DevolverVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IAlquilerRepository alquilerRepository,  IMediator mediator, IUnitOfWork unitOfWork)
    {
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Función que manejará la devolución de un vehículo alquilado
    /// </summary>
    /// <param name="request">DevolverVehiculoCommand con la petición</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>True en caso de que el proceso haya ido bien. False en caso de error</returns>
    /// <exception cref="VehiculoNoEncontradoException">En caso de no encontrar el vehículo</exception>
    public async Task<bool> Handle(DevolverVehiculoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Inicializamos la transacción
            await _unitOfWork.BeginTransactionAsync();
            
            // Buscamos el vehículo alquilado
            var vehiculo = await _vehiculoRepository.ObtenerPorIdAsync(request.IdVehiculo);
            if (vehiculo is null)
                throw new VehiculoNoEncontradoException(request.IdVehiculo);

            // Devolvemos el vehículo
            vehiculo.Devolver();

            // Actualizamos el vehículo
            await _vehiculoRepository.ActualizarAsync(vehiculo);
            
            // Obtenemos el alquiler de ese vehículo
            var alquiler = await _alquilerRepository.ObtenerAlquilerActivoPorIdVehiculoAsync(vehiculo.Id);
            if (alquiler is null)
                throw new AlquilerNoEncontradoException(vehiculo.Matricula);
            
            // Finalizamos el alquiler
            alquiler.Devolver();
            
            // Actualizamos el alquiler
            await _alquilerRepository.ActualizarAsync(alquiler);

            // Commiteamos los cambios
            await _unitOfWork.CommitAsync(cancellationToken);

            // Publicar evento de dominio
            foreach (var evento in vehiculo.DomainEvents)
            {
                // Lanzamos el evento de vehículo devuelto
                if (evento is VehiculoDevueltoEvent vehiculoDevuelto)
                {
                    await _mediator.Publish(new VehiculoDevueltoNotification(vehiculoDevuelto), cancellationToken);
                }
                
                // Lanzamos el evento de alquiler terminado
                if (evento is AlquilerDevueltoEvent alquilerDevuelto)
                {
                    await _mediator.Publish(new AlquilerDevueltoNotification(alquilerDevuelto), cancellationToken);
                }
            }

            vehiculo.ClearDomainEvents();

            return true;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            
            Console.WriteLine($"Se ha producido un error creando el vehículo: {ex.Message}");
            throw;
        }
    }
}