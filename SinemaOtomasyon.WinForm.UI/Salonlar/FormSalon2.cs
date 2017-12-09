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
    public partial class FormSalon2 : Form
    {
        public FormSalon2()
        {
            InitializeComponent();
        }

        

        private void FormSalon2_Load(object sender, EventArgs e)
        {

        }

        private void A4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == Color.FromArgb(64,64,64))
            {
                btn.BackColor = Color.Green;
            }
            else if (btn.BackColor==Color.Green)
            {
                btn.BackColor = Color.FromArgb(64, 64, 64);
            }
        }
    }
}
