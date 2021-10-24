using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineBookSubscription.Identity.Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();
        void Remove(T entity);

        Task<T> GetById(int id);

    }
}