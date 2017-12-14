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
        private IPersonelRepository _personelRepo;
        private IPersonelService _personelService;


        public FormLogin()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _personelService = container.Get<IPersonelService>();
            _personelRepo = container.Get<IPersonelRepository>();
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
            Personel p = new Personel();
            p.Email = txtUser.Text;
            p.Sifre = txtPass.Text;
            var result = _personelService.Login(p);
            if (result.IsValid == false)
            {
                MessageBox.Show(result.Errors.FirstOrDefault().ToString());
            }
            else
            {

                if (_personelRepo.Login(txtUser.Text, txtPass.Text).Count() == 0)

                {
                    MessageBox.Show("Hatalı kullanıcı adı ya da şifre!", "HATA!");
                    txtUser.Focus();
                    txtUser.SelectAll();
                }
                else
                {
                    MessageBox.Show("başarılı");
                }
            }
        }
    }
}

