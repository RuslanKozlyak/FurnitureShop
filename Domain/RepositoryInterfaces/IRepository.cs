using Domain.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.RepositoryInterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);
        T Get(int id, params Expression<Func<T, object>>[] includes);
        void Insert(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
