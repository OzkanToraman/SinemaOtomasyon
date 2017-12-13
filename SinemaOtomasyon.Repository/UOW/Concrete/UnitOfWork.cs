using SinemaOtomasyon.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.Core.Abstract;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Core.Concrete;

namespace SinemaOtomasyon.Repository.UOW.Concrete
{
    public class UnitOfWork : IUnitOfWork

    {
        protected SinemaContext _dbContext;

        public UnitOfWork(SinemaContext context)
        {
            _dbContext = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository<Film> FilmRepository()
        {
            return new EFRepositoryBase<Film, SinemaContext>(_dbContext);
        }

        public IRepository<Gosterim> GosterimRepository()
        {
            return new EFRepositoryBase<Gosterim, SinemaContext>(_dbContext);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

    }
}
