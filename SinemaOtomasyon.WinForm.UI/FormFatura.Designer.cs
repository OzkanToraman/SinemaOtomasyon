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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatura)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFatura
            // 
            this.dgvFatura.AllowUserToAddRows = false;
            this.dgvFatura.AllowUserToDeleteRows = false;
            this.dgvFatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            // FormFatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SinemaOtomasyon.WinForm.UI.Properties.Resources.black_patterns_16;
            this.ClientSize = new System.Drawing.Size(900, 447);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvFatura);
            this.Controls.Add(this.txtFaturaNo);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFatura";
            this.ShowIcon = false;
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
    }
}