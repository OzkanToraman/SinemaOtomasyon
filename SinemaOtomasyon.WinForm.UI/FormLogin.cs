using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.UOW.Abstract;
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

        public static string Username;
        protected IUnitOfWork _uow;
        private ILoginService _loginService;
        

        public FormLogin()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _loginService = container.Get<ILoginService>();
            _uow = container.Get<IUnitOfWork>();
            InitializeComponent();
        }


        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.SelectAll();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            txtUser.SelectAll();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Login p = new Login();
            p.Username = txtUser.Text;
            p.Password = txtPass.Text;
            var result = _loginService.Kontrol(p);

            if (result.IsValid == false)
            {
                MessageBox.Show(result.Errors.FirstOrDefault().ToString());
            }
            else
            {
                Login login = new Login();
                login = _uow.GetRepo<Login>()
                    .Where(x => x.Username == txtUser.Text && x.Password == txtPass.Text)
                    .FirstOrDefault();
                if (login == null)
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre!", "HATA");
                    txtUser.Focus();
                    txtUser.SelectAll();
                }
                else
                {
                    string Role = login.Role.RoleAD;
                    Username = login.Username;
                    FormParent frm = new FormParent();
                    this.Hide();
                    frm.Show();
                }

            }
        }
    }
}


