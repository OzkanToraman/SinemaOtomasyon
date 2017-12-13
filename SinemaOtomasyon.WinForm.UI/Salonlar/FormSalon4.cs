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
        private IUnitOfWork _gosterimUOW;
        private Film f;
        int SeansId, SalonId;
        string Tarih;
        List<string> butonlar = new List<string>();


        public FormSalon4()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _koltukRepo = container.Get<IKoltukRepository>();
            _gosterimRepo = container.Get<IGosterimRepository>();
            _gosterimUOW = container.Get<IUnitOfWork>();
            InitializeComponent();
        }
        public FormSalon4(Film f, int SeansId, int SalonId, string Tarih)
        {
            InitializeComponent();
            this.f = f;
            this.SeansId = SeansId;
            this.SalonId = SalonId;
            this.Tarih = Tarih;
        }

        private void FormSalon4_Load(object sender, EventArgs e)
        {
            //Gosterim gosterim = new Gosterim();
            //gosterim.FilmID = f.FilmID;
            //gosterim.SalonID = SalonId;
            //gosterim.SeansID = SeansId;
            //_gosterimUOW.GosterimRepository().Add(gosterim);
            //if (_gosterimUOW.Save()>0)
            //{
            //    MessageBox.Show("Kayıt başarılı!");
            //}
            

            //txtInformation.Text = f.FilmAd + " / " + "Salon: "+SalonId+" / "+"Seans: "+SeansId+" / ";
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnBiletKes_Click(object sender, EventArgs e)
        {
            if (lbKoltuklar.Items.Count != 0)
            {
                string koltukAd;
                var koltukListe = _koltukRepo.GetList().Select(x => new { x.KoltukAD });

                Button koltuk = new Button();
                for (int i = 0; i < lbKoltuklar.Items.Count; i++)
                {

                    koltuk = (Button)Controls[lbKoltuklar.Items[i].ToString()];
                    koltuk.BackColor = Color.Red;
                    koltuk.FlatAppearance.MouseOverBackColor = Color.Red;

                    koltukAd = lbKoltuklar.Items[i].ToString();
                    lbSeciliKoltuklar.Items.Add(koltukListe.Where(x => x.KoltukAD == koltukAd).FirstOrDefault());
                    lbSeciliKoltuklar.DisplayMember = "KoltukAd";
                }



                butonlar.Clear();
                lbKoltuklar.DataSource = butonlar.ToList();

                KoltukSayisiHesapla();

                //FormBiletYazdir frm = new FormBiletYazdir();
                //frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Önce koltuk seçiniz !");
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
            else if (btn.BackColor == Color.Red)
            {
                btn.FlatAppearance.MouseOverBackColor = Color.Red;
            }

            lbKoltuklar.DataSource = butonlar.ToList();


        }
    }
}
