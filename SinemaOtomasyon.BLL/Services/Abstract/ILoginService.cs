﻿using SinemaOtomasyon.BLL.DTOs;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.Services.Abstract
{
    public interface ILoginService
    {
        ResultModel<Login> Login(Login p);
        ResultModel<Login> Kontrol(Login p);
    }
}
