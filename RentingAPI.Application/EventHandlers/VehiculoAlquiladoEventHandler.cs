using MediatR;
using RentingAPI.Application.Notifications;

namespace RentingAPI.Application.EventHandlers;

public class VehiculoAlquiladoEventHandler : INotificationHandler<VehiculoAlquiladoNotification>
{
    public async Task Handle(VehiculoAlquiladoNotification notification, CancellationToken cancellationToken)
    {
        // Mostramos por consola que un vehículo ha sido alquilado
        Console.WriteLine($"{notification.Fecha}: Vehículo con Id {notification.IdVehiculo} ha sido alquilado por el cliente con Id {notification.IdCliente}.");
        
        await Task.CompletedTask;
    }
}