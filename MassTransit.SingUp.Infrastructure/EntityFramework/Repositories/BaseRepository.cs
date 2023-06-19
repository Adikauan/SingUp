using MassTransit.SingUp.Domain.Interfaces;
using MassTransit.SingUp.Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MassTransit.SingUp.Infrastructure.EntityFramework.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SingUpDbContext context;

        public BaseRepository(SingUpDbContext context) => this.context = context;

        public void Add(T entity) => context.Set<T>().Add(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate) => await context.Set<T>().FirstOrDefaultAsync(predicate);

        public void Remove(T entity) => context.Set<T>().Remove(entity);

        public void Update(T existingEntity, T entity)
        {
            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            //context.Set<T>().Update(entity);
        }
    }
}
