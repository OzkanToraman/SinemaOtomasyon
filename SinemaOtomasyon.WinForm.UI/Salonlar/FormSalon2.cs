using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SinemaOtomasyon.Repository.Repositories.Concretes;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.UOW.Abstract;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.WinForm.UI.Ninject;
using Ninject;

namespace SinemaOtomasyon.WinForm.UI
{
    public partial class FormSalon2 : Form
    {

        private IKoltukRepository _koltukRepo;
        private IGiseRepository _giseRepo;
        private IGosterimRepository _gosterimRepo;
        private IUnitOfWork _gosterimUOW, _koltukUOW;



        private Film f;
        int SeansId, SalonId, GosterimId;
        string SagTus;
        List<string> butonlar = new List<string>();


        public FormSalon2()
        {           
            InitializeComponent();
        }

        public FormSalon2(Film f, int SeansId, int SalonId)
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _koltukRepo = container.Get<IKoltukRepository>();
            _koltukUOW = container.Get<IUnitOfWork>();
            _gosterimRepo = container.Get<IGosterimRepository>();
            _gosterimUOW = container.Get<IUnitOfWork>();
            _giseRepo = container.Get<IGiseRepository>();

            this.f = f;
            this.SeansId = SeansId;
            this.SalonId = SalonId;
            InitializeComponent();
        }


        private void FormSalon2_Load(object sender, EventArgs e)
        {
            Temizle();

            butonlar.Clear();
            lbKoltuklar.DataSource = butonlar.ToList();

            GosterimId = _gosterimRepo.GetList().Where(x => x.SalonID == SalonId && x.SeansID == SeansId).Select(x => x.GosterimID).FirstOrDefault();
            KoltukKontrol();
            KoltukSayisiHesapla();

            Gosterim gosterimBilgi = new Gosterim();
            gosterimBilgi = _gosterimRepo.GetById(GosterimId);
            txtInformation.Text = f.FilmAd + " / " + gosterimBilgi.Salon.SalonAD + " / " + "Seans: " + gosterimBilgi.Seans.SeansAD + " / ";

            lblTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button49_Click(object sender, EventArgs e)
        {
            
            
        }

        private void KoltukKontrol()
        {
            IEnumerable<int> koltuklar = new List<int>();
            koltuklar = _giseRepo.GetList().Where(x => x.GosterimID == GosterimId && x.DoluMu == true).Select(x => x.KoltukID);
            if (koltuklar.Count() != 0)
            {
                foreach (var item in koltuklar)
                {
                    string koltukAd = _koltukRepo.GetById(item).KoltukAD;
                    Button koltuk = new Button();
                    koltuk = (Button)Controls[koltukAd];
                    koltuk.BackColor = Color.Red;

                }
            }

        }

        private void KoltukSayisiHesapla()
        {
            int Count = 0;
            foreach (Control c in this.Controls)
            {
                if (c.BackColor == Color.Gray)
                {
                    Count++;
                }
            }

            lblToplamKoltuk.Text = Count.ToString();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBiletKes_Click(object sender, EventArgs e)
        {
            if (lbKoltuklar.Items.Count != 0)
            {
                if (string.IsNullOrEmpty(txtAd.Text) && string.IsNullOrEmpty(txtSoyad.Text))
                {
                    MessageBox.Show(" Gerekli alanları doldurmalısınız ! ");
                    txtAd.Focus();
                }
                else
                {
                    //for (int i = 0; i < lbKoltuklar.Items.Count; i++)
                    //{
                    //    /*Koltuk Rengi Değiştirme*/
                    //    Button koltuk = new Button();
                    //    koltuk = (Button)Controls[lbKoltuklar.Items[i].ToString()];
                    //    koltuk.BackColor = Color.Red;
                    //    koltuk.FlatAppearance.MouseOverBackColor = Color.Red;
                    //    /**/

                    //    /*Seçilen KoltukId'si bulunur ve veritabanından kontrol edilir.Eşleşen Id'lerin DoluMu özelliği doldurulur.*/
                    //    string koltukAd = lbKoltuklar.Items[i].ToString();
                    //    giseId = _giseRepo.GetList().Where(x => x.GosterimID == GosterimId && x.Koltuk.KoltukAD == koltukAd).Select(x => x.GiseID).FirstOrDefault();
                    //    //_giseRepo.GetById(giseId).DoluMu = true;
                    //    /**/
                    //}

                    KoltukSayisiHesapla();

                    #region Seyirci Bilgileri

                    /*Seyirci bilgileri toplanır*/
                    Seyirci seyirci = new Seyirci();
                    seyirci.SeyirciAd = txtAd.Text;
                    seyirci.SeyirciSoyad = txtSoyad.Text;
                    seyirci.SeyirciTelefon = txtTelefon.Text;
                    seyirci.SeyirciAdres = txtAdres.Text;
                    /**/
                    #endregion

                    #region Gösterim Bilgileri
                    /*Gosterim Id'sine bağlı Salon ve Seans bilgisi içerir*/
                    Gosterim gosterim = new Gosterim();
                    gosterim = _gosterimRepo.GetById(GosterimId);
                    /**/
                    #endregion

                    #region Bilet Tür Bilgisi
                    /*Radiobutton seçim*/

                    int biletTur;
                    if (rbOgrenci.Checked)
                    {
                        biletTur = 2;
                    }
                    else if (rbTam.Checked)
                    {
                        biletTur = 1;
                    }
                    else
                    {
                        biletTur = 4;
                    }

                    /**/
                    #endregion


                    FormBilet frm = new FormBilet(seyirci, f.FilmAd, butonlar, gosterim, biletTur);
                    frm.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Önce koltuk seçiniz !");
            }

        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
        }

        private void A5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                SagTus = btn.Name;
            }
        }

        private void iptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int giseId = _giseRepo.GetList().Where(x => x.GosterimID == GosterimId && x.Koltuk.KoltukAD == SagTus).Select(x => x.GiseID).FirstOrDefault();
            _giseRepo.GetById(giseId).DoluMu = false;

            if (_giseRepo.Save() > 0)
            {
                MessageBox.Show("iptal edildi");
                Button koltuk = new Button();
                koltuk = (Button)Controls[SagTus.ToString()];
                koltuk.BackColor = Color.Gray;
            }
            else
            {
                MessageBox.Show("başarısız");
            }
        }

        private void A5_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (btn.BackColor == Color.Gray)
            {

                btn.BackColor = Color.Green;
                butonlar.Add(btn.Name);
            }
            else if (btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.Gray;
                butonlar.Remove(btn.Name);
            }

            lbKoltuklar.DataSource = butonlar.ToList();


        }
    }
}
