namespace CapaPresentacion
{
    partial class FrmConsultaCobros
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblMedio = new System.Windows.Forms.Label();
            this.cboMedio = new System.Windows.Forms.ComboBox();
            this.lblCajera = new System.Windows.Forms.Label();
            this.cboCajera = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.lblTotalTxt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(122, 46, 22);
            this.pnlTitulo.Height = 48;
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Consultar cobros (CUS-20)";
            this.lblTitulo.TabIndex = 0;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Location = new System.Drawing.Point(20, 62);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(920, 90);
            this.grpFiltros.Text = "  Filtros  ";
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.Controls.Add(this.lblDesde);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.lblHasta);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.lblMedio);
            this.grpFiltros.Controls.Add(this.cboMedio);
            this.grpFiltros.Controls.Add(this.lblCajera);
            this.grpFiltros.Controls.Add(this.cboCajera);
            this.grpFiltros.Controls.Add(this.btnConsultar);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(15, 33);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Text = "Desde:";
            this.lblDesde.TabIndex = 2;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 29);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 23);
            this.dtpDesde.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(185, 33);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.TabIndex = 4;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(230, 29);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 23);
            this.dtpHasta.TabIndex = 5;
            // 
            // lblMedio
            // 
            this.lblMedio.AutoSize = true;
            this.lblMedio.Location = new System.Drawing.Point(360, 33);
            this.lblMedio.Name = "lblMedio";
            this.lblMedio.Text = "Medio de pago:";
            this.lblMedio.TabIndex = 6;
            // 
            // cboMedio
            // 
            this.cboMedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedio.FormattingEnabled = true;
            this.cboMedio.Location = new System.Drawing.Point(455, 29);
            this.cboMedio.Name = "cboMedio";
            this.cboMedio.Size = new System.Drawing.Size(120, 23);
            this.cboMedio.TabIndex = 7;
            // 
            // lblCajera
            // 
            this.lblCajera.AutoSize = true;
            this.lblCajera.Location = new System.Drawing.Point(595, 33);
            this.lblCajera.Name = "lblCajera";
            this.lblCajera.Text = "Cajera:";
            this.lblCajera.TabIndex = 8;
            // 
            // cboCajera
            // 
            this.cboCajera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCajera.FormattingEnabled = true;
            this.cboCajera.Location = new System.Drawing.Point(645, 29);
            this.cboCajera.Name = "cboCajera";
            this.cboCajera.Size = new System.Drawing.Size(240, 23);
            this.cboCajera.TabIndex = 9;
            // 
            // btnConsultar
            // 
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Location = new System.Drawing.Point(15, 56);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 26);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.MultiSelect = false;
            this.dgvResultados.RowHeadersVisible = false;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultados.AllowUserToResizeRows = false;
            this.dgvResultados.Location = new System.Drawing.Point(20, 162);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.Size = new System.Drawing.Size(920, 340);
            this.dgvResultados.TabIndex = 11;
            // 
            // lblTotalTxt
            // 
            this.lblTotalTxt.AutoSize = true;
            this.lblTotalTxt.Location = new System.Drawing.Point(20, 516);
            this.lblTotalTxt.Name = "lblTotalTxt";
            this.lblTotalTxt.Text = "Total recaudado (S/):";
            this.lblTotalTxt.TabIndex = 12;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.AutoSize = false;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Size = new System.Drawing.Size(120, 24);
            this.lblTotal.Location = new System.Drawing.Point(150, 512);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "0.00";
            this.lblTotal.TabIndex = 13;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = false;
            this.lblNota.Size = new System.Drawing.Size(540, 20);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNota.Location = new System.Drawing.Point(290, 514);
            this.lblNota.Name = "lblNota";
            this.lblNota.Text = "Suma los importes aplicados y excluye el vuelto. No es un reporte contable ni tributario.";
            this.lblNota.TabIndex = 14;
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 508);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmConsultaCobros
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 556);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.lblTotalTxt);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmConsultaCobros";
            this.Text = "Consultar cobros (CUS-20)";
            this.AcceptButton = this.btnConsultar;
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmConsultaCobros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblMedio;
        private System.Windows.Forms.ComboBox cboMedio;
        private System.Windows.Forms.Label lblCajera;
        private System.Windows.Forms.ComboBox cboCajera;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Label lblTotalTxt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnSalir;
    }
}
