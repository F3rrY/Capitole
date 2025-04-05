using MediatR;
using RentingAPI.Application.Notifications;

namespace RentingAPI.Application.EventHandlers;

public class AlquilerCreadoEventHandler : INotificationHandler<AlquilerCreadoNotification>
{
    public async Task Handle(AlquilerCreadoNotification notification, CancellationToken cancellationToken)
    {
        // Mostramos por consola que se ha realizado un alquiler
        Console.WriteLine($"{notification.Fecha}: Se ha terminado el alquiler {notification.IdAlquiler}.");
        
        await Task.CompletedTask;
    }
}