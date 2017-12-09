using SinemaOtomasyon.DAL.SinemaContext;
using SinemaOtomasyon.Repository.Repositories.Abstracts;
using SinemaOtomasyon.Repository.Repositories.Concretes;
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
    public partial class FormFilmSeansSalonSec : Form
    {
        public FormFilmSeansSalonSec()
        {
            InitializeComponent();
        }

        //FilmRepository _repo = new FilmRepository(new SinemaContext());

        private void FormFilmSeansSalonSec_Load(object sender, EventArgs e)
        {
            
            //lblDate.Text = DateTime.Now.Date.ToShortDateString() ;
            //timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
