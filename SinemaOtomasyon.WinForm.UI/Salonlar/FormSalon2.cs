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

namespace SinemaOtomasyon.WinForm.UI
{
    public partial class FormSalon2 : Form
    {
        
        public FormSalon2()
        {
           
            InitializeComponent();
        }


        List<string> butonlar = new List<string>();
        GosterimModel model = new GosterimModel();

        private void FormSalon2_Load(object sender, EventArgs e)
        {
            if (model.koltukList != null)
            {
                foreach (var item in model.koltukList)
                {
                    Button btn = new Button();
                    btn = (Button)Controls[item.ToString()];
                    btn.BackColor = Color.Red;
                }
            }
        }

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
            else if (btn.BackColor ==Color.Red)
            {
                btn.BackColor = Color.Red;
            }

            lbKoltuklar.DataSource = butonlar.ToList();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            
            model.koltukList = butonlar;

            foreach (var item in butonlar)
            {
                Button btn = new Button();
                btn =(Button)Controls[item.ToString()];
                btn.BackColor = Color.Red;
            }

            butonlar.Clear();
            lbKoltuklar.DataSource = butonlar.ToList();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
