namespace CapaPresentacion
{
    partial class FrmDiferencia
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
            this.lblPend = new System.Windows.Forms.Label();
            this.dgvDiferencias = new System.Windows.Forms.DataGridView();
            this.grpRegularizar = new System.Windows.Forms.GroupBox();
            this.lblMotivoTxt = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblSolucion = new System.Windows.Forms.Label();
            this.txtSolucion = new System.Windows.Forms.TextBox();
            this.lblSustento = new System.Windows.Forms.Label();
            this.txtSustento = new System.Windows.Forms.TextBox();
            this.lblFechaReg = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnRegularizar = new System.Windows.Forms.Button();
            this.lblNotaReg = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiferencias)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpRegularizar.SuspendLayout();
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
            this.lblTitulo.Text = "Regularizar diferencia de recepcion (CUS-11)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblPend
            // 
            this.lblPend.AutoSize = true;
            this.lblPend.Location = new System.Drawing.Point(20, 62);
            this.lblPend.Name = "lblPend";
            this.lblPend.Text = "Diferencias de recepcion pendientes:";
            this.lblPend.TabIndex = 1;
            // 
            // dgvDiferencias
            // 
            this.dgvDiferencias.AllowUserToAddRows = false;
            this.dgvDiferencias.AllowUserToDeleteRows = false;
            this.dgvDiferencias.ReadOnly = true;
            this.dgvDiferencias.MultiSelect = false;
            this.dgvDiferencias.RowHeadersVisible = false;
            this.dgvDiferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiferencias.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiferencias.AllowUserToResizeRows = false;
            this.dgvDiferencias.Location = new System.Drawing.Point(20, 84);
            this.dgvDiferencias.Name = "dgvDiferencias";
            this.dgvDiferencias.Size = new System.Drawing.Size(920, 200);
            this.dgvDiferencias.TabIndex = 2;
            this.dgvDiferencias.SelectionChanged += new System.EventHandler(this.dgvDiferencias_SelectionChanged);
            // 
            // grpRegularizar
            // 
            this.grpRegularizar.Location = new System.Drawing.Point(20, 296);
            this.grpRegularizar.Name = "grpRegularizar";
            this.grpRegularizar.Size = new System.Drawing.Size(920, 190);
            this.grpRegularizar.Text = "  Regularizacion  ";
            this.grpRegularizar.TabIndex = 3;
            this.grpRegularizar.Controls.Add(this.lblMotivoTxt);
            this.grpRegularizar.Controls.Add(this.lblMotivo);
            this.grpRegularizar.Controls.Add(this.lblSolucion);
            this.grpRegularizar.Controls.Add(this.txtSolucion);
            this.grpRegularizar.Controls.Add(this.lblSustento);
            this.grpRegularizar.Controls.Add(this.txtSustento);
            this.grpRegularizar.Controls.Add(this.lblFechaReg);
            this.grpRegularizar.Controls.Add(this.dtpFecha);
            this.grpRegularizar.Controls.Add(this.btnRegularizar);
            this.grpRegularizar.Controls.Add(this.lblNotaReg);
            // 
            // lblMotivoTxt
            // 
            this.lblMotivoTxt.AutoSize = true;
            this.lblMotivoTxt.Location = new System.Drawing.Point(15, 30);
            this.lblMotivoTxt.Name = "lblMotivoTxt";
            this.lblMotivoTxt.Text = "Motivo registrado:";
            this.lblMotivoTxt.TabIndex = 4;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = false;
            this.lblMotivo.Size = new System.Drawing.Size(770, 20);
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMotivo.Location = new System.Drawing.Point(130, 30);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Text = "-";
            this.lblMotivo.TabIndex = 5;
            // 
            // lblSolucion
            // 
            this.lblSolucion.AutoSize = true;
            this.lblSolucion.Location = new System.Drawing.Point(15, 62);
            this.lblSolucion.Name = "lblSolucion";
            this.lblSolucion.Text = "Solucion:";
            this.lblSolucion.TabIndex = 6;
            // 
            // txtSolucion
            // 
            this.txtSolucion.Multiline = true;
            this.txtSolucion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSolucion.MaxLength = 250;
            this.txtSolucion.Location = new System.Drawing.Point(15, 84);
            this.txtSolucion.Name = "txtSolucion";
            this.txtSolucion.Size = new System.Drawing.Size(420, 70);
            this.txtSolucion.TabIndex = 7;
            // 
            // lblSustento
            // 
            this.lblSustento.AutoSize = true;
            this.lblSustento.Location = new System.Drawing.Point(455, 62);
            this.lblSustento.Name = "lblSustento";
            this.lblSustento.Text = "Referencia del sustento:";
            this.lblSustento.TabIndex = 8;
            // 
            // txtSustento
            // 
            this.txtSustento.MaxLength = 60;
            this.txtSustento.Location = new System.Drawing.Point(455, 84);
            this.txtSustento.Name = "txtSustento";
            this.txtSustento.Size = new System.Drawing.Size(250, 23);
            this.txtSustento.TabIndex = 9;
            // 
            // lblFechaReg
            // 
            this.lblFechaReg.AutoSize = true;
            this.lblFechaReg.Location = new System.Drawing.Point(720, 62);
            this.lblFechaReg.Name = "lblFechaReg";
            this.lblFechaReg.Text = "Fecha:";
            this.lblFechaReg.TabIndex = 10;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(720, 84);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 23);
            this.dtpFecha.TabIndex = 11;
            // 
            // btnRegularizar
            // 
            this.btnRegularizar.UseVisualStyleBackColor = true;
            this.btnRegularizar.Location = new System.Drawing.Point(455, 120);
            this.btnRegularizar.Name = "btnRegularizar";
            this.btnRegularizar.Size = new System.Drawing.Size(140, 34);
            this.btnRegularizar.Text = "Regularizar";
            this.btnRegularizar.TabIndex = 12;
            this.btnRegularizar.Click += new System.EventHandler(this.btnRegularizar_Click);
            // 
            // lblNotaReg
            // 
            this.lblNotaReg.AutoSize = false;
            this.lblNotaReg.Size = new System.Drawing.Size(300, 40);
            this.lblNotaReg.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNotaReg.Location = new System.Drawing.Point(610, 120);
            this.lblNotaReg.Name = "lblNotaReg";
            this.lblNotaReg.Text = "La regularizacion no modifica cantidades; una reposicion se registra como nueva recepcion.";
            this.lblNotaReg.TabIndex = 13;
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(20, 498);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 498);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmDiferencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 550);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPend);
            this.Controls.Add(this.dgvDiferencias);
            this.Controls.Add(this.grpRegularizar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDiferencia";
            this.Text = "Regularizar diferencia de recepcion (CUS-11)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmDiferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiferencias)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpRegularizar.ResumeLayout(false);
            this.grpRegularizar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPend;
        private System.Windows.Forms.DataGridView dgvDiferencias;
        private System.Windows.Forms.GroupBox grpRegularizar;
        private System.Windows.Forms.Label lblMotivoTxt;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblSolucion;
        private System.Windows.Forms.TextBox txtSolucion;
        private System.Windows.Forms.Label lblSustento;
        private System.Windows.Forms.TextBox txtSustento;
        private System.Windows.Forms.Label lblFechaReg;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnRegularizar;
        private System.Windows.Forms.Label lblNotaReg;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
