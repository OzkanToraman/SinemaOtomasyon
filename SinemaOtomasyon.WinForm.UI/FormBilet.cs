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
        private IFaturaRepository _faturaRepo;
        private IBiletTuruRepository _biletturRepo;
        private IBiletSatisRepository _biletSatisRepo;
        private ISeyirciRepository _seyirciRepo;
        private IPersonelRepository _personelRepo;

        private Seyirci s;
        string filmAd;
        ICollection<string> koltuklar;
        Gosterim gosterim;
        int biletTur;
        string kullanici;
        int sonSeyirciKaydiId, giseId, sonBiletKaydiId;
        int OdemeSekliID;

        public FormBilet()
        {
            InitializeComponent();
        }

        public FormBilet(Seyirci s, string filmAd, ICollection<string> koltuklar, Gosterim gosterim, int biletTur)
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _giseRepo = container.Get<IGiseRepository>();
            _faturaRepo = container.Get<IFaturaRepository>();
            _biletturRepo = container.Get<IBiletTuruRepository>();
            _biletSatisRepo = container.Get<IBiletSatisRepository>();
            _seyirciRepo = container.Get<ISeyirciRepository>();
            _personelRepo = container.Get<IPersonelRepository>();

            InitializeComponent();
            this.s = s;
            this.filmAd = filmAd;
            this.koltuklar = koltuklar;
            this.gosterim = gosterim;
            this.biletTur = biletTur;

        }

        private void FormBilet_Load(object sender, EventArgs e)
        {
            #region Kullanıcı Bilgileri
            FormLogin formLogin = new FormLogin();
            kullanici = FormLogin.Username;
            #endregion
            #region Salondan gelen bilgiler
            txtAd.Text = s.SeyirciAd;
            txtSoyad.Text = s.SeyirciSoyad;
            txtTelefon.Text = s.SeyirciTelefon;
            txtAdres.Text = s.SeyirciAdres;
            txtSalon.Text = gosterim.Salon.SalonAD;
            txtSeans.Text = gosterim.Seans.SeansAD.ToString();
            txtBiletTur.Text = _biletturRepo.GetById(biletTur).BiletTuru1;
            txtFilmAd.Text = filmAd;
            txtTarih.Text = DateTime.Now.ToShortDateString();


            int koltukAdet = koltuklar.Count();
            foreach (var koltuk in koltuklar)
            {
                txtKoltuklar.Text += koltuk.ToString() + " ";
            }
            #endregion
            #region Bilet Fiyat Hesabı
            if (txtBiletTur.Text == "Öğrenci")
            {
                txtToplam.Text = (koltukAdet * 6).ToString();
            }
            else if (txtBiletTur.Text == "Tam")
            {
                txtToplam.Text = (koltukAdet * 10).ToString();
            }
            else
            {
                txtToplam.Text = (koltukAdet * 7).ToString();
            }
            #endregion
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            DialogResult onayla = new DialogResult();
            onayla = MessageBox.Show("Onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (onayla == DialogResult.Yes)
            {
                /*Seçilen KoltukId'si bulunur ve veritabanından kontrol edilir.Eşleşen Id'lerin DoluMu özelliği doldurulur.*/
                string koltukAd;
                foreach (var item in koltuklar)
                {
                    koltukAd = item.ToString();
                    giseId = _giseRepo.Where(x => x.GosterimID == gosterim.GosterimID && x.Koltuk.KoltukAD == koltukAd).Select(x => x.GiseID).FirstOrDefault();
                    Gise g = new Gise();
                    g = _giseRepo.GetById(giseId);
                    g.DoluMu = true;
                    g.Tarih = DateTime.Now.Date;                 
                }
                if (_giseRepo.Save() > 0)
                {
                    MessageBox.Show("İşlem başarıyla gerçekleşti!");
                }
                /**/

                #region Ödeme Şekli
                /*OdemeSekliyle alakalı*/
                if (rbNakit.Checked)
                {
                    OdemeSekliID = 1;
                }
                else
                {
                    OdemeSekliID = 2;
                }
                /**/
                #endregion

                SeyirciDatabaseEkle();
                BiletDatabaseEkle();
                FaturaDatabaseEkle();

                this.Close();
            } 
        }


        //bool IslemTamam(bool seyirci, bool bilet, bool fatura)
        //{
        //    if (seyirci & bilet & fatura)
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        void SeyirciDatabaseEkle()
        {
            Seyirci seyirci = new Seyirci();
            seyirci.SeyirciAd = txtAd.Text;
            seyirci.SeyirciSoyad = txtSoyad.Text;
            seyirci.SeyirciTelefon = txtTelefon.Text;
            seyirci.SeyirciAdres = txtAdres.Text;

            _seyirciRepo.Add(seyirci);
            _seyirciRepo.Save();
            sonSeyirciKaydiId = _seyirciRepo.SonKayit();

        }
        void BiletDatabaseEkle()
        {
            BiletSatis satis = new BiletSatis();
            satis.BiletFiyat = Convert.ToDecimal(txtToplam.Text);
            satis.Satıldı = true;
            satis.SeyirciID = sonSeyirciKaydiId;
            satis.GiseID = giseId;
            satis.BiletTurID = biletTur;

            _biletSatisRepo.Add(satis);
            if (_biletSatisRepo.Save() > 0)
            {
                MessageBox.Show("Bilet satışı başarıyla gerçekleşti!");
                sonBiletKaydiId = _biletSatisRepo.SonBiletKayitBul();
            }

        }
        void FaturaDatabaseEkle()
        {
            Fatura f = new Fatura();
            f.OdemeSekliID = OdemeSekliID;
            f.BiletID = sonBiletKaydiId;
            f.FaturaTarih = DateTime.Now.Date;
            #region PersonelID Bulmak
            Personel p = new Personel();
            p = _personelRepo.GetList().Where(x => x.Login.Username == kullanici).FirstOrDefault();
            f.PersoneID = p.PersonelID;
            #endregion
            _faturaRepo.Add(f);
            _faturaRepo.Save();

        }


        private void FormBilet_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormFilmSeansSalonSec frm = new FormFilmSeansSalonSec();
            frm.Show();
        }
    }
}
