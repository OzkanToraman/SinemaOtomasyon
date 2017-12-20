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
using System.Data.Entity.Validation;

namespace SinemaOtomasyon.BLL.Services.Concrete
{
    public class PersonelService : IPersonelService
    {

        private IPersonelRepository _personelRepo;

        public PersonelService(IPersonelRepository personelRepo)
        {
            _personelRepo = personelRepo;
        }

        public ResultModel<Personel> PersonelKayıtKontrol(Personel personel)
        {
            PersonelValidator validator = new PersonelValidator();
            var Result = validator.Validate(personel);

            if (Result.IsValid)
            {
                _personelRepo.Add(personel);
                _personelRepo.Save();
               
                return new ResultModel<Personel>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Başarıyla kayıt edildi."
                };
            }
            else
            {
                return new ResultModel<Personel>
                {
                    Errors = Result.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsValid = false,
                    Message = "Kayıt başarısız ! "
                };
            }
        }
    }
}

