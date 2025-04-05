using MediatR;
using RentingAPI.Application.Notifications;

namespace RentingAPI.Application.EventHandlers;

public class VehiculoDevueltoEventHandler : INotificationHandler<VehiculoDevueltoNotification>
{
    public async Task Handle(VehiculoDevueltoNotification notification, CancellationToken cancellationToken)
    {
        // Mostramos por consola que se ha realizado un alquiler
        Console.WriteLine($"{notification.Fecha}: Se ha devuelto el vehículo {notification.IdVehiculo}.");
        
        await Task.CompletedTask;
    }
}