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

namespace SinemaOtomasyon.BLL.Services.Concrete
{
    public class LoginService : ILoginService
    {

        ILoginRepository _loginRepo;
        public LoginService(ILoginRepository loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public ResultModel<Login> Login(Login p)
        {
            LoginValidator validator = new LoginValidator();
            var result = validator.Validate(p);

            if (result.IsValid)
            {

                _loginRepo.Add(p);
                _loginRepo.Save();

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
