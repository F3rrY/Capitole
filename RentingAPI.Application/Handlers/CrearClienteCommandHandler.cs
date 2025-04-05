using MediatR;
using RentingAPI.Application.Commands;
using RentingAPI.Application.Factories;
using RentingAPI.Application.Notifications;
using RentingAPI.Domain.Entities;
using RentingAPI.Domain.Events;
using RentingAPI.Domain.Repositories;
using RentingAPI.Infrastructure.UnitOfWork;

namespace RentingAPI.Application.Handlers;

public class CrearClienteCommandHandler: IRequestHandler<CrearClienteCommand, Guid>
{
    /// <summary>
    /// _mediator
    /// </summary>
    private readonly IMediator _mediator;
    
    /// <summary>
    /// Interfaz con el repositorio
    /// </summary>
    private readonly IClienteRepository _clienteRepository;
    
    /// <summary>
    /// Interfaz de Unit of Work
    /// </summary>
    private readonly IUnitOfWork _unitOfWork;
    
    /// <summary>
    /// Interfaz con la factory del cliente
    /// </summary>
    private readonly IClienteFactory _clienteFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="clienteRepository">Interfaz del repositorio</param>
    /// <param name="mediator">Mediator, para publicar los eventos</param>
    /// <param name="unitOfWork">Interfaz de Unit Of Work</param>
    /// <param name="clienteFactory">Interfaz con la factory del cliente</param>
    public CrearClienteCommandHandler(IClienteRepository clienteRepository, IMediator mediator, IUnitOfWork unitOfWork, IClienteFactory clienteFactory)
    {
        _clienteRepository = clienteRepository;
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _clienteFactory = clienteFactory;
    }

    /// <summary>
    /// Función que manejará la creación del cliente
    /// </summary>
    /// <param name="request">CrearClienteCommand con la petición</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Guid del vehículo creado</returns>
    public async Task<Guid> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
    {
        // Inicializamos la transacción
        await _unitOfWork.BeginTransactionAsync();
        
        try
        {
            // Creamos el cliente con la factory
            var cliente = _clienteFactory.CrearCliente(request.Dni, request.Nombre, request.Apellido);

            // Se agrega al repositorio
            await _clienteRepository.AgregarAsync(cliente);

            // Commiteamos los cambios
            await _unitOfWork.CommitAsync(cancellationToken);
            
            // Publicamos el evento y limpiamos los eventos
            foreach (var evento in cliente.DomainEvents)
            {
                if (evento is ClienteCreadoEvent clienteCreado)
                {
                    await _mediator.Publish(new ClienteCreadoNotification(clienteCreado), cancellationToken);   
                }
            }
            cliente.ClearDomainEvents();
            
            // Devolvemos el Id del cliente creado
            return cliente.Id;
        }
        catch (Exception ex)
        {
            // Desshacemos los cambios
            await _unitOfWork.RollbackAsync();
            
            Console.WriteLine($"Se ha producido un error creando el cliente: {ex.Message}");
            throw;
        }
    }
}
