using MassTransit.SingUp.Application.IntegrationEvents.Interfaces;
using MassTransit.SingUp.Application.IntegrationEvents.Models;
using MassTransit.SingUp.Application.Models;

namespace MassTransit.SingUp.Application.IntegrationEvents.Events
{
    public class UserCreatedEventHandling : IUserCreatedEventHandling
    {
        private readonly IBus bus;
        public UserCreatedEventHandling(IBus bus)
        {
            this.bus = bus;
        }

        public async Task Publish(UserModel model) =>
            await bus.Publish<IUserCreatedEvent>(new 
            {
                TransactId = Guid.NewGuid(),
                Payload = model,
            });

        public async Task Send(UserModel model) =>
            await bus.Send<IUserCreatedEvent>(new 
            {
                TransactId = Guid.NewGuid(),
                Payload = model,
            });
    }
}
