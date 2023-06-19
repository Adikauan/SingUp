using MediatR;
using MassTransit.SingUp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Application.Queries.GetById
{
    public class GetByIdQuery : IRequest<UserModel>
    {
        public Guid Id { get; set; }

        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
