using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void Update(T existingEntity, T entity);

    }
}
