using SinemaOtomasyon.BLL.DTOs;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Abstract
{
    public interface IPersonelService
    {
        ResultModel<Personel> Login(Personel p);

        
    }
}
