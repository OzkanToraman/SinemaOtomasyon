using SinemaOtomasyon.BLL.DTOs;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.BLL.Services.Validations;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
using SinemaOtomasyon.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Concrete
{
    public class FilmService : IFilmService
    {
        protected IFilmRepository _filmRepo;
        protected IUnitOfWork _uow;

        public FilmService(IFilmRepository filmRepo,IUnitOfWork uow)
        {
            _filmRepo = filmRepo;
            _uow = uow;
        }

        public ResultModel<Film> SaveFilm(Film f)
        {
            FilmValidator validator = new FilmValidator();
            var result = validator.Validate(f);

            if (result.IsValid)
            {
                _uow.GetRepo<Film>().Add(f);
                _uow.Commit();

                return new ResultModel<Film>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Başarıyla kayıt edildi!"
                };
            }
            return new ResultModel<Film>
            {
                Errors = result.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Kayıt işlemi başarısız!"
            };
        }

       
    }
}

