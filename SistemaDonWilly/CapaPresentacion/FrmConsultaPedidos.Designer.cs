namespace CapaPresentacion
{
    partial class FrmConsultaPedidos
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
            this.lblModalidad = new System.Windows.Forms.Label();
            this.cboModalidad = new System.Windows.Forms.ComboBox();
            this.lblAtencion = new System.Windows.Forms.Label();
            this.cboAtencion = new System.Windows.Forms.ComboBox();
            this.lblPago = new System.Windows.Forms.Label();
            this.cboPago = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
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
            this.lblTitulo.Text = "Consultar pedidos (CUS-19)";
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
            this.grpFiltros.Controls.Add(this.lblModalidad);
            this.grpFiltros.Controls.Add(this.cboModalidad);
            this.grpFiltros.Controls.Add(this.lblAtencion);
            this.grpFiltros.Controls.Add(this.cboAtencion);
            this.grpFiltros.Controls.Add(this.lblPago);
            this.grpFiltros.Controls.Add(this.cboPago);
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
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Location = new System.Drawing.Point(360, 33);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Text = "Modalidad:";
            this.lblModalidad.TabIndex = 6;
            // 
            // cboModalidad
            // 
            this.cboModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModalidad.FormattingEnabled = true;
            this.cboModalidad.Location = new System.Drawing.Point(430, 29);
            this.cboModalidad.Name = "cboModalidad";
            this.cboModalidad.Size = new System.Drawing.Size(110, 23);
            this.cboModalidad.TabIndex = 7;
            // 
            // lblAtencion
            // 
            this.lblAtencion.AutoSize = true;
            this.lblAtencion.Location = new System.Drawing.Point(560, 33);
            this.lblAtencion.Name = "lblAtencion";
            this.lblAtencion.Text = "Atencion:";
            this.lblAtencion.TabIndex = 8;
            // 
            // cboAtencion
            // 
            this.cboAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAtencion.FormattingEnabled = true;
            this.cboAtencion.Location = new System.Drawing.Point(620, 29);
            this.cboAtencion.Name = "cboAtencion";
            this.cboAtencion.Size = new System.Drawing.Size(130, 23);
            this.cboAtencion.TabIndex = 9;
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(770, 33);
            this.lblPago.Name = "lblPago";
            this.lblPago.Text = "Pago:";
            this.lblPago.TabIndex = 10;
            // 
            // cboPago
            // 
            this.cboPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPago.FormattingEnabled = true;
            this.cboPago.Location = new System.Drawing.Point(810, 29);
            this.cboPago.Name = "cboPago";
            this.cboPago.Size = new System.Drawing.Size(95, 23);
            this.cboPago.TabIndex = 11;
            // 
            // btnConsultar
            // 
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Location = new System.Drawing.Point(15, 56);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 26);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TabIndex = 12;
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
            this.dgvResultados.TabIndex = 13;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(20, 514);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "";
            this.lblResumen.TabIndex = 14;
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
            // FrmConsultaPedidos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 556);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmConsultaPedidos";
            this.Text = "Consultar pedidos (CUS-19)";
            this.AcceptButton = this.btnConsultar;
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmConsultaPedidos_Load);
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
        private System.Windows.Forms.Label lblModalidad;
        private System.Windows.Forms.ComboBox cboModalidad;
        private System.Windows.Forms.Label lblAtencion;
        private System.Windows.Forms.ComboBox cboAtencion;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.ComboBox cboPago;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnSalir;
    }
}
