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
        int filmId;
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
            //SeansDoldur();
            SeansSaatKontrol();

        }

        private void SeansSaatKontrol()
        {
            cbSeansSec.DataSource = _seansRepo.GetList().Where(x => x.SeansAD >= DateTime.Now.TimeOfDay).Select(x => new { id = x.SeansID, ad = x.SeansAD }).ToList();
            cbSeansSec.DisplayMember = "ad";
            cbSeansSec.ValueMember = "id";
            if (cbSeansSec.Items.Count != 0)
            {
                txtSeans.Text = cbSeansSec.Text.Substring(0, 5);
            }

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
            var salonSorgu = _filmRepo.GetList().Where(x => x.FilmID == filmId).Select(x => new
            {
                x.Salon.SalonID,
                x.Salon.SalonAD
            }).ToList();
            cbSalonSec.DataSource = salonSorgu;
            cbSalonSec.DisplayMember = "SalonAD";
            cbSalonSec.ValueMember = "SalonID";

        }

        //private void SeansDoldur()
        //{
        //    var seansSorgu = _seansRepo.GetList().Select(x => new { id = x.SeansID, ad = x.SeansAD }).ToList();
        //    cbSeansSec.DataSource = seansSorgu;
        //    cbSeansSec.DisplayMember = "ad";
        //    cbSeansSec.ValueMember = "id";
        //    txtSeans.Text = cbSeansSec.Text.Substring(0, 5);
        //}

        private void dgvFilmler_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("" + (int)dgvFilmler.CurrentRow.Cells[0].Value);
            f = _filmRepo.GetById((int)dgvFilmler.CurrentRow.Cells[0].Value);
            filmId = f.FilmID;

            if (f.Afis != null)
            {
                pbFilmAfis.SizeMode = PictureBoxSizeMode.StretchImage;
                pbFilmAfis.Image = Image.FromFile(f.Afis);
            }

            SalonDoldur();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSeansSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSeans.Text = cbSeansSec.Text.Substring(0, 5);
        }

        private void btnBiletSatis_Click(object sender, EventArgs e)
        {
            if (cbSalonSec.Items.Count==0 || cbSeansSec.Items.Count==0)
            {
                MessageBox.Show("Lütfen seans ya da salon bilgisi giriniz!");               
            }
            else
            {
                if (f != null)
                {
                    SeansId = (int)cbSeansSec.SelectedValue;
                    SalonId = (int)cbSalonSec.SelectedValue;
                    int id = SalonId;
                    //switch (SalonId)
                    //{
                    //    case 2:
                    //        FormSalon2 frm2 = new FormSalon2(f, SeansId, SalonId);
                    //        frm2.ShowDialog();
                    //        break;
                    //    case 3:
                    //        FormSalon3 frm3 = new FormSalon3(f, SeansId, SalonId);
                    //        frm3.ShowDialog();
                    //        break;
                    //    case 4:
                    //        FormSalon4 frm4 = new FormSalon4(f, SeansId, SalonId);
                    //        frm4.ShowDialog();
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
        }


    }
}
