using MassTransit.SingUp.Application.Models;

namespace MassTransit.SingUp.Application.IntegrationEvents.Interfaces
{
    public interface IUserCreatedEvent
    {
        Guid TransactId { get; set; }
        UserModel? Payload { get; set; }
    }
}
