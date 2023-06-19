using MediatR;
using MassTransit.SingUp.Application.Models;
using MassTransit.SingUp.Domain.Aggregates;

namespace MassTransit.SingUp.Application.Queries.GettAll
{
    public class GetAllQuery : IRequest<IEnumerable<UserModel>>
    {
    }
}
