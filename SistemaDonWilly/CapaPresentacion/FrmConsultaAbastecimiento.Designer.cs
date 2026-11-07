namespace CapaPresentacion
{
    partial class FrmConsultaAbastecimiento
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
            this.lblReq = new System.Windows.Forms.Label();
            this.cboRequerimiento = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.lblDif = new System.Windows.Forms.Label();
            this.cboDiferencia = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
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
            this.lblTitulo.Text = "Consultar abastecimiento (CUS-21)";
            this.lblTitulo.TabIndex = 0;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Location = new System.Drawing.Point(20, 62);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(920, 90);
            this.grpFiltros.Text = "  Filtros  ";
            this.grpFiltros.TabIndex = 1;
            this.grpFiltros.Controls.Add(this.lblReq);
            this.grpFiltros.Controls.Add(this.cboRequerimiento);
            this.grpFiltros.Controls.Add(this.lblProveedor);
            this.grpFiltros.Controls.Add(this.cboProveedor);
            this.grpFiltros.Controls.Add(this.lblDif);
            this.grpFiltros.Controls.Add(this.cboDiferencia);
            this.grpFiltros.Controls.Add(this.btnConsultar);
            // 
            // lblReq
            // 
            this.lblReq.AutoSize = true;
            this.lblReq.Location = new System.Drawing.Point(15, 33);
            this.lblReq.Name = "lblReq";
            this.lblReq.Text = "Requerimiento:";
            this.lblReq.TabIndex = 2;
            // 
            // cboRequerimiento
            // 
            this.cboRequerimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequerimiento.FormattingEnabled = true;
            this.cboRequerimiento.Location = new System.Drawing.Point(105, 29);
            this.cboRequerimiento.Name = "cboRequerimiento";
            this.cboRequerimiento.Size = new System.Drawing.Size(230, 23);
            this.cboRequerimiento.TabIndex = 3;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(355, 33);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Text = "Proveedor:";
            this.lblProveedor.TabIndex = 4;
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(425, 29);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(230, 23);
            this.cboProveedor.TabIndex = 5;
            // 
            // lblDif
            // 
            this.lblDif.AutoSize = true;
            this.lblDif.Location = new System.Drawing.Point(675, 33);
            this.lblDif.Name = "lblDif";
            this.lblDif.Text = "Diferencias:";
            this.lblDif.TabIndex = 6;
            // 
            // cboDiferencia
            // 
            this.cboDiferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiferencia.FormattingEnabled = true;
            this.cboDiferencia.Location = new System.Drawing.Point(750, 29);
            this.cboDiferencia.Name = "cboDiferencia";
            this.cboDiferencia.Size = new System.Drawing.Size(150, 23);
            this.cboDiferencia.TabIndex = 7;
            // 
            // btnConsultar
            // 
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Location = new System.Drawing.Point(15, 56);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(120, 26);
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TabIndex = 8;
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
            this.dgvResultados.TabIndex = 9;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(20, 514);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "";
            this.lblResumen.TabIndex = 10;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = false;
            this.lblNota.Size = new System.Drawing.Size(780, 20);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNota.Location = new System.Drawing.Point(20, 534);
            this.lblNota.Name = "lblNota";
            this.lblNota.Text = "Las cantidades provienen de requerimientos, compras y recepciones; no son un inventario en tiempo real.";
            this.lblNota.TabIndex = 11;
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 508);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmConsultaAbastecimiento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 566);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmConsultaAbastecimiento";
            this.Text = "Consultar abastecimiento (CUS-21)";
            this.AcceptButton = this.btnConsultar;
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmConsultaAbastecimiento_Load);
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
        private System.Windows.Forms.Label lblReq;
        private System.Windows.Forms.ComboBox cboRequerimiento;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label lblDif;
        private System.Windows.Forms.ComboBox cboDiferencia;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Button btnSalir;
    }
}
