using Ninject;
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
    public partial class FormBilet : Form
    {
        private IGiseRepository _giseRepo;

        private Seyirci s;
        string filmAd;
        List<string> koltuklar;
        Gosterim gosterim;
        string biletTuru;


        public FormBilet()
        {
            InitializeComponent();
        }

        public FormBilet(Seyirci s,string filmAd,List<string> koltuklar,Gosterim gosterim,string biletTuru)
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _giseRepo = container.Get<IGiseRepository>();

            InitializeComponent();
            this.s = s;
            this.filmAd = filmAd;
            this.koltuklar = koltuklar;
            this.gosterim = gosterim;
            this.biletTuru = biletTuru;

        }

        private void FormBilet_Load(object sender, EventArgs e)
        {
            #region Salondan gelen bilgiler
            txtAd.Text = s.SeyirciAd;
            txtSoyad.Text = s.SeyirciSoyad;
            txtTelefon.Text = s.SeyirciTelefon;
            txtAdres.Text = s.SeyirciAdres;
            txtSalon.Text = gosterim.Salon.SalonAD;
            txtSeans.Text = gosterim.Seans.SeansAD;
            txtBiletTur.Text = biletTuru;
            txtFilmAd.Text = filmAd;

            int koltukAdet = koltuklar.Count();
            foreach (var koltuk in koltuklar)
            {
                txtKoltuklar.Text += koltuk.ToString() + " ";
            } 
            #endregion
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            /*Seçilen KoltukId'si bulunur ve veritabanından kontrol edilir.Eşleşen Id'lerin DoluMu özelliği doldurulur.*/
            string koltukAd;
            foreach (var item in koltuklar)
            {
                koltukAd = item.ToString();
                int giseId = _giseRepo.GetList().Where(x => x.GosterimID == gosterim.GosterimID && x.Koltuk.KoltukAD == koltukAd).Select(x => x.GiseID).FirstOrDefault();
                _giseRepo.GetById(giseId).DoluMu = true;
                if (_giseRepo.Save()>0)
                {
                    MessageBox.Show("İşlem başarıyla gerçekleşti!");
                }
                
            }
            
            
            /**/
        }
    }
}
