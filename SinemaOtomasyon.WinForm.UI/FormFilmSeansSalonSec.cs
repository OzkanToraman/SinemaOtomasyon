using Ninject;
using SinemaOtomasyon.BLL.Services.Abstract;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
using SinemaOtomasyon.Repository.UOW.Abstract;
using SinemaOtomasyon.Repository.UOW.Concrete;
using SinemaOtomasyon.WinForm.UI.Ninject;
using SinemaOtomasyon.WinForm.UI.Salonlar;
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
    public partial class FormFilmSeansSalonSec : Form
    {
        private IFilmRepository _filmRepo;
        private IFilmService _filmService;
        private ISeansRepository _seansRepo;
        private ISalonRepository _salonRepo;
        Film f = new Film();
        int SalonId, SeansId;
        public FormFilmSeansSalonSec()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _filmService = container.Get<IFilmService>();
            _filmRepo = container.Get<IFilmRepository>();
            _seansRepo = container.Get<ISeansRepository>();
            _salonRepo = container.Get<ISalonRepository>();
            InitializeComponent();
        }



        private void FormFilmSeansSalonSec_Load(object sender, EventArgs e)
        {

            DataGridViewDoldur();
            SeansDoldur();
            SalonDoldur();

        }

        private void DataGridViewDoldur()
        {
            dgvFilmler.DataSource = _filmRepo.GetList().Where(x => x.Vizyonda == true).Select(x => new
            {
                Id = x.FilmID,
                Ad = x.FilmAd,
                Oyuncular = x.Oyuncular,
                Yonetmen = x.Yonetmen,
                FilmSure = x.FilmSuresi_dk,
                TurAd = x.FilmTuru.FilmTurAd
            }).ToList();

            dgvFilmler.Columns[0].Visible = false;
        }


        private void SalonDoldur()
        {
            var salonSorgu = _salonRepo.GetList().Select(x => new
            {
                x.SalonID,
                x.SalonAD
            }).ToList();
            cbSalonSec.DataSource = salonSorgu;
            cbSalonSec.DisplayMember = "SalonAD";
            cbSalonSec.ValueMember = "SalonID";
            cbSalonSec.SelectedIndex = 0;
            SalonId = (int)cbSalonSec.SelectedValue;
        }

        private void SeansDoldur()
        {
            var seansSorgu = _seansRepo.GetList().Select(x => new { id = x.SeansID, ad = x.SeansAD }).ToList();
            cbSeansSec.DataSource = seansSorgu;
            cbSeansSec.DisplayMember = "ad";
            cbSeansSec.ValueMember = "id";
            cbSeansSec.SelectedIndex = 0;
            SeansId = (int)cbSeansSec.SelectedValue;
        }

        private void dgvFilmler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("" + (int)dgvFilmler.CurrentRow.Cells[0].Value);
            f = _filmRepo.GetById((int)dgvFilmler.CurrentRow.Cells[0].Value);
            if (f.Afis!=null)
            {
                pbFilmAfis.SizeMode = PictureBoxSizeMode.StretchImage;
                pbFilmAfis.Image = Image.FromFile(f.Afis);
            }


        }

        private void btnBiletSatis_Click(object sender, EventArgs e)
        {
            if (f != null)
            {

                FormSalon4 frm = new FormSalon4(f, SeansId, SalonId, dtpTarih.Value.ToShortDateString());
                frm.ShowDialog();
            }

        }


    }
}
