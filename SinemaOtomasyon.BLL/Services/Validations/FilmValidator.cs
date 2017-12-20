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
            RuleFor(x => x.FilmAd).NotEmpty().WithMessage("Film adı boş bırakılamaz.");
            RuleFor(x => x.Yonetmen).NotEmpty().WithMessage("Yonetmen boş bırakılamaz.");
            RuleFor(x => x.Oyuncular).NotEmpty().WithMessage("Oyuncular boş bırakılamaz.");
            RuleFor(x => x.FilmSuresi_dk).NotEmpty().WithMessage("Film süresi boş bırakılamaz.");
            RuleFor(x => x.Vizyonda).NotEmpty().WithMessage("Vizyonda mı boş bırakılamaz.");
            RuleFor(x => x.SalonID).NotEmpty().WithMessage("Salon boş bırakılamaz.");
        }

        
    }
}
