using SinemaOtomasyon.Core.Abstract;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.Repository.UOW.Abstract
{
    public interface IUnitOfWork : IDisposable

        
    {
        IRepository<Film> FilmRepository();
        IRepository<Gosterim> GosterimRepository();

        int Save();    
    }
}
