using SinemaOtomasyon.Core.Concrete;
using SinemaOtomasyon.DAL.SinemaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SinemaOtomasyon.Repository.Repositories.Abstracts;

namespace SinemaOtomasyon.Repository.Repositories.Concretes
{
    public class GosterimRepository : EFRepositoryBase<Gosterim, SinemaContext>, IGosterimRepository
    {
        public GosterimRepository(DbContext Context) : base(Context)
        {
        }
    }

    public class GosterimModel
    {
        public int Id { get; set; }
        public List<string> koltukList { get; set; }      
    }
}
