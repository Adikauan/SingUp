using MassTransit.SingUp.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
