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
            kernel.Bind<IPersonelRepository>().To<PersonelRepository>();
            kernel.Bind<IPersonelService>().To<PersonelService>();
            kernel.Bind<IFilmService>().To<FilmService>();
            kernel.Bind<IFilmRepository>().To<FilmRepository>();
            kernel.Bind<ISeansRepository>().To<SeansRepository>();
            kernel.Bind<ISalonRepository>().To<SalonRepository>();
            kernel.Bind<IKoltukRepository>().To<KoltukRepository>();
            kernel.Bind<IGosterimRepository>().To<GosterimRepository>();
            kernel.Bind<ILoginRepository>().To<LoginRepository>();
            kernel.Bind<IGiseRepository>().To<GiseRepository>();
            kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<ISeyirciService>().To<SeyirciService>();
            kernel.Bind<ISeyirciRepository>().To<SeyirciRepository>();
            kernel.Bind<IFaturaRepository>().To<FaturaRepository>();
            kernel.Bind<IBiletSatisRepository>().To<BiletSatisRepository>();
            kernel.Bind<IBiletTuruRepository>().To<BiletTuruRepository>();
            kernel.Bind<IFilmTuruRepository>().To<FilmTuruRepository>();
            kernel.Bind<IUnvanRepository>().To<UnvanRepository>();
            kernel.Bind<ICinsiyetRepository>().To<CinsiyetRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            return kernel;
        }
    }
}
