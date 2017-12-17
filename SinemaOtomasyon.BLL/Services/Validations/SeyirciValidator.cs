using FluentValidation;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Validations
{
    public class SeyirciValidator:AbstractValidator<Seyirci>
    {
        public SeyirciValidator()
        {
            RuleFor(x => x.SeyirciAd).NotEmpty().WithMessage("Seyirci adı boş bırakılamaz!");
            RuleFor(x => x.SeyirciSoyad).NotEmpty().WithMessage("Seyirci soyadı boş bırakılamaz!");
            //RuleFor(x => x.SeyirciTelefon).NotEmpty().WithMessage("Seyirci telefonu boş bırakılamaz!");
            //RuleFor(x => x.SeyirciAdres).NotEmpty().WithMessage("Seyirci adresi boş bırakılamaz!");
            //RuleFor(x => x.Üyelik).NotEmpty().WithMessage("Seyirci üyeliği boş bırakılamaz!");
        }
    }
}
