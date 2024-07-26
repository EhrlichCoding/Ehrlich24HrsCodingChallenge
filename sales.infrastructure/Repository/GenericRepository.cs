using sales.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sales.infrastructure.Repository
{
    public class GenericRepository<T> where T : class
    {
        private readonly SalesContext _db = new SalesContext();

        public async Task<T> Add(T entity)
        {
            var item = _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> items)
        {
            var item = _db.Set<T>().AddRange(items);
            await _db.SaveChangesAsync();
            return item;

        }
        public async Task<T> Edit(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<T> FindById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<double> Count()
        {
            return await _db.Set<T>().CountAsync();
        }
    }
}
