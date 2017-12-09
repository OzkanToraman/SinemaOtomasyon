using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinemaOtomasyon.BLL.DTOs;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.BLL.Services.Validations;

namespace SinemaOtomasyon.BLL.Services.Concrete
{
    public class PersonelService : IPersonelService
    {
        IPersonelRepository _personelRepo;
        public PersonelService(IPersonelRepository personelRepo)
        {
            _personelRepo = personelRepo;
        }
      
        public ResultModel<Personel> Login(Personel p)
        {
            PersonelValidator validator = new PersonelValidator();
            var result = validator.Validate(p);

            if (result.IsValid)
            {
                _personelRepo.Add(p);

                return new ResultModel<Personel>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Giriş Başarılı"
                };
            }

            return new ResultModel<Personel>
            {
                Errors = result.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Giriş Başarısız"
            };
        }
    }
}
