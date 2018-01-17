using SinemaOtomasyon.BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.BLL.DTOs;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.BLL.Services.Validations;
using SinemaOtomasyon.Repository.UOW.Abstract;

namespace SinemaOtomasyon.BLL.Services.Concrete
{
    public class LoginService : ILoginService
    {

        //private ILoginRepository _loginRepo;
        private IUnitOfWork _uow;
        public LoginService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultModel<Login> Kontrol(Login p)
        {
            LoginValidator validator = new LoginValidator();
            var result = validator.Validate(p);

            if (result.IsValid)
            {
                return new ResultModel<Login>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Kayıt Başarılı"
                };
            }
            return new ResultModel<Login>
            {
                Errors = result.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Giriş Başarısız"
            };
        }

        public ResultModel<Login> Login(Login p)
        {
            LoginValidator validator = new LoginValidator();
            var result = validator.Validate(p);

            if (result.IsValid)
            {
                _uow.GetRepo<Login>().Add(p);
                _uow.Commit();

                return new ResultModel<Login>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Kayıt Başarılı"
                };
            }
            return new ResultModel<Login>
            {
                Errors = result.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Giriş Başarısız"
            };

        }
    }
}
