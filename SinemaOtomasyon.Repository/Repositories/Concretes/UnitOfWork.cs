using SinemaOtomasyon.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.Core.Abstract;
using System.Data.Entity;
using SinemaOtomasyon.Core.Concrete;

namespace SinemaOtomasyon.Repository.Repositories.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {

        protected DbContext _context;
        protected bool _disposed = false;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }


        public int Commit()
        {
            int resultSet = 0;

            using (_context.Database.BeginTransaction())
            {
                try
                {
                    resultSet = _context.SaveChanges();
                    _context.Database.CurrentTransaction.Commit();
                }
                catch (Exception)
                {
                    _context.Database.CurrentTransaction.Rollback();
                    resultSet = 0;
                }
            }
            return resultSet;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                if (disposing)
                {
                    Dispose();
                    _disposed = true;
                    _context = null;
                }
            }
        }

        public IRepository<T> GetRepo<T>() where T : class, new()
        {
            return new EFRepositoryBase<T, DbContext>(_context);
        }
    }
}
