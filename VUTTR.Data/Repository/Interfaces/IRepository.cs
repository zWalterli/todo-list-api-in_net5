using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VUTTR.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes);
        Task<T> GetOne(Expression<Func<T, bool>> predicate, params Expression<Func<T, Object>>[] includes);
        Task<T> Insert(T item);
        Task<ICollection<T>> Insert(ICollection<T> models);
        Task<T> Update(T item);
        Task<ICollection<T>> Update(ICollection<T> models);
        Task<T> Delete(T item);
        Task<ICollection<T>> Delete(ICollection<T> models);
    }
}