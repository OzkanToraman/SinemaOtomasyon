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
            btnGuncelle.Enabled = false;
            btnEkle.Enabled = false;
            btnSil.Enabled = false;
            #region Rol Doldur
            cbRole.DataSource = _roleRepo.GetList();
            cbRole.DisplayMember = "RoleAD";
            cbRole.ValueMember = "RoleID";
            #endregion
            DGVDoldur();
        }

        private void DGVDoldur()
        {
            dgvKullanicilar.DataSource = _loginRepo.GetList().Select(x => new
            {
                x.LoginID,
                x.Username,
                x.Password,
                x.Role.RoleAD
            }).ToList();

            dgvKullanicilar.Columns[0].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
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

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnEkle.Enabled = true;
            Temizle();
        }

        private void dgvKullanicilar_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnYeni.Enabled = true;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnEkle.Enabled = false;
            Login l = new Login();
            l = _loginRepo.GetById((int)dgvKullanicilar.CurrentRow.Cells[0].Value);
            txtAd.Text = l.Username;
            txtSifre.Text = l.Password;
            cbRole.SelectedValue = l.RoleID;
            lblLoginID.Text = l.LoginID.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            Login l = new Login();
            l = _loginRepo.GetById(Convert.ToInt32(lblLoginID.Text));
            l.Username = txtAd.Text;
            l.Password = txtSifre.Text;
            l.RoleID =(int)cbRole.SelectedValue;
            if (_loginRepo.Save()>0)
            {
                MessageBox.Show("Başarıyla güncellendi!");
                DGVDoldur();
                Temizle();
                btnYeni.Enabled = true;
            }

            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            _loginRepo.Delete(Convert.ToInt32(lblLoginID.Text));
            if (_loginRepo.Save() > 0)
            {
                MessageBox.Show("Başarıyla silindi!");
                DGVDoldur();
                Temizle();
                btnYeni.Enabled = true;
            }
        }

        void Temizle()
        {
            txtAd.Clear();
            txtSifre.Clear();

        }


    }
}
