using SinemaOtomasyon.BLL.DTOs;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.BLL.Services.Validations;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Concrete
{
    public class FilmService : IFilmService
    {
        protected IFilmRepository _repo;

        public FilmService(IFilmRepository repo)
        {
            _repo = repo;
        }
      
    }
}
