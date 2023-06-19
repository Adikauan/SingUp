using MassTransit.SingUp.Application.IntegrationEvents.Models;
using MassTransit.SingUp.Application.Models;

namespace MassTransit.SingUp.Application.IntegrationEvents.Events
{
    public interface IUserCreatedEventHandling
    {
        Task Publish(UserModel model);
        Task Send(UserModel model);
    }
}
