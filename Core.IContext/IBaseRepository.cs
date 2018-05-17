using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> exp);
        Task<IEnumerable<T>> WhereOrdered(Expression<Func<T, bool>> exp, 
            Expression<Func<T, object>> keyselector, 
            Expression<Func<T, object>> includedentity);
        void Insert(T entity);
        void InsertRange(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
    }
}
