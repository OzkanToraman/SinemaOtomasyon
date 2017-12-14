using SinemaOtomasyon.DAL.SinemaContext;
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
    public partial class FormBiletYazdir : Form
    {
        private Seyirci s;

        public FormBiletYazdir()
        {
            InitializeComponent();
        }

        public FormBiletYazdir(Seyirci s)
        {            
            InitializeComponent();
            this.s = s;
        }

        private void FormBiletYazdir_Load(object sender, EventArgs e)
        {
            
        }
    }
}
