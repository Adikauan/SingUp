using MediatR;
using MassTransit.SingUp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Application.Commands.Create
{
    public class CreateCommand : IRequest<bool>
    {
        public UserModel? Payload { get; set; }
    }
}
