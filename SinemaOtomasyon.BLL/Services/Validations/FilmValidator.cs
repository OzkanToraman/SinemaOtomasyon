using FluentValidation;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Validations
{
    public class FilmValidator : AbstractValidator<Film>
    {

        public FilmValidator()
        {
            RuleFor(x => x.FilmAd).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
        }

        
    }
}
