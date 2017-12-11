﻿using SinemaOtomasyon.Core.Concrete;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SinemaOtomasyon.Repository.Repositories.Concretes
{
    public class PersonelRepository : EFRepositoryBase<Personel, SinemaContext>, IPersonelRepository
    {
        public PersonelRepository(DbContext Context) : base(Context)
        {
        }


        public bool Sorgu(string username, string pass)
        {
            return Convert.ToBoolean(_dbSet.Where(x => x.Email == username && x.Sifre == pass).Count());
        }
    }
}

