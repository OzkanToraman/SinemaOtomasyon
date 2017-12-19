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
    public class UnvanRepository : EFRepositoryBase<Unvan, SinemaContext>, IUnvanRepository
    {
        public UnvanRepository(DbContext Context) : base(Context)
        {
        }
    }
}
