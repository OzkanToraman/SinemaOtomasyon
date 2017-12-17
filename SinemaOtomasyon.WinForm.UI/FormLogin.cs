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
    public partial class FormLogin : Form
    {
        private ILoginRepository _loginRepo;
        private ILoginService _loginService;


        public FormLogin()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _loginService = container.Get<ILoginService>();
            _loginRepo = container.Get<ILoginRepository>();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login p = new Login();
            p.Username = txtUser.Text;
            p.Password = txtPass.Text;
            var result = _loginService.Login(p);
            if (result.IsValid == false)
            {
                MessageBox.Show(result.Errors.FirstOrDefault().ToString());
            }
            else
            {
                //MessageBox.Show(_loginRepo.Giris(txtUser.Text, txtPass.Text));
                Login login = new Login();
                login = _loginRepo.Giris(txtUser.Text, txtPass.Text);
                if (login == null)
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre!", "HATA");
                    txtUser.Focus();
                    txtUser.SelectAll();
                }
                else
                {
                    MessageBox.Show("Başarılı");
                    string Role = login.Role;
                }
                
            }     
        }
    }
}


