using SinemaOtomasyon.Core.Concrete;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SinemaOtomasyon.Repository.Repositories.Concretes
{
    public class FilmRepository : EFRepositoryBase<Film, SinemaContext>, IFilmRepository
    {
        public FilmRepository(DbContext Context) : base(Context)
        {
        }
    }
}
