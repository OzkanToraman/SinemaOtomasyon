﻿namespace SinemaOtomasyon.WinForm.UI
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
            this.components = new System.ComponentModel.Container();
            this.dgvFilmler = new System.Windows.Forms.DataGridView();
            this.cbSeansSec = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSalonSec = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBiletSatis = new System.Windows.Forms.Button();
            this.pbFilmAfis = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilmler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFilmAfis)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFilmler
            // 
            this.dgvFilmler.AllowUserToAddRows = false;
            this.dgvFilmler.AllowUserToDeleteRows = false;
            this.dgvFilmler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilmler.Location = new System.Drawing.Point(226, 132);
            this.dgvFilmler.Name = "dgvFilmler";
            this.dgvFilmler.ReadOnly = true;
            this.dgvFilmler.Size = new System.Drawing.Size(528, 166);
            this.dgvFilmler.TabIndex = 2;
            // 
            // cbSeansSec
            // 
            this.cbSeansSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSeansSec.FormattingEnabled = true;
            this.cbSeansSec.Items.AddRange(new object[] {
            ""});
            this.cbSeansSec.Location = new System.Drawing.Point(809, 131);
            this.cbSeansSec.Name = "cbSeansSec";
            this.cbSeansSec.Size = new System.Drawing.Size(154, 21);
            this.cbSeansSec.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(806, 164);
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
            this.label3.Location = new System.Drawing.Point(-282, 305);
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
            this.label5.Location = new System.Drawing.Point(-282, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Film Seçimi :";
            // 
            // cbSalonSec
            // 
            this.cbSalonSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSalonSec.FormattingEnabled = true;
            this.cbSalonSec.Location = new System.Drawing.Point(809, 184);
            this.cbSalonSec.Name = "cbSalonSec";
            this.cbSalonSec.Size = new System.Drawing.Size(154, 21);
            this.cbSalonSec.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(223, 112);
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
            this.label8.Location = new System.Drawing.Point(806, 110);
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
            this.btnBiletSatis.Location = new System.Drawing.Point(809, 262);
            this.btnBiletSatis.Name = "btnBiletSatis";
            this.btnBiletSatis.Size = new System.Drawing.Size(154, 36);
            this.btnBiletSatis.TabIndex = 5;
            this.btnBiletSatis.Text = "Bilet Satış İşlemleri";
            this.btnBiletSatis.UseVisualStyleBackColor = false;
            // 
            // pbFilmAfis
            // 
            this.pbFilmAfis.Location = new System.Drawing.Point(54, 132);
            this.pbFilmAfis.Name = "pbFilmAfis";
            this.pbFilmAfis.Size = new System.Drawing.Size(126, 166);
            this.pbFilmAfis.TabIndex = 6;
            this.pbFilmAfis.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(809, 225);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(154, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // FormFilmSeansSalonSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundImage = global::SinemaOtomasyon.WinForm.UI.Properties.Resources.backgroundpattern1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1033, 415);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.pbFilmAfis);
            this.Controls.Add(this.btnBiletSatis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSalonSec);
            this.Controls.Add(this.cbSeansSec);
            this.Controls.Add(this.dgvFilmler);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFilmSeansSalonSec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FİLM GÖSTERİM";
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBiletSatis;
        private System.Windows.Forms.PictureBox pbFilmAfis;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}