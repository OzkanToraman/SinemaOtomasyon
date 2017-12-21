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
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Personel adı boş bırakılamaz!");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Personel soyadı boş bırakılamaz!");
            RuleFor(x => x.SicilNo).NotEmpty().WithMessage("Sicil No boş bırakılamaz!");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Tel No boş bırakılamaz!");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres boş bırakılamaz!");
            ////RuleFor(x => x.CalismaHali).NotEmpty().WithMessage("Çalışma hali boş bırakılamaz!");
            ////RuleFor(x => x.UnvanID).NotEmpty().WithMessage("Ünvan boş bırakılamaz!");
            ////RuleFor(x => x.CinsiyetID).NotEmpty().WithMessage("Cinsiyet boş bırakılamaz!");
            RuleFor(x => x.LoginID).NotEmpty().WithMessage("Kullanıcı ayarlarıdan yeni kullanıcı tanımlayınız!");
        }
    }
}
