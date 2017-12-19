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

namespace SinemaOtomasyon.WinForm.UI.PersonelIslemleri
{
    public partial class FormPersonelIslemleri : Form
    {

        private IPersonelRepository _personelRepo;
        private IUnvanRepository _unvanRepo;
        private ICinsiyetRepository _cinsiyetRepo;

        public FormPersonelIslemleri()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _personelRepo = container.Get<IPersonelRepository>();
            _unvanRepo = container.Get<IUnvanRepository>();
            _cinsiyetRepo = container.Get<ICinsiyetRepository>();
            InitializeComponent();
        }

        private void FormPersonelIslemleri_Load(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            #region UnvanDoldurma
            cbUnvan.DataSource = _unvanRepo.GetList().Select(x => new { id = x.UnvanID, ad = x.UnvanAD }).ToList();
            cbUnvan.DisplayMember = "ad";
            cbUnvan.ValueMember = "id";
            #endregion
            #region CinsiyetDoldurma
            cbCinsiyet.DataSource = _cinsiyetRepo.GetList().Select(x => new { ad=x.CinsiyetAD, id=x.CinsiyetID }).ToList();
            cbCinsiyet.DisplayMember = "ad";
            cbCinsiyet.ValueMember = "id";
            #endregion
            DGVDoldur();
        }

        private void DGVDoldur()
        {
            dgvPersonel.DataSource = _personelRepo.GetList().Select(x => new
            {
                x.PersonelID,
                x.Ad,
                x.Soyad,
                x.SicilNo,
                x.Unvan.UnvanAD,
                x.Username
            }).ToList();

            dgvPersonel.Columns[0].Visible = false;
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            #region ButonHareketleri
            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true; 
            #endregion
        }

        private void dgvPersonel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;

            Personel p = new Personel();
            p = _personelRepo.GetById((int)dgvPersonel.CurrentRow.Cells[0].Value);
            txtAd.Text = p.Ad;
            txtSoyad.Text = p.Soyad;
            txtKimlikNo.Text = p.SicilNo;
            txtTelefon.Text = p.Telefon;
            txtAdres.Text = p.Adres;
            chkCalisma.Checked = p.CalismaHali;
            cbUnvan.SelectedValue = p.UnvanID;
            cbCinsiyet.SelectedValue = p.CinsiyetID;
            txtUsername.Text = p.Username;
        }
    }
}
