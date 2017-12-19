﻿using Ninject;
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

namespace SinemaOtomasyon.WinForm.UI
{
    public partial class FormSalon3 : Form
    {

        private IKoltukRepository _koltukRepo;
        private IGiseRepository _giseRepo;
        private IGosterimRepository _gosterimRepo;
        private IUnitOfWork _gosterimUOW, _koltukUOW;

        private Film f;
        int SeansId, SalonId, GosterimId;
        string SagTus;
        List<string> butonlar = new List<string>();

        public FormSalon3()
        {
            InitializeComponent();
        }

        public FormSalon3(Film f, int SeansId, int SalonId)
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

        private void FormSalon3_Load(object sender, EventArgs e)
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

        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
        }

        private void A3_MouseDown(object sender, MouseEventArgs e)
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

        private void A3_Click(object sender, EventArgs e)
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
