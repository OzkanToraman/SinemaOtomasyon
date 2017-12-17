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
    public class SeyirciService : ISeyirciService
    {
        private ISeyirciRepository _seyirciRepo;
        public SeyirciService(ISeyirciRepository seyirciRepo)
        {
            _seyirciRepo=seyirciRepo;
        }

        public ResultModel<Seyirci> SeyirciKayıtKontrol(Seyirci seyirci)
        {
            SeyirciValidator validator = new SeyirciValidator();
            var result = validator.Validate(seyirci);

            if (result.IsValid)
            {
                return new ResultModel<Seyirci>
                {
                    Errors = null,
                    IsValid = true,
                    Message = "Giriş Başarılı"
                };
            }
            return new ResultModel<Seyirci>
            {
                Errors = result.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Giriş Başarısız"
            };

        }
    }
}
