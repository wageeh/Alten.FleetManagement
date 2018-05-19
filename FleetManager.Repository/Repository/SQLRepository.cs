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

namespace FleetManager.Repository
{
    public class SQLRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly FleetManagerContext _context;

        private readonly DbSet<T> _entity;

        private readonly IErrorHandler _errorHandler;

        public SQLRepository(FleetManagerContext context, IErrorHandler errorHandler)
        {
            _context = context;
            _entity = context.Set<T>();
            _errorHandler = errorHandler;
        }
        public async Task<List<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }
        public async Task<T> GetById(Guid id)
        {
            return await _entity.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> exp)
        {
            return await _entity.Where(exp).ToListAsync();
        }

        public async void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));

            await _entity.AddAsync(entity);
            _context.SaveChanges();
        }

        public async void InsertRange(List<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(string.Format(_errorHandler.GetMessage(ErrorMessagesEnum.EntityNull), "", "Input data is null"));

            await _entity.AddRangeAsync(entities);
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

            _entity.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<List<T>> WhereOrdered(Expression<Func<T, bool>> exp, Expression<Func<T, object>> keyselector,
           Expression<Func<T, object>> includedentity)
        {
            return await _entity.Where(exp).OrderByDescending(keyselector).Include(includedentity).ToListAsync();
        }
    }
}
