using MassTransit.SingUp.Domain.Aggregates;
using MassTransit.SingUp.Domain.Interfaces;
using MassTransit.SingUp.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace MassTransit.SingUp.Infrastructure.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SingUpDbContext? context;
        public UserRepository(SingUpDbContext context) : base(context)
        {
        }
    }
}
