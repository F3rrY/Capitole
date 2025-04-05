using MediatR;
using RentingAPI.Application.Notifications;

namespace RentingAPI.Application.EventHandlers;

public class AlquilerDevueltoEventHandler : INotificationHandler<AlquilerDevueltoNotification>
{
    public Task Handle(AlquilerDevueltoNotification notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}