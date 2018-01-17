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
        int Commit();

        IRepository<T> GetRepo<T>() where T : class, new();

        void Dispose(bool disposing);
    }
}
