using SinemaOtomasyon.Core.Concrete;
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
    public class BiletSatisRepository : EFRepositoryBase<BiletSatis, SinemaContext>, IBiletSatisRepository
    {
        public BiletSatisRepository(DbContext Context) : base(Context)
        {
        }

        public int SonBiletKayitBul()
        {
            return _dbContext.Set<BiletSatis>().OrderByDescending(x => x.BiletID).Select(x => x.BiletID).FirstOrDefault();
        }
    }
}
