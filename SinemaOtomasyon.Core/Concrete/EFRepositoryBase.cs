using SinemaOtomasyon.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SinemaOtomasyon.Core.Concrete
{
    public class EFRepositoryBase<T, TContext> : IRepository<T>, IDisposable
        where T : class, new()
        where TContext : DbContext
    {

        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;


        public EFRepositoryBase(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
            //_dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            //_dbContext.SaveChanges();
        }

        public void Dispose()
        {
            //database bağlantısını kesip kaynakların ram e geri teslimini sağlar.
            _dbContext.Dispose();
            //Garbage Collector bu sınıfı ramden kaldırır.
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_disposed == false)
                {
                    Dispose();
                    _disposed = true;
                }
            }
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet.AsEnumerable();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            //_dbContext.SaveChanges();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsEnumerable<T>();
        }

        public IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsQueryable<T>();
        }
    }
}
