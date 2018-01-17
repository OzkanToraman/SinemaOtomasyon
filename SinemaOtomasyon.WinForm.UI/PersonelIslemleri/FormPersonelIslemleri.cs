using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.BLL.Services.Validations;
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

namespace SinemaOtomasyon.WinForm.UI.PersonelIslemleri
{
    public partial class FormPersonelIslemleri : Form
    {
        
        private IPersonelRepository _personelRepo;
        private IPersonelService _personelService;
        private ILoginRepository _loginRepo;
        private IUnitOfWork _uow;

        public FormPersonelIslemleri()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _personelRepo = container.Get<IPersonelRepository>();
            _personelService = container.Get<IPersonelService>();
            _loginRepo = container.Get<ILoginRepository>();
            _uow = container.Get<IUnitOfWork>();

            InitializeComponent();
        }

        private void FormPersonelIslemleri_Load(object sender, EventArgs e)
        {
            btnYeni.Enabled = true;
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            #region UnvanDoldurma
            cbUnvan.DataSource = _uow.GetRepo<Unvan>().GetList().Select(x => new { id = x.UnvanID, ad = x.UnvanAD }).ToList();
            cbUnvan.DisplayMember = "ad";
            cbUnvan.ValueMember = "id";
            #endregion
            #region CinsiyetDoldurma
            cbCinsiyet.DataSource = _uow.GetRepo<Cinsiyet>().GetList().Select(x => new { ad = x.CinsiyetAD, id = x.CinsiyetID }).ToList();
            cbCinsiyet.DisplayMember = "ad";
            cbCinsiyet.ValueMember = "id";
            #endregion
            DGVDoldur();
        }

        private void DGVDoldur()
        {
            dgvPersonel.DataSource = _uow.GetRepo<Personel>().GetList().Select(x => new
            {
                x.PersonelID,
                x.Ad,
                x.Soyad,
                x.SicilNo,
                x.Unvan.UnvanAD,
                x.Login.Username
            }).ToList();

            dgvPersonel.Columns[0].Visible = false;
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            #region ButonHareketleri
            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnYeni.Enabled = false;
            #endregion
        }

        private void dgvPersonel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Buton Alanları
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnYeni.Enabled = true;
            #endregion

            Personel p = new Personel();
            p = _uow.GetRepo<Personel>().GetById((int)dgvPersonel.CurrentRow.Cells[0].Value);
            txtAd.Text = p.Ad;
            txtSoyad.Text = p.Soyad;
            txtKimlikNo.Text = p.SicilNo;
            txtTelefon.Text = p.Telefon;
            txtAdres.Text = p.Adres;
            chkCalisma.Checked = p.CalismaHali;
            cbUnvan.SelectedValue = p.UnvanID;
            cbCinsiyet.SelectedValue = p.CinsiyetID;
            txtUsername.Text = p.Login.Username;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Ad = txtAd.Text;
            personel.Soyad = txtSoyad.Text;
            personel.SicilNo = txtKimlikNo.Text;
            personel.Telefon = txtTelefon.Text;
            personel.Adres = txtAdres.Text;
            personel.CalismaHali = chkCalisma.Checked;
            personel.UnvanID = (int)cbUnvan.SelectedValue;
            personel.CinsiyetID = (int)cbCinsiyet.SelectedValue;
            personel.LoginID = FormKullaniciTanimla.log;

            var result = _personelService.PersonelKayıtKontrol(personel);
                                 
            if (result.IsValid)
            {
                DGVDoldur();
                Temizle();
                btnYeni.Enabled = true;
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtKimlikNo.Clear();
            chkCalisma.Checked = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel = _uow.GetRepo<Personel>().GetById((int)dgvPersonel.CurrentRow.Cells[0].Value);
            personel.Ad = txtAd.Text;
            personel.Soyad = txtSoyad.Text;
            personel.SicilNo = txtKimlikNo.Text;
            personel.Telefon = txtTelefon.Text;
            personel.Adres = txtAdres.Text;
            personel.CalismaHali = chkCalisma.Checked;
            personel.UnvanID = (int)cbUnvan.SelectedValue;
            personel.CinsiyetID = (int)cbCinsiyet.SelectedValue;
            personel.LoginID = FormKullaniciTanimla.log;

            if (_uow.Commit()>0)
            {
                MessageBox.Show("Başarıyla güncellendi.");
                DGVDoldur();
                Temizle();
                btnYeni.Enabled = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _personelRepo.Delete((int)dgvPersonel.CurrentRow.Cells[0].Value);
            if (_uow.Commit() > 0)
            {
                MessageBox.Show("Silindi!");
                DGVDoldur();
                Temizle();
                btnYeni.Enabled = true;
            }

        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            FormKullaniciTanimla frmUser = new FormKullaniciTanimla();
            frmUser.ShowDialog();            
            txtUsername.Text = FormKullaniciTanimla.ad;
            DGVDoldur();
        }
    }
}
