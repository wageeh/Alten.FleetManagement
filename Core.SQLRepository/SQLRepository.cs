using Core.BaseRepository;
using Core.Entites;
using Core.ErrorHandler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLRepository
{
    public class SQLRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly BaseContext _context;

        private readonly DbSet<T> _entities;

        private readonly IErrorHandler _errorHandler;

        public SQLRepository(BaseContext context, IErrorHandler errorHandler)
        {
            _context = context;
            _entities = context.Set<T>();
            _errorHandler = errorHandler;
        }
        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetById(Guid id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> exp)
        {
            return await _entities.Where(exp).ToListAsync();
        }

        public async Task<IEnumerable<T>> WhereOrdered(Expression<Func<T, bool>> exp, Expression<Func<T, object>> keyselector)
        {
            return await _entities.Where(exp).OrderByDescending(keyselector).ToListAsync();
        }

        public async void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));

            await _entities.AddAsync(entity);
            _context.SaveChanges();
        }

        public async void InsertRange(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));

            await _entities.AddRangeAsync(entities);
            _context.SaveChanges();
        }

        public async void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));

            var oldEntity = await _context.FindAsync<T>(entity.Id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));

            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
