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
using SinemaOtomasyon.BLL.DTOs;

namespace SinemaOtomasyon.WinForm.UI
{
    public partial class FormSalon2 : Form
    {
        private Film f;
        int SeansId, SalonId, GosterimId;
        string SagTus;
        List<string> butonlar = new List<string>();
        protected IUnitOfWork _uow;

        public FormSalon2()
        {
            InitializeComponent();
        }

        public FormSalon2(Film f, int SeansId, int SalonId)
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _uow = container.Get<IUnitOfWork>();
            CheckForIllegalCrossThreadCalls = false;
            this.f = f;
            this.SeansId = SeansId;
            this.SalonId = SalonId;
            InitializeComponent();
        }


        private async void FormSalon2_Load(object sender, EventArgs e)
        {
            Task task = new Task(LoadItems);
            task.Start();
            await task;
        }

        private void LoadItems()
        {
            GosterimId = _uow.GetRepo<Gosterim>()
                .Where(x => x.SalonID == SalonId && x.SeansID == SeansId)
                .FirstOrDefault()
                .GosterimID;

            #region ErtesiGunKoltukBoşalır
            IEnumerable<KoltukBosaltDTO> koltukBosalt = new List<KoltukBosaltDTO>();
            koltukBosalt = _uow.GetRepo<Gise>()
                .Where(x => x.GosterimID == GosterimId && x.DoluMu == true)
                .Select(x => new KoltukBosaltDTO { GiseId = x.GiseID, Tarih = x.Tarih }).ToList();
            foreach (var item in koltukBosalt)
            {
                if (item.Tarih.Day < DateTime.Now.Day)
                {
                    var sorgu = _uow.GetRepo<Gise>().GetById(item.GiseId);
                    sorgu.DoluMu = false;
                    sorgu.Tarih = DateTime.Now.Date;
                }
            }
            _uow.Commit();
            #endregion

            Temizle();

            butonlar.Clear();
            lbKoltuklar.DataSource = butonlar.ToList();

            KoltukKontrol();
            KoltukSayisiHesapla();

            Gosterim gosterimBilgi = new Gosterim();
            gosterimBilgi = _uow.GetRepo<Gosterim>().GetById(GosterimId);
            txtInformation.Text = f.FilmAd + " / " + gosterimBilgi.Salon.SalonAD + " / " + "Seans: " + gosterimBilgi.Seans.SeansAD + " / ";

            lblTarih.Text = DateTime.Now.ToShortDateString();
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
                    gosterim = _uow.GetRepo<Gosterim>().GetById(GosterimId);
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
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Önce koltuk seçiniz !");
            }

        }

        #region ContextMenuActions
        private void iptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show("İptal etmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int giseId = _uow.GetRepo<Gise>()
                    .Where(x => x.GosterimID == GosterimId && x.Koltuk.KoltukAD == SagTus && x.DoluMu == true)
                    .FirstOrDefault()
                    .GiseID;

                if (giseId == 0)
                {
                    MessageBox.Show("İptal edilebilecek koltuk algılanmadı!", "HATA");
                }
                else
                {
                    _uow.GetRepo<Gise>().GetById(giseId).DoluMu = false;
                    #region SatıldıMı ayarları
                    int biletid = _uow.GetRepo<BiletSatis>()
                        .Where(x => x.GiseID == giseId)
                        .FirstOrDefault()
                        .BiletID;
                    _uow.GetRepo<BiletSatis>().GetById(biletid).Satıldı = false;
                    #endregion

                    if (_uow.Commit() > 0)
                    {
                        MessageBox.Show("İptal edildi.");
                        Button koltuk = new Button();
                        koltuk = (Button)Controls[SagTus.ToString()];
                        koltuk.BackColor = Color.Gray;
                    }
                    else
                    {
                        MessageBox.Show("Başarısız!");
                    }
                }
            }
        }
        #endregion
        #region KoltukKontrol
        private void KoltukKontrol()
        {
            IEnumerable<int> koltuklar = new List<int>();
            koltuklar = _uow.GetRepo<Gise>()
                .Where(x => x.GosterimID == GosterimId && x.DoluMu == true)
                .Select(x => x.KoltukID);
            if (koltuklar.Count() != 0)
            {
                foreach (var item in koltuklar)
                {
                    string koltukAd = _uow.GetRepo<Koltuk>()
                        .GetById(item)
                        .KoltukAD;
                    Button koltuk = new Button();
                    koltuk = (Button)Controls[koltukAd];
                    koltuk.BackColor = Color.Red;
                }
            }

        }
        #endregion
        #region KoltukSayısıHesapla
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
        #endregion
        #region Temizle
        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
        }
        #endregion
        #region MouseActions
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
        private void A5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                SagTus = btn.Name;
            }
        }
        #endregion
        #region Back
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
