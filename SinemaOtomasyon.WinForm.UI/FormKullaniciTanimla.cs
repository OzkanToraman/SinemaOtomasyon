using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.DAL.SinemaContext;
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
    public partial class FormKullaniciTanimla : Form
    {
        public static int log;
        public static string ad;
        private ILoginRepository _loginRepo;
        private IRoleRepository _roleRepo;
        private ILoginService _loginService;

        public FormKullaniciTanimla()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _loginRepo = container.Get<ILoginRepository>();
            _roleRepo = container.Get<IRoleRepository>();
            _loginService = container.Get<ILoginService>();

            InitializeComponent();
        }

        private void FormKullaniciTanimla_Load(object sender, EventArgs e)
        {
            cbRole.DataSource= _roleRepo.GetList();
            cbRole.DisplayMember = "RoleAD";
            cbRole.ValueMember = "RoleID";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Username = txtAd.Text;
            login.Password = txtSifre.Text;
            login.RoleID = (int)cbRole.SelectedValue;

            var result = _loginService.Login(login);
            if (result.IsValid)
            {
                int loginId = _loginRepo.GetList().OrderByDescending(x => x.LoginID).Select(x => x.LoginID).FirstOrDefault();
                log = loginId;
                ad = txtAd.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
           
           
        }
    }
}
