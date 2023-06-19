using MassTransit.SingUp.Domain.Interfaces;
using MassTransit.SingUp.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Infrastructure.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SingUpDbContext context;
        public IUserRepository? userRepository;

        public UnitOfWork(SingUpDbContext context, IUserRepository? sampleRepository)
        {
            this.context = context;
            this.userRepository = sampleRepository;
        }

        public IUserRepository UserRepository => userRepository ?? (new UserRepository(context));

        public async Task<bool> Commit()
        {
            var result = await context.SaveChangesAsync();

            if (result == 0)
                return false;
            return true;

        }

        public void Rollback()
        {
            context?.Dispose();
        }
    }
}
