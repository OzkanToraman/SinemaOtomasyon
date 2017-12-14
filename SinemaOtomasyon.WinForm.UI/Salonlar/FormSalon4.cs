using Ninject;
using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
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

namespace SinemaOtomasyon.WinForm.UI.Salonlar
{
    public partial class FormSalon4 : Form
    {

        private IKoltukRepository _koltukRepo;
        private IGosterimRepository _gosterimRepo;
        private IUnitOfWork _gosterimUOW, _koltukUOW;


        private Film f;
        int SeansId, SalonId;
        string Tarih;
        string SagTus;
        List<string> butonlar = new List<string>();


        public FormSalon4()
        {
            InitializeComponent();
        }

        public FormSalon4(Film f, int SeansId, int SalonId, string Tarih)
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _koltukRepo = container.Get<IKoltukRepository>();
            _koltukUOW = container.Get<IUnitOfWork>();
            _gosterimRepo = container.Get<IGosterimRepository>();
            _gosterimUOW = container.Get<IUnitOfWork>();
            this.f = f;
            this.SeansId = SeansId;
            this.SalonId = SalonId;
            this.Tarih = Tarih;
            InitializeComponent();
        }

        private void FormSalon4_Load(object sender, EventArgs e)
        {

            KoltukKontrol();
            KoltukSayisiHesapla();
            //Gosterim gosterim = new Gosterim();
            //gosterim.FilmID = f.FilmID;
            //gosterim.SalonID = SalonId;
            //gosterim.SeansID = SeansId;
            //_gosterimUOW.GosterimRepository().Add(gosterim);
            //if (_gosterimUOW.Save()>0)
            //{
            //    MessageBox.Show("Kayıt başarılı!");
            //}


            //txtInformation.Text = f.FilmAd + " / " + "Salon: " + SalonId + " / " + "Seans: " + SeansId + " / ";
        }

        private void KoltukKontrol()
        {
            IEnumerable<string> koltuklarDolu = new List<string>();
            koltuklarDolu = _koltukUOW.KoltukRepository().GetList().Where(x => x.DoluMu == true).Select(x => x.KoltukAD);
            if (koltuklarDolu.Count() != 0)
            {

                foreach (var item in koltuklarDolu)
                {
                    Button koltuk = new Button();
                    koltuk = (Button)Controls[item.ToString()];
                    koltuk.BackColor = Color.Red;
                    //koltuk.FlatAppearance.MouseOverBackColor = Color.Red;
                }

            }
            else
            {
                MessageBox.Show("seçili koltuk yok");
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

                List<Koltuk> koltukListe = _koltukRepo.GetList();

                Button koltuk = new Button();
                for (int i = 0; i < lbKoltuklar.Items.Count; i++)
                {
                    /*Koltuk Rengi Değiştirme*/
                    koltuk = (Button)Controls[lbKoltuklar.Items[i].ToString()];
                    koltuk.BackColor = Color.Red;
                    koltuk.FlatAppearance.MouseOverBackColor = Color.Red;
                    /**/

                    /*Seçilen KoltukId'si bulunur ve veritabanından kontrol edilir.Eşleşen Id'lerin DoluMu özelliği doldurulur.*/
                    string koltukAd = lbKoltuklar.Items[i].ToString();
                    int secilenkoltukId = koltukListe.Where(x => x.KoltukAD == koltukAd).Select(x => x.KoltukID).FirstOrDefault();
                    _koltukUOW.KoltukRepository().GetById(secilenkoltukId).DoluMu = true;
                    /**/
                    /*Database kayıt edilir,kayıt başarılıysa bir mesaj kutusu döner*/
                    if (_koltukUOW.Save() > 0)
                    {
                        MessageBox.Show("başarılı");
                    }
                    else
                    {
                        MessageBox.Show("başarısız");
                    }
                    /**/

                }

                butonlar.Clear();
                lbKoltuklar.DataSource = butonlar.ToList();

                KoltukSayisiHesapla();

            }
            else
            {
                MessageBox.Show("Önce koltuk seçiniz !");
            }

            KoltukKontrol();

        }

        private void A1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                SagTus = btn.Name;
            }
        }

        private void iptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            int iptalEdilecekKoltukId = _koltukRepo.GetList().Where(x => x.KoltukAD == SagTus).Select(x => x.KoltukID).FirstOrDefault();
            _koltukUOW.KoltukRepository().GetById(iptalEdilecekKoltukId).DoluMu = false;

            if (_koltukUOW.Save() > 0)
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

        private void A1_Click(object sender, EventArgs e)
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
