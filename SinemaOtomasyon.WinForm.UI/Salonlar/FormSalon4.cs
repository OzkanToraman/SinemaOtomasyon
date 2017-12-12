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

namespace SinemaOtomasyon.WinForm.UI.Salonlar
{
    public partial class FormSalon4 : Form
    {
        private IKoltukRepository _koltukRepo;
        private Film f;
        int SeansId, SalonId;
        string Tarih;


        public FormSalon4()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _koltukRepo = container.Get<IKoltukRepository>();
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
            txtInformation.Text = f.FilmAd;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void A1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.Gray)
            {
                btn.BackColor = Color.Green;     
            }
            else if (btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.Gray;
                
            }

            
        }
    }
}
