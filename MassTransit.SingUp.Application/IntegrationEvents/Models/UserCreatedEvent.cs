using MassTransit.SingUp.Application.IntegrationEvents.Interfaces;
using MassTransit.SingUp.Application.Models;

namespace MassTransit.SingUp.Application.IntegrationEvents.Models
{
    public class UserCreatedEvent : IUserCreatedEvent
    {
        public Guid TransactId { get ; set ; }
        public UserModel? Payload { get ; set ; }
    }
}
