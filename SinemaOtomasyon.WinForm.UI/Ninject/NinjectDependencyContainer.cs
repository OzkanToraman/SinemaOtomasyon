using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.BLL.Services.Concrete;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.WinForm.UI.Ninject
{
    public class NinjectDependencyContainer
    {
        //public static int SinemaContext { get; private set; }

        public static IKernel RegisterDependency(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<SinemaContext>();
            kernel.Bind<IPersonelService>().To<PersonelService>();
            kernel.Bind<IPersonelRepository>().To<PersonelRepository>();
            kernel.Bind<IFilmService>().To<FilmService>();
            kernel.Bind<IFilmRepository>().To<FilmRepository>();
            kernel.Bind<ISeansRepository>().To<SeansRepository>();
            kernel.Bind<ISalonRepository>().To<SalonRepository>();
            kernel.Bind<IKoltukRepository>().To<KoltukRepository>();

            return kernel;
        }
    }
}
