using SinemaOtomasyon.Core.Concrete;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace SinemaOtomasyon.Repository.Repositories.Concretes
{
    public class KoltukRepository : EFRepositoryBase<Koltuk, SinemaContext>, IKoltukRepository
    {
        public KoltukRepository(DbContext Context) : base(Context)
        {
        }
    }
}
