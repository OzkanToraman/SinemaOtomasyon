using FluentValidation;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Validations
{
    public class LoginValidator:AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz!");
        }
    }
}
