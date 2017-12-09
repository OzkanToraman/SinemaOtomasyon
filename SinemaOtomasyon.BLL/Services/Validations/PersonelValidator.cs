using FluentValidation;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Validations
{
    public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz!");
            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Şifre boş bırakılamaz!");
        }
    }
}
