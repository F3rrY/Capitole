using MediatR;
using RentingAPI.Application.Notifications;

namespace RentingAPI.Application.EventHandlers;

public class ClienteCreadoEventHandler : INotificationHandler<ClienteCreadoNotification>
{
    public async Task Handle(ClienteCreadoNotification notification, CancellationToken cancellationToken)
    {
        // Mostramos por consola que se ha creado un cliente
        Console.WriteLine($"{notification.Fecha}: Se ha creado el cliente {notification.IdCliente}.");
        
        await Task.CompletedTask;
    }
}