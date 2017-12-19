namespace SinemaOtomasyon.WinForm.UI
{
    partial class FormParent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFilmIslemleri = new System.Windows.Forms.Button();
            this.btnPersonelslemleri = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGosterimIslemleri = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFilmIslemleri
            // 
            this.btnFilmIslemleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFilmIslemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilmIslemleri.Font = new System.Drawing.Font("Arial", 15F);
            this.btnFilmIslemleri.Location = new System.Drawing.Point(280, 165);
            this.btnFilmIslemleri.Name = "btnFilmIslemleri";
            this.btnFilmIslemleri.Size = new System.Drawing.Size(150, 150);
            this.btnFilmIslemleri.TabIndex = 0;
            this.btnFilmIslemleri.Text = "Film İşlemleri";
            this.btnFilmIslemleri.UseVisualStyleBackColor = true;
            this.btnFilmIslemleri.Click += new System.EventHandler(this.btnFilmIslemleri_Click_1);
            // 
            // btnPersonelslemleri
            // 
            this.btnPersonelslemleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPersonelslemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersonelslemleri.Font = new System.Drawing.Font("Arial", 15F);
            this.btnPersonelslemleri.Location = new System.Drawing.Point(557, 165);
            this.btnPersonelslemleri.Name = "btnPersonelslemleri";
            this.btnPersonelslemleri.Size = new System.Drawing.Size(150, 150);
            this.btnPersonelslemleri.TabIndex = 0;
            this.btnPersonelslemleri.Text = "Personel İşlemleri";
            this.btnPersonelslemleri.UseVisualStyleBackColor = true;
            this.btnPersonelslemleri.Click += new System.EventHandler(this.btnPersonelslemleri_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Arial", 15F);
            this.button3.Location = new System.Drawing.Point(834, 165);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 150);
            this.button3.TabIndex = 0;
            this.button3.Text = "Bilet Satış";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnFilmIslemleri_Click);
            // 
            // btnGosterimIslemleri
            // 
            this.btnGosterimIslemleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGosterimIslemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGosterimIslemleri.Font = new System.Drawing.Font("Arial", 15F);
            this.btnGosterimIslemleri.Location = new System.Drawing.Point(280, 445);
            this.btnGosterimIslemleri.Name = "btnGosterimIslemleri";
            this.btnGosterimIslemleri.Size = new System.Drawing.Size(150, 150);
            this.btnGosterimIslemleri.TabIndex = 0;
            this.btnGosterimIslemleri.Text = "Gösterim Ayarları";
            this.btnGosterimIslemleri.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Arial", 15F);
            this.button5.Location = new System.Drawing.Point(557, 445);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 150);
            this.button5.TabIndex = 0;
            this.button5.Text = "Fatura İşlemleri";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Arial", 15F);
            this.button6.Location = new System.Drawing.Point(834, 445);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 150);
            this.button6.TabIndex = 0;
            this.button6.Text = "RAPOR";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1085, 739);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oturum:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(1130, 739);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(122, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "sevda@yenisinema.com";
            // 
            // FormParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::SinemaOtomasyon.WinForm.UI.Properties.Resources.black_patterns_16;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGosterimIslemleri);
            this.Controls.Add(this.btnPersonelslemleri);
            this.Controls.Add(this.btnFilmIslemleri);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormParent";
            this.ShowIcon = false;
            this.Text = "ANASAYFA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormParent_FormClosing);
            this.Load += new System.EventHandler(this.FormParent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFilmIslemleri;
        private System.Windows.Forms.Button btnPersonelslemleri;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGosterimIslemleri;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
    }
}