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
    public partial class FormFatura : Form
    {

        private IFaturaRepository _faturaRepo;

        public FormFatura()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _faturaRepo = container.Get<IFaturaRepository>();
            InitializeComponent();
        }

        private void FormFatura_Load(object sender, EventArgs e)
        {
            cbBiletSatis.SelectedIndex = 0;
            DGVDoldur();
        }

        private void DGVDoldur()
        {
            dgvFatura.DataSource = _faturaRepo.GetList().Where(x=>x.BiletSatis.Satıldı==true).OrderByDescending(x => x.FaturaID).Select(x => new
            {
                FaturaNo = x.FaturaID,
                PersonelAd = x.Personel.Ad,
                PersonelSoyad = x.Personel.Soyad,
                Odeme = x.OdemeSekli.OdemeSekli1,
                x.BiletSatis.Gise.Gosterim.Salon.SalonAD,
                x.BiletSatis.Gise.Gosterim.Seans.SeansAD,
                x.BiletSatis.Gise.Koltuk.KoltukAD,
                x.BiletSatis.Seyirci.SeyirciAd,
                x.BiletSatis.Seyirci.SeyirciSoyad,
                x.FaturaTarih

            }).ToList();
        }

        private void txtFaturaNo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFaturaNo.Text) == false)
            {
                int faturaId = Convert.ToInt32(txtFaturaNo.Text);
                var sorgu = _faturaRepo.GetList().Where(x => x.FaturaID == faturaId).ToList();
                dgvFatura.DataSource = sorgu.Select(x => new
                {
                    FaturaNo = x.FaturaID,
                    PersonelAd = x.Personel.Ad,
                    PersonelSoyad = x.Personel.Soyad,
                    Odeme = x.OdemeSekli.OdemeSekli1,
                    x.BiletSatis.Gise.Gosterim.Salon.SalonAD,
                    x.BiletSatis.Gise.Gosterim.Seans.SeansAD,
                    x.BiletSatis.Gise.Koltuk.KoltukAD,
                    x.BiletSatis.Seyirci.SeyirciAd,
                    x.BiletSatis.Seyirci.SeyirciSoyad,
                    x.FaturaTarih,

                }).ToList();
            }
            else
            {
                DGVDoldur();
            }
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtFaturaNo.Clear();
            int biletSatildiMi = Convert.ToInt32(lblBiletSatis.Text);
            var sorgu = _faturaRepo.GetList().Where(x => x.FaturaTarih <= dtpTarih.Value&&x.BiletSatis.Satıldı==Convert.ToBoolean(biletSatildiMi)).OrderByDescending(x => x.FaturaTarih).ToList();
            dgvFatura.DataSource = sorgu.Select(x => new
            {
                FaturaNo = x.FaturaID,
                PersonelAd = x.Personel.Ad,
                PersonelSoyad = x.Personel.Soyad,
                Odeme = x.OdemeSekli.OdemeSekli1,
                x.BiletSatis.Gise.Gosterim.Salon.SalonAD,
                x.BiletSatis.Gise.Gosterim.Seans.SeansAD,
                x.BiletSatis.Gise.Koltuk.KoltukAD,
                x.BiletSatis.Seyirci.SeyirciAd,
                x.BiletSatis.Seyirci.SeyirciSoyad,
                x.FaturaTarih,

            }).ToList();
        }

        private void cbBiletSatis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBiletSatis.SelectedIndex==1)
            {
                lblBiletSatis.Text = "0";
                int biletSatildiMi = Convert.ToInt32(lblBiletSatis.Text);
                var sorgu = _faturaRepo.GetList().Where(x => x.FaturaTarih <= dtpTarih.Value && x.BiletSatis.Satıldı == Convert.ToBoolean(biletSatildiMi)).OrderByDescending(x => x.FaturaTarih).ToList();
                dgvFatura.DataSource = sorgu.Select(x => new
                {
                    FaturaNo = x.FaturaID,
                    PersonelAd = x.Personel.Ad,
                    PersonelSoyad = x.Personel.Soyad,
                    Odeme = x.OdemeSekli.OdemeSekli1,
                    x.BiletSatis.Gise.Gosterim.Salon.SalonAD,
                    x.BiletSatis.Gise.Gosterim.Seans.SeansAD,
                    x.BiletSatis.Gise.Koltuk.KoltukAD,
                    x.BiletSatis.Seyirci.SeyirciAd,
                    x.BiletSatis.Seyirci.SeyirciSoyad,
                    x.FaturaTarih,

                }).ToList();
            }
            else
            {
                lblBiletSatis.Text = "1";
                int biletSatildiMi = Convert.ToInt32(lblBiletSatis.Text);
                var sorgu = _faturaRepo.GetList().Where(x => x.FaturaTarih <= dtpTarih.Value && x.BiletSatis.Satıldı == Convert.ToBoolean(biletSatildiMi)).OrderByDescending(x => x.FaturaTarih).ToList();
                dgvFatura.DataSource = sorgu.Select(x => new
                {
                    FaturaNo = x.FaturaID,
                    PersonelAd = x.Personel.Ad,
                    PersonelSoyad = x.Personel.Soyad,
                    Odeme = x.OdemeSekli.OdemeSekli1,
                    x.BiletSatis.Gise.Gosterim.Salon.SalonAD,
                    x.BiletSatis.Gise.Gosterim.Seans.SeansAD,
                    x.BiletSatis.Gise.Koltuk.KoltukAD,
                    x.BiletSatis.Seyirci.SeyirciAd,
                    x.BiletSatis.Seyirci.SeyirciSoyad,
                    x.FaturaTarih,

                }).ToList();
            }
        }
    }
}
