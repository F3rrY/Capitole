using MediatR;
using RentingAPI.Application.Notifications;

namespace RentingAPI.Application.EventHandlers;

public class VehiculoCreadoEventHandler : INotificationHandler<VehiculoCreadoNotification>
{
    public async Task Handle(VehiculoCreadoNotification notification, CancellationToken cancellationToken)
    {
        // Mostramos por consola que se ha creado un vehículo
        Console.WriteLine($"{notification.Fecha}: Se ha creado el vehículo {notification.IdVehiculo}.");
        
        await Task.CompletedTask;
    }
}