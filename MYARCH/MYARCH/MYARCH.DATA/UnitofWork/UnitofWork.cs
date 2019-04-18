using MYARCH.DATA.Context;
using MYARCH.DATA.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.DATA.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly MyArchContext _context;
        private bool disposed = false;
        public UnitofWork(MyArchContext context)
        {
            Database.SetInitializer<MyArchContext>(null);
            if (context == null)
                throw new ArgumentException("context is null");
            _context = context;
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Commit();
        }

        public void Rollback()
        {
            Rollback();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}
