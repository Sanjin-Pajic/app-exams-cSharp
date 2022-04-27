namespace DLWMS.WinForms.IB200262
{
    partial class frmPretragaIB200262
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Predmet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPolaganja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ocjena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrisiPredmet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Slike = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImePrezime,
            this.Predmet,
            this.DatumPolaganja,
            this.Ocjena,
            this.BrisiPredmet,
            this.Slike});
            this.dgvMain.Location = new System.Drawing.Point(13, 67);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidth = 51;
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1071, 326);
            this.dgvMain.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(13, 39);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(201, 22);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // ImePrezime
            // 
            this.ImePrezime.DataPropertyName = "Student";
            this.ImePrezime.HeaderText = "Ime i prezime";
            this.ImePrezime.MinimumWidth = 6;
            this.ImePrezime.Name = "ImePrezime";
            this.ImePrezime.ReadOnly = true;
            this.ImePrezime.Width = 125;
            // 
            // Predmet
            // 
            this.Predmet.DataPropertyName = "Predmet";
            this.Predmet.HeaderText = "Predmet";
            this.Predmet.MinimumWidth = 6;
            this.Predmet.Name = "Predmet";
            this.Predmet.ReadOnly = true;
            this.Predmet.Width = 125;
            // 
            // DatumPolaganja
            // 
            this.DatumPolaganja.DataPropertyName = "DatumPolaganja";
            this.DatumPolaganja.HeaderText = "Datum polaganja";
            this.DatumPolaganja.MinimumWidth = 6;
            this.DatumPolaganja.Name = "DatumPolaganja";
            this.DatumPolaganja.ReadOnly = true;
            this.DatumPolaganja.Width = 125;
            // 
            // Ocjena
            // 
            this.Ocjena.DataPropertyName = "Ocjena";
            this.Ocjena.HeaderText = "Ocjena";
            this.Ocjena.MinimumWidth = 6;
            this.Ocjena.Name = "Ocjena";
            this.Ocjena.ReadOnly = true;
            this.Ocjena.Width = 125;
            // 
            // BrisiPredmet
            // 
            this.BrisiPredmet.HeaderText = "Brisi predmet";
            this.BrisiPredmet.MinimumWidth = 6;
            this.BrisiPredmet.Name = "BrisiPredmet";
            this.BrisiPredmet.ReadOnly = true;
            this.BrisiPredmet.Width = 125;
            // 
            // Slike
            // 
            this.Slike.HeaderText = "Slike";
            this.Slike.MinimumWidth = 6;
            this.Slike.Name = "Slike";
            this.Slike.ReadOnly = true;
            this.Slike.Width = 125;
            // 
            // frmPretragaIB200262
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 450);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.dgvMain);
            this.Name = "frmPretragaIB200262";
            this.Text = "frmPretragaIB200262";
            this.Load += new System.EventHandler(this.frmPretragaIB200262_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Predmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPolaganja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ocjena;
        private System.Windows.Forms.DataGridViewButtonColumn BrisiPredmet;
        private System.Windows.Forms.DataGridViewButtonColumn Slike;
    }
}