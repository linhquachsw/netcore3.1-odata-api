using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Netpower.Contracts.Data.Repositoties;
using Netpower.Migrations;

namespace Netpower.Core.Data.Repositoties
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ProductStoreContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ProductStoreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public void Delete(int Id)
        {
            var entity = Get(Id);

            if (entity != null)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                _dbSet.Remove(entity);
            }
        }

        public T Get(int Id)
        {
            var entity = _dbSet.Find(Id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}