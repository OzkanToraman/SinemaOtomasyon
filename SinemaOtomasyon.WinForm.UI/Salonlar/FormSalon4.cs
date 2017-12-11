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
        public FormSalon4()
        {
            InitializeComponent();
        }

        private void FormSalon4_Load(object sender, EventArgs e)
        {

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
