using MYARCH.DATA.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.DATA.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MyArchContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MyArchContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
    }
}
