namespace SinemaOtomasyon.WinForm.UI
{
    partial class FormFatura
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
            this.dgvFatura = new System.Windows.Forms.DataGridView();
            this.txtFaturaNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.cbBiletSatis = new System.Windows.Forms.ComboBox();
            this.lblBiletSatis = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatura)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFatura
            // 
            this.dgvFatura.AllowUserToAddRows = false;
            this.dgvFatura.AllowUserToDeleteRows = false;
            this.dgvFatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFatura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFatura.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFatura.Location = new System.Drawing.Point(46, 109);
            this.dgvFatura.MultiSelect = false;
            this.dgvFatura.Name = "dgvFatura";
            this.dgvFatura.ReadOnly = true;
            this.dgvFatura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFatura.Size = new System.Drawing.Size(803, 278);
            this.dgvFatura.TabIndex = 40;
            // 
            // txtFaturaNo
            // 
            this.txtFaturaNo.Location = new System.Drawing.Point(46, 63);
            this.txtFaturaNo.Name = "txtFaturaNo";
            this.txtFaturaNo.Size = new System.Drawing.Size(82, 21);
            this.txtFaturaNo.TabIndex = 29;
            this.txtFaturaNo.TextChanged += new System.EventHandler(this.txtFaturaNo_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(43, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 15);
            this.label16.TabIndex = 41;
            this.label16.Text = "Fatura No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(738, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 41;
            this.label1.Text = "Fatura Tarih:";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(741, 61);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(108, 21);
            this.dtpTarih.TabIndex = 42;
            this.dtpTarih.ValueChanged += new System.EventHandler(this.dtpTarih_ValueChanged);
            // 
            // cbBiletSatis
            // 
            this.cbBiletSatis.FormattingEnabled = true;
            this.cbBiletSatis.Items.AddRange(new object[] {
            "Satılanlar",
            "İptal Edilenler"});
            this.cbBiletSatis.Location = new System.Drawing.Point(370, 63);
            this.cbBiletSatis.Name = "cbBiletSatis";
            this.cbBiletSatis.Size = new System.Drawing.Size(121, 23);
            this.cbBiletSatis.TabIndex = 43;
            this.cbBiletSatis.SelectedIndexChanged += new System.EventHandler(this.cbBiletSatis_SelectedIndexChanged);
            // 
            // lblBiletSatis
            // 
            this.lblBiletSatis.AutoSize = true;
            this.lblBiletSatis.BackColor = System.Drawing.Color.Transparent;
            this.lblBiletSatis.ForeColor = System.Drawing.Color.White;
            this.lblBiletSatis.Location = new System.Drawing.Point(367, 45);
            this.lblBiletSatis.Name = "lblBiletSatis";
            this.lblBiletSatis.Size = new System.Drawing.Size(0, 15);
            this.lblBiletSatis.TabIndex = 44;
            this.lblBiletSatis.Visible = false;
            // 
            // FormFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SinemaOtomasyon.WinForm.UI.Properties.Resources.black_patterns_16;
            this.ClientSize = new System.Drawing.Size(900, 447);
            this.Controls.Add(this.lblBiletSatis);
            this.Controls.Add(this.cbBiletSatis);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvFatura);
            this.Controls.Add(this.txtFaturaNo);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFatura";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fatura";
            this.Load += new System.EventHandler(this.FormFatura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFatura;
        private System.Windows.Forms.TextBox txtFaturaNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.ComboBox cbBiletSatis;
        private System.Windows.Forms.Label lblBiletSatis;
    }
}