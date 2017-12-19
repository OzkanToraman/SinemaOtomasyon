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

namespace SinemaOtomasyon.WinForm.UI.AdminIslemleri
{
    public partial class FormFilmIslemleri : Form
    {
        private IFilmRepository _filmRepo;
        private IFilmTuruRepository _filmTuruRepo;
        private ISalonRepository _salonRepo;
        private IFilmService _filmService;
        

        public FormFilmIslemleri()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _filmRepo = container.Get<IFilmRepository>();
            _filmTuruRepo = container.Get<IFilmTuruRepository>();
            _salonRepo = container.Get<ISalonRepository>();
            _filmService = container.Get<IFilmService>();
            InitializeComponent();
        }

        private void FormFilmIslemleri_Load(object sender, EventArgs e)
        {
            #region Film Türü Doldurma
            cbFilmTur.DataSource = _filmTuruRepo.GetList().Select(x => new { filmid = x.FilmTurID, filmad = x.FilmTurAd }).ToList();
            cbFilmTur.DisplayMember = "filmad";
            cbFilmTur.ValueMember = "filmid";
            #endregion

            #region Salon Türü Doldurma
            //var doluSalonlar = _filmRepo.GetList().Where(x => x.Vizyonda == true).Select(x => x.SalonID);
            cbSalon.DataSource= _salonRepo.GetList().Select(x=>new { x.SalonID, x.SalonAD }).ToList();
            cbSalon.DisplayMember = "SalonAD";
            cbSalon.ValueMember = "SalonID";
            txtSalon.Text = cbSalon.Text;
            #endregion

            #region Başlangıç Değerleri
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            //txtFilmAd.Enabled = false;
            //txtOyuncular.Enabled = false;
            //txtYonetmen.Enabled = false;
            //txtFilmSure.Enabled = false;
            dtpVizyonGiris.MinDate = DateTime.Today.Date;
            dtpVizyonCikis.MinDate = dtpVizyonGiris.Value;
            txtVizyonGiris.Enabled = false;
            txtVizyonCikis.Enabled= false;
            txtVizyonGiris.Text = dtpVizyonGiris.Value.ToShortDateString();
            txtVizyonCikis.Text = dtpVizyonCikis.Value.ToShortDateString();
            dtpVizyonCikis.Enabled = false;
            chkVizyonda.Checked = true;
            #endregion

            DataGridViewDoldur();
            VizyondanCikicakFilmKontrol();
        }

        private void VizyondanCikicakFilmKontrol()
        {
            int kontrol = _filmRepo.GetList().Where(x =>x.Vizyonda==true&&x.VizyonCksTarih < DateTime.Now.Date).Select(x => x.SalonID).FirstOrDefault();
            if (kontrol != 0)
            {
                _salonRepo.GetById(kontrol).DoluMu = false;
            }
        }

        void DataGridViewDoldur()
        {
            dgvFilmler.DataSource = _filmRepo.GetList().Select(x => new
            {
                Id = x.FilmID,
                Ad = x.FilmAd,
                Oyuncular = x.Oyuncular,
                Yonetmen = x.Yonetmen,
                FilmSure = x.FilmSuresi_dk,
                x.VizyonGrsTarih,
                x.VizyonCksTarih,
                TurAd = x.FilmTuru.FilmTurAd,
                Salon = x.Salon.SalonAD
            }).ToList();

            dgvFilmler.Columns[0].Visible = false;
        }
        void Temizle()
        {
            txtFilmAd.Clear();
            txtYonetmen.Clear();
            txtOyuncular.Clear();
            txtFilmSure.Clear();
            txtAfis.Clear();
            txtFilmAd.Focus();
            chkVizyonda.Checked = false;
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            #region Butona basıldığında yapılan alan kontrolü
            dtpVizyonGiris.Enabled = true;
            dtpVizyonCikis.Enabled = true;
            txtVizyonGiris.Text = dtpVizyonGiris.Value.ToShortDateString();
            txtVizyonCikis.Text = dtpVizyonCikis.Value.ToShortDateString();
            #endregion

            #region Yeni Film için Salon Kontrolü 
            //cbSalon.DataSource = _filmRepo.GetList().Where(x=>x.VizyonGrsTarih==DateTime.Now.Date).Select(x => new { salonid = x.Salon.SalonID, salonad = x.Salon.SalonAD }).ToList();
            txtSalon.Clear();
            cbSalon.DataSource = _salonRepo.GetList().Where(x => x.DoluMu == false).Select(x => new { x.SalonID, x.SalonAD }).ToList();
            cbSalon.DisplayMember = "SalonAD";
            cbSalon.ValueMember = "SalonID"; 
            #endregion

            #region Butona Basıldığında Başlangıç Değerleri
            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            txtFilmAd.Enabled = true;
            txtOyuncular.Enabled = true;
            txtYonetmen.Enabled = true;
            txtFilmSure.Enabled = true;
            cbSalon.Enabled = true;
            #endregion
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Film f = new Film();
            f.FilmAd = txtFilmAd.Text;
            f.Yonetmen = txtYonetmen.Text;
            f.Oyuncular = txtOyuncular.Text;
            f.VizyonGrsTarih = dtpVizyonGiris.Value;
            f.VizyonCksTarih = dtpVizyonCikis.Value;
            f.FilmSuresi_dk = txtFilmSure.Text;
            f.FilmTurID = (int)cbFilmTur.SelectedValue;
            f.SalonID = (int)cbSalon.SelectedValue;
            f.Vizyonda = chkVizyonda.Checked;

            var result = _filmService.SaveFilm(f);
            MessageBox.Show(result.IsValid ? result.Message : string.Join("\n", result.Errors));
            DataGridViewDoldur();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Film f = new Film();
            f.FilmAd = txtFilmAd.Text;
            f.Yonetmen = txtYonetmen.Text;
            f.Oyuncular = txtOyuncular.Text;
            f.VizyonGrsTarih = dtpVizyonGiris.Value;
            f.VizyonCksTarih = dtpVizyonCikis.Value;
            f.FilmSuresi_dk = txtFilmSure.Text;
            f.FilmTurID = (int)cbFilmTur.SelectedValue;
            f.SalonID = (int)cbSalon.SelectedValue;
            f.Vizyonda = chkVizyonda.Checked;
            f.Afis = txtAfis.Text;

            var result = _filmService.UpdateFilm(f);
            MessageBox.Show(result.IsValid ? result.Message : string.Join("\n", result.Errors));
            DataGridViewDoldur();
            Temizle();
        }

        private void dgvFilmler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            #region Salon Türü Doldurma
            //var doluSalonlar = _filmRepo.GetList().Where(x => x.Vizyonda == true).Select(x => x.SalonID);
            cbSalon.DataSource = _salonRepo.GetList().Select(x => new { salonid = x.SalonID, salonad = x.SalonAD }).ToList();
            cbSalon.DisplayMember = "salonad";
            cbSalon.ValueMember = "salonid";
            #endregion
            #region Buton Hareketleri
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            #endregion
            #region Alan Kontrolü
            cbSalon.Enabled = false;
            dtpVizyonGiris.Enabled = false;
            dtpVizyonCikis.Enabled = false;
            txtVizyonGiris.Enabled = false;
            txtVizyonCikis.Enabled = false; 
            #endregion

            int id = (int)dgvFilmler.CurrentRow.Cells[0].Value;
            Film f = new Film();
            f = _filmRepo.GetById(id);
            txtFilmAd.Text = f.FilmAd;
            txtYonetmen.Text = f.Yonetmen;
            txtOyuncular.Text = f.Oyuncular;
            txtVizyonGiris.Text = f.VizyonGrsTarih.ToShortDateString();
            txtVizyonCikis.Text = f.VizyonCksTarih.ToShortDateString();
            txtFilmSure.Text = f.FilmSuresi_dk;
            cbFilmTur.SelectedValue = f.FilmTurID;
            cbSalon.SelectedValue = f.SalonID;
            chkVizyonda.Checked = f.Vizyonda;
        }

        private void dtpVizyonGiris_ValueChanged(object sender, EventArgs e)
        {
            txtVizyonGiris.Text = dtpVizyonGiris.Value.ToShortDateString();
            dtpVizyonCikis.Enabled = true;
            dtpVizyonCikis.MinDate = dtpVizyonGiris.Value;
        }

        private void dtpVizyonCikis_ValueChanged(object sender, EventArgs e)
        {
            txtVizyonCikis.Text = dtpVizyonCikis.Value.ToShortDateString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _filmRepo.Delete((int)dgvFilmler.CurrentRow.Cells[0].Value);
            if (_filmRepo.Save() > 0)
            {
                MessageBox.Show("Kayıt başarıyla silindi!");
            }
            DataGridViewDoldur();
        }

        private void txtFilmAdinaGoreAra_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilmAdinaGoreAra.Text))
            {
                dgvFilmler.DataSource = _filmRepo.GetList().Select(x => new
                {
                    Id = x.FilmID,
                    Ad = x.FilmAd,
                    Oyuncular = x.Oyuncular,
                    Yonetmen = x.Yonetmen,
                    FilmSure = x.FilmSuresi_dk,
                    x.VizyonGrsTarih,
                    x.VizyonCksTarih,
                    TurAd = x.FilmTuru.FilmTurAd,
                    Salon=x.Salon.SalonAD
                }).ToList();
            }
            else
            {
                dgvFilmler.DataSource = _filmRepo.GetList().Where(x => x.FilmAd.Contains(txtFilmAdinaGoreAra.Text.Substring(0, 1).ToUpper())).Select(x => new
                {
                    Id = x.FilmID,
                    Ad = x.FilmAd,
                    Oyuncular = x.Oyuncular,
                    Yonetmen = x.Yonetmen,
                    FilmSure = x.FilmSuresi_dk,
                    x.VizyonGrsTarih,
                    x.VizyonCksTarih,
                    TurAd = x.FilmTuru.FilmTurAd,
                    Salon = x.Salon.SalonAD
                }).ToList();
            }
          
        }

        private void chkVizyonKontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVizyonKontrol.Checked)
            {
                dgvFilmler.DataSource = _filmRepo.GetList().Where(x => x.Vizyonda == true).Select(x => new
                {
                    Id = x.FilmID,
                    Ad = x.FilmAd,
                    Oyuncular = x.Oyuncular,
                    Yonetmen = x.Yonetmen,
                    FilmSure = x.FilmSuresi_dk,
                    x.VizyonGrsTarih,
                    x.VizyonCksTarih,
                    TurAd = x.FilmTuru.FilmTurAd,
                    Salon = x.Salon.SalonAD
                }).ToList();
            }
            else
            {
                dgvFilmler.DataSource = _filmRepo.GetList().Select(x => new
                {
                    Id = x.FilmID,
                    Ad = x.FilmAd,
                    Oyuncular = x.Oyuncular,
                    Yonetmen = x.Yonetmen,
                    FilmSure = x.FilmSuresi_dk,
                    x.VizyonGrsTarih,
                    x.VizyonCksTarih,
                    TurAd = x.FilmTuru.FilmTurAd,
                    Salon = x.Salon.SalonAD
                }).ToList();
            }
           
        }

        private void cbSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalon.Text = cbSalon.Text;
        }
    }
}

