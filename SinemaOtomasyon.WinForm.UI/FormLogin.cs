using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.WinForm.UI.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinemaOtomasyon.WinForm.UI
{
    public partial class FormLogin : Form
    {
        private IPersonelRepository _personelRepo;
        private IPersonelService _personelService;

        public FormLogin()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _personelService = container.Get<IPersonelService>();
            _personelRepo = container.Get<IPersonelRepository>();
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
