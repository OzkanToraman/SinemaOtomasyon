namespace SinemaOtomasyon.WinForm.UI
{
    partial class FormFilmSeansSalonSec
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
            this.dgvFilmler = new System.Windows.Forms.DataGridView();
            this.cbSeansSec = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSalonSec = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBiletSatis = new System.Windows.Forms.Button();
            this.pbFilmAfis = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeans = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFilmAd = new System.Windows.Forms.Label();
            this.lblOyuncular = new System.Windows.Forms.Label();
            this.lblYonetmen = new System.Windows.Forms.Label();
            this.lblFilmSuresi = new System.Windows.Forms.Label();
            this.lblFilmTur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilmAfis)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFilmler
            // 
            this.dgvFilmler.AllowUserToAddRows = false;
            this.dgvFilmler.AllowUserToDeleteRows = false;
            this.dgvFilmler.AllowUserToResizeColumns = false;
            this.dgvFilmler.AllowUserToResizeRows = false;
            this.dgvFilmler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFilmler.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvFilmler.Location = new System.Drawing.Point(311, 432);
            this.dgvFilmler.MultiSelect = false;
            this.dgvFilmler.Name = "dgvFilmler";
            this.dgvFilmler.ReadOnly = true;
            this.dgvFilmler.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvFilmler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvFilmler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilmler.Size = new System.Drawing.Size(528, 166);
            this.dgvFilmler.TabIndex = 2;
            this.dgvFilmler.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFilmler_CellMouseClick);
            // 
            // cbSeansSec
            // 
            this.cbSeansSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeansSec.DropDownWidth = 75;
            this.cbSeansSec.Font = new System.Drawing.Font("Arial", 9F);
            this.cbSeansSec.FormattingEnabled = true;
            this.cbSeansSec.Items.AddRange(new object[] {
            ""});
            this.cbSeansSec.Location = new System.Drawing.Point(1045, 432);
            this.cbSeansSec.Name = "cbSeansSec";
            this.cbSeansSec.Size = new System.Drawing.Size(25, 23);
            this.cbSeansSec.TabIndex = 3;
            this.cbSeansSec.SelectedIndexChanged += new System.EventHandler(this.cbSeansSec_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(912, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Salon Seçimi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(-282, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Film Seçimi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(-282, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Film Seçimi :";
            // 
            // cbSalonSec
            // 
            this.cbSalonSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSalonSec.Font = new System.Drawing.Font("Arial", 9F);
            this.cbSalonSec.FormattingEnabled = true;
            this.cbSalonSec.Location = new System.Drawing.Point(915, 489);
            this.cbSalonSec.Name = "cbSalonSec";
            this.cbSalonSec.Size = new System.Drawing.Size(154, 23);
            this.cbSalonSec.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(308, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Film Seçimi :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(912, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Seans Seçimi:";
            // 
            // btnBiletSatis
            // 
            this.btnBiletSatis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBiletSatis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBiletSatis.FlatAppearance.BorderSize = 0;
            this.btnBiletSatis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBiletSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBiletSatis.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBiletSatis.Location = new System.Drawing.Point(915, 533);
            this.btnBiletSatis.Name = "btnBiletSatis";
            this.btnBiletSatis.Size = new System.Drawing.Size(154, 65);
            this.btnBiletSatis.TabIndex = 5;
            this.btnBiletSatis.Text = "Koltuk Seçimi";
            this.btnBiletSatis.UseVisualStyleBackColor = false;
            this.btnBiletSatis.Click += new System.EventHandler(this.btnBiletSatis_Click);
            // 
            // pbFilmAfis
            // 
            this.pbFilmAfis.Location = new System.Drawing.Point(311, 182);
            this.pbFilmAfis.Name = "pbFilmAfis";
            this.pbFilmAfis.Size = new System.Drawing.Size(126, 166);
            this.pbFilmAfis.TabIndex = 6;
            this.pbFilmAfis.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(308, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Afiş :";
            // 
            // txtSeans
            // 
            this.txtSeans.Font = new System.Drawing.Font("Arial", 9.25F);
            this.txtSeans.Location = new System.Drawing.Point(915, 432);
            this.txtSeans.Multiline = true;
            this.txtSeans.Name = "txtSeans";
            this.txtSeans.Size = new System.Drawing.Size(132, 23);
            this.txtSeans.TabIndex = 243;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(473, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 244;
            this.label4.Text = "Film Adı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(473, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 244;
            this.label7.Text = "Oyuncular:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(473, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 244;
            this.label9.Text = "Yönetmen:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(473, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 244;
            this.label10.Text = "Film Süresi:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(473, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 244;
            this.label11.Text = "Film Türü:";
            // 
            // lblFilmAd
            // 
            this.lblFilmAd.AutoSize = true;
            this.lblFilmAd.BackColor = System.Drawing.Color.Transparent;
            this.lblFilmAd.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFilmAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFilmAd.Location = new System.Drawing.Point(577, 209);
            this.lblFilmAd.Name = "lblFilmAd";
            this.lblFilmAd.Size = new System.Drawing.Size(12, 16);
            this.lblFilmAd.TabIndex = 244;
            this.lblFilmAd.Text = " ";
            // 
            // lblOyuncular
            // 
            this.lblOyuncular.AutoSize = true;
            this.lblOyuncular.BackColor = System.Drawing.Color.Transparent;
            this.lblOyuncular.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOyuncular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOyuncular.Location = new System.Drawing.Point(577, 234);
            this.lblOyuncular.Name = "lblOyuncular";
            this.lblOyuncular.Size = new System.Drawing.Size(12, 16);
            this.lblOyuncular.TabIndex = 244;
            this.lblOyuncular.Text = " ";
            // 
            // lblYonetmen
            // 
            this.lblYonetmen.AutoSize = true;
            this.lblYonetmen.BackColor = System.Drawing.Color.Transparent;
            this.lblYonetmen.Font = new System.Drawing.Font("Arial", 10F);
            this.lblYonetmen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblYonetmen.Location = new System.Drawing.Point(577, 259);
            this.lblYonetmen.Name = "lblYonetmen";
            this.lblYonetmen.Size = new System.Drawing.Size(12, 16);
            this.lblYonetmen.TabIndex = 244;
            this.lblYonetmen.Text = " ";
            // 
            // lblFilmSuresi
            // 
            this.lblFilmSuresi.AutoSize = true;
            this.lblFilmSuresi.BackColor = System.Drawing.Color.Transparent;
            this.lblFilmSuresi.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFilmSuresi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFilmSuresi.Location = new System.Drawing.Point(577, 284);
            this.lblFilmSuresi.Name = "lblFilmSuresi";
            this.lblFilmSuresi.Size = new System.Drawing.Size(12, 16);
            this.lblFilmSuresi.TabIndex = 244;
            this.lblFilmSuresi.Text = " ";
            // 
            // lblFilmTur
            // 
            this.lblFilmTur.AutoSize = true;
            this.lblFilmTur.BackColor = System.Drawing.Color.Transparent;
            this.lblFilmTur.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFilmTur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFilmTur.Location = new System.Drawing.Point(577, 309);
            this.lblFilmTur.Name = "lblFilmTur";
            this.lblFilmTur.Size = new System.Drawing.Size(12, 16);
            this.lblFilmTur.TabIndex = 244;
            this.lblFilmTur.Text = " ";
            // 
            // FormFilmSeansSalonSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImage = global::SinemaOtomasyon.WinForm.UI.Properties.Resources.black_patterns_16;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.lblFilmTur);
            this.Controls.Add(this.lblFilmSuresi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblYonetmen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblOyuncular);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFilmAd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSeans);
            this.Controls.Add(this.pbFilmAfis);
            this.Controls.Add(this.btnBiletSatis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSalonSec);
            this.Controls.Add(this.cbSeansSec);
            this.Controls.Add(this.dgvFilmler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFilmSeansSalonSec";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FİLM GÖSTERİM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormFilmSeansSalonSec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilmAfis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFilmler;
        private System.Windows.Forms.ComboBox cbSeansSec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSalonSec;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBiletSatis;
        private System.Windows.Forms.PictureBox pbFilmAfis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFilmAd;
        private System.Windows.Forms.Label lblOyuncular;
        private System.Windows.Forms.Label lblYonetmen;
        private System.Windows.Forms.Label lblFilmSuresi;
        private System.Windows.Forms.Label lblFilmTur;
    }
}