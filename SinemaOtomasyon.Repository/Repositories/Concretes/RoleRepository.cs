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
    public class RoleRepository : EFRepositoryBase<Role, SinemaContext>, IRoleRepository
    {
        public RoleRepository(DbContext Context) : base(Context)
        {
        }
    }
}
