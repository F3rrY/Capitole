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

public class AlquilarVehiculoCommandHandler: IRequestHandler<AlquilarVehiculoCommand, Guid>
{
    /// <summary>
    /// _mediator
    /// </summary>
    private readonly IMediator _mediator;
    
    /// <summary>
    /// Interfaz con el repositorio de vehículos
    /// </summary>
    private readonly IVehiculoRepository _vehiculoRepository;
    
    /// <summary>
    /// Interfaz con el repositorio de alquileres
    /// </summary>
    private readonly IAlquilerRepository _alquilerRepository;
    
    /// <summary>
    /// Interfaz de Unit of Work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;
    
    /// <summary>
    /// Interfaz con la factory de alquiler
    /// </summary>
    private readonly IAlquilerFactory _alquilerFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="vehiculoRepository">Interfaz del repositorio de vehículo</param>
    /// <param name="alquilerRepository">Interfaz del repositorio de alquiler</param>
    /// <param name="mediator">Mediator, para publicar los eventos</param>
    /// <param name="unitOfWork">Interfaz de Unit of Work</param>
    /// <param name="alquilerFactory">Interfaz con la factory de alquiler</param>
    public AlquilarVehiculoCommandHandler(IVehiculoRepository vehiculoRepository,
        IAlquilerRepository alquilerRepository, IMediator mediator, IUnitOfWork unitOfWork, IAlquilerFactory alquilerFactory)
    {
        _vehiculoRepository = vehiculoRepository;
        _alquilerRepository = alquilerRepository;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _alquilerFactory = alquilerFactory;
    }
    
    /// <summary>
    /// Función que manejará el alquilar un vehículo
    /// </summary>
    /// <param name="request">AlquilarVehiculoCommand con la petición</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>True en caso de que el proceso haya ido bien. False en caso de error</returns>
    /// <exception cref="VehiculoNoEncontradoException">En caso de no encontrar el vehículo</exception>
    public async Task<Guid> Handle(AlquilarVehiculoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Inicializamos la transacción
            await _unitOfWork.BeginTransactionAsync();
            
            // Buscamos el vehículo a alquilar
            var vehiculo = await _vehiculoRepository.ObtenerPorIdAsync(request.IdVehiculo).ConfigureAwait(false);
            if (vehiculo is null)
                throw new VehiculoNoEncontradoException(request.IdVehiculo);
        
            // Alquilamos el vehículo para ese cliente
            vehiculo.Alquilar(request.IdCliente);
        
            // Guardar cambios en el repositorio del vehículo
            await _vehiculoRepository.ActualizarAsync(vehiculo);
        
            // Creamos el alquiler con la factory
            var alquiler = await _alquilerFactory.CrearAlquiler(request.IdCliente, request.IdVehiculo);
            await _alquilerRepository.AgregarAsync(alquiler).ConfigureAwait(false);

            // Commiteamos la transacción
            await _unitOfWork.CommitAsync(cancellationToken);
            
            // Publicar evento de dominio
            foreach (var evento in vehiculo.DomainEvents)
            {
                // Lanzamos el evento de vehículo alquilado
                if (evento is VehiculoAlquiladoEvent vehiculoAlquilado)
                {
                    await _mediator.Publish(new VehiculoAlquiladoNotification(vehiculoAlquilado), cancellationToken);   
                }
                
                // Lanzamos el evento de creación de alquiler
                if (evento is AlquilerCreadoEvent alquilerCreado)
                {
                    await _mediator.Publish(new AlquilerCreadoNotification(alquilerCreado), cancellationToken);
                }
            }
            vehiculo.ClearDomainEvents();

            return alquiler.Id;
        }
        catch (Exception ex)
        {
            // Deshacemos los cambios
            await _unitOfWork.RollbackAsync();
            
            Console.WriteLine($"Se ha producido un error al realizar un alquiler: {ex.Message}");
            throw;
        }
    }
}
