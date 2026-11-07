namespace CapaPresentacion
{
    partial class FrmRequerimiento
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
            this.grpCabecera = new System.Windows.Forms.GroupBox();
            this.lblSemana = new System.Windows.Forms.Label();
            this.txtSemana = new System.Windows.Forms.TextBox();
            this.lblConteo = new System.Windows.Forms.Label();
            this.dtpConteo = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cboInsumo = new System.Windows.Forms.ComboBox();
            this.lblUnidadTxt = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblUtilizable = new System.Windows.Forms.Label();
            this.nudUtilizable = new System.Windows.Forms.NumericUpDown();
            this.lblNecesidad = new System.Windows.Forms.Label();
            this.nudNecesidad = new System.Windows.Forms.NumericUpDown();
            this.lblSolicitada = new System.Windows.Forms.Label();
            this.nudSolicitada = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblNotaConteo = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.grpMios = new System.Windows.Forms.GroupBox();
            this.dgvMios = new System.Windows.Forms.DataGridView();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.btnCorregir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBorrador = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudUtilizable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNecesidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolicitada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMios)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpCabecera.SuspendLayout();
            this.grpDetalle.SuspendLayout();
            this.grpMios.SuspendLayout();
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
            this.lblTitulo.Text = "Elaborar requerimiento semanal (CUS-07)";
            this.lblTitulo.TabIndex = 0;
            // 
            // grpCabecera
            // 
            this.grpCabecera.Location = new System.Drawing.Point(20, 64);
            this.grpCabecera.Name = "grpCabecera";
            this.grpCabecera.Size = new System.Drawing.Size(920, 70);
            this.grpCabecera.Text = "  Requerimiento semanal  ";
            this.grpCabecera.TabIndex = 1;
            this.grpCabecera.Controls.Add(this.lblSemana);
            this.grpCabecera.Controls.Add(this.txtSemana);
            this.grpCabecera.Controls.Add(this.lblConteo);
            this.grpCabecera.Controls.Add(this.dtpConteo);
            this.grpCabecera.Controls.Add(this.lblEstado);
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Location = new System.Drawing.Point(15, 33);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Text = "Semana:";
            this.lblSemana.TabIndex = 2;
            // 
            // txtSemana
            // 
            this.txtSemana.MaxLength = 20;
            this.txtSemana.Location = new System.Drawing.Point(75, 29);
            this.txtSemana.Name = "txtSemana";
            this.txtSemana.Size = new System.Drawing.Size(180, 23);
            this.txtSemana.TabIndex = 3;
            // 
            // lblConteo
            // 
            this.lblConteo.AutoSize = true;
            this.lblConteo.Location = new System.Drawing.Point(280, 33);
            this.lblConteo.Name = "lblConteo";
            this.lblConteo.Text = "Fecha del conteo fisico:";
            this.lblConteo.TabIndex = 4;
            // 
            // dtpConteo
            // 
            this.dtpConteo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpConteo.Location = new System.Drawing.Point(425, 29);
            this.dtpConteo.Name = "dtpConteo";
            this.dtpConteo.Size = new System.Drawing.Size(120, 23);
            this.dtpConteo.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(122, 46, 22);
            this.lblEstado.Location = new System.Drawing.Point(580, 33);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Requerimiento nuevo";
            this.lblEstado.TabIndex = 6;
            // 
            // grpDetalle
            // 
            this.grpDetalle.Location = new System.Drawing.Point(20, 140);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(920, 236);
            this.grpDetalle.Text = "  Insumos del requerimiento  ";
            this.grpDetalle.TabIndex = 7;
            this.grpDetalle.Controls.Add(this.lblInsumo);
            this.grpDetalle.Controls.Add(this.cboInsumo);
            this.grpDetalle.Controls.Add(this.lblUnidadTxt);
            this.grpDetalle.Controls.Add(this.lblUnidad);
            this.grpDetalle.Controls.Add(this.lblUtilizable);
            this.grpDetalle.Controls.Add(this.nudUtilizable);
            this.grpDetalle.Controls.Add(this.lblNecesidad);
            this.grpDetalle.Controls.Add(this.nudNecesidad);
            this.grpDetalle.Controls.Add(this.lblSolicitada);
            this.grpDetalle.Controls.Add(this.nudSolicitada);
            this.grpDetalle.Controls.Add(this.btnAgregar);
            this.grpDetalle.Controls.Add(this.btnQuitar);
            this.grpDetalle.Controls.Add(this.lblNotaConteo);
            this.grpDetalle.Controls.Add(this.dgvDetalle);
            // 
            // lblInsumo
            // 
            this.lblInsumo.AutoSize = true;
            this.lblInsumo.Location = new System.Drawing.Point(15, 31);
            this.lblInsumo.Name = "lblInsumo";
            this.lblInsumo.Text = "Insumo:";
            this.lblInsumo.TabIndex = 8;
            // 
            // cboInsumo
            // 
            this.cboInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsumo.FormattingEnabled = true;
            this.cboInsumo.Location = new System.Drawing.Point(70, 27);
            this.cboInsumo.Name = "cboInsumo";
            this.cboInsumo.Size = new System.Drawing.Size(210, 23);
            this.cboInsumo.TabIndex = 9;
            this.cboInsumo.SelectedIndexChanged += new System.EventHandler(this.cboInsumo_SelectedIndexChanged);
            // 
            // lblUnidadTxt
            // 
            this.lblUnidadTxt.AutoSize = true;
            this.lblUnidadTxt.Location = new System.Drawing.Point(292, 31);
            this.lblUnidadTxt.Name = "lblUnidadTxt";
            this.lblUnidadTxt.Text = "Unidad:";
            this.lblUnidadTxt.TabIndex = 10;
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUnidad.Location = new System.Drawing.Point(342, 31);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Text = "-";
            this.lblUnidad.TabIndex = 11;
            // 
            // lblUtilizable
            // 
            this.lblUtilizable.AutoSize = true;
            this.lblUtilizable.Location = new System.Drawing.Point(400, 31);
            this.lblUtilizable.Name = "lblUtilizable";
            this.lblUtilizable.Text = "Utilizable:";
            this.lblUtilizable.TabIndex = 12;
            // 
            // nudUtilizable
            // 
            this.nudUtilizable.DecimalPlaces = 2;
            this.nudUtilizable.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudUtilizable.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudUtilizable.Location = new System.Drawing.Point(470, 27);
            this.nudUtilizable.Name = "nudUtilizable";
            this.nudUtilizable.Size = new System.Drawing.Size(80, 23);
            this.nudUtilizable.TabIndex = 13;
            // 
            // lblNecesidad
            // 
            this.lblNecesidad.AutoSize = true;
            this.lblNecesidad.Location = new System.Drawing.Point(562, 31);
            this.lblNecesidad.Name = "lblNecesidad";
            this.lblNecesidad.Text = "Necesidad:";
            this.lblNecesidad.TabIndex = 14;
            // 
            // nudNecesidad
            // 
            this.nudNecesidad.DecimalPlaces = 2;
            this.nudNecesidad.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudNecesidad.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudNecesidad.Location = new System.Drawing.Point(633, 27);
            this.nudNecesidad.Name = "nudNecesidad";
            this.nudNecesidad.Size = new System.Drawing.Size(80, 23);
            this.nudNecesidad.TabIndex = 15;
            // 
            // lblSolicitada
            // 
            this.lblSolicitada.AutoSize = true;
            this.lblSolicitada.Location = new System.Drawing.Point(725, 31);
            this.lblSolicitada.Name = "lblSolicitada";
            this.lblSolicitada.Text = "Solicitar:";
            this.lblSolicitada.TabIndex = 16;
            // 
            // nudSolicitada
            // 
            this.nudSolicitada.DecimalPlaces = 2;
            this.nudSolicitada.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudSolicitada.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudSolicitada.Location = new System.Drawing.Point(785, 27);
            this.nudSolicitada.Name = "nudSolicitada";
            this.nudSolicitada.Size = new System.Drawing.Size(80, 23);
            this.nudSolicitada.TabIndex = 17;
            // 
            // btnAgregar
            // 
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Location = new System.Drawing.Point(15, 62);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Location = new System.Drawing.Point(123, 62);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(100, 30);
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TabIndex = 19;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblNotaConteo
            // 
            this.lblNotaConteo.AutoSize = false;
            this.lblNotaConteo.Size = new System.Drawing.Size(640, 22);
            this.lblNotaConteo.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNotaConteo.Location = new System.Drawing.Point(240, 64);
            this.lblNotaConteo.Name = "lblNotaConteo";
            this.lblNotaConteo.Text = "El conteo se guarda con su fecha; no representa existencias permanentes.";
            this.lblNotaConteo.TabIndex = 20;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.Location = new System.Drawing.Point(15, 98);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(890, 128);
            this.dgvDetalle.TabIndex = 21;
            // 
            // grpMios
            // 
            this.grpMios.Location = new System.Drawing.Point(20, 382);
            this.grpMios.Name = "grpMios";
            this.grpMios.Size = new System.Drawing.Size(920, 136);
            this.grpMios.Text = "  Borradores y requerimientos devueltos (A2 / A3)  ";
            this.grpMios.TabIndex = 22;
            this.grpMios.Controls.Add(this.dgvMios);
            this.grpMios.Controls.Add(this.lblObservacion);
            this.grpMios.Controls.Add(this.btnCorregir);
            // 
            // dgvMios
            // 
            this.dgvMios.AllowUserToAddRows = false;
            this.dgvMios.AllowUserToDeleteRows = false;
            this.dgvMios.ReadOnly = true;
            this.dgvMios.MultiSelect = false;
            this.dgvMios.RowHeadersVisible = false;
            this.dgvMios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMios.BackgroundColor = System.Drawing.Color.White;
            this.dgvMios.AllowUserToResizeRows = false;
            this.dgvMios.Location = new System.Drawing.Point(15, 26);
            this.dgvMios.Name = "dgvMios";
            this.dgvMios.Size = new System.Drawing.Size(600, 100);
            this.dgvMios.TabIndex = 23;
            this.dgvMios.SelectionChanged += new System.EventHandler(this.dgvMios_SelectionChanged);
            // 
            // lblObservacion
            // 
            this.lblObservacion.AutoSize = false;
            this.lblObservacion.Size = new System.Drawing.Size(265, 60);
            this.lblObservacion.ForeColor = System.Drawing.Color.Firebrick;
            this.lblObservacion.Location = new System.Drawing.Point(625, 28);
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Text = "";
            this.lblObservacion.TabIndex = 24;
            // 
            // btnCorregir
            // 
            this.btnCorregir.UseVisualStyleBackColor = true;
            this.btnCorregir.Location = new System.Drawing.Point(625, 92);
            this.btnCorregir.Name = "btnCorregir";
            this.btnCorregir.Size = new System.Drawing.Size(150, 30);
            this.btnCorregir.Text = "Corregir requerimiento";
            this.btnCorregir.TabIndex = 25;
            this.btnCorregir.Click += new System.EventHandler(this.btnCorregir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Location = new System.Drawing.Point(20, 530);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 34);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TabIndex = 26;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBorrador
            // 
            this.btnBorrador.UseVisualStyleBackColor = true;
            this.btnBorrador.Location = new System.Drawing.Point(540, 530);
            this.btnBorrador.Name = "btnBorrador";
            this.btnBorrador.Size = new System.Drawing.Size(140, 34);
            this.btnBorrador.Text = "Guardar borrador";
            this.btnBorrador.TabIndex = 27;
            this.btnBorrador.Click += new System.EventHandler(this.btnBorrador_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Location = new System.Drawing.Point(688, 530);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(150, 34);
            this.btnEnviar.Text = "Enviar a revision";
            this.btnEnviar.TabIndex = 28;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(846, 530);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 34);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 29;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmRequerimiento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 584);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpCabecera);
            this.Controls.Add(this.grpDetalle);
            this.Controls.Add(this.grpMios);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnBorrador);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmRequerimiento";
            this.Text = "Elaborar requerimiento semanal (CUS-07)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmRequerimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudUtilizable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNecesidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSolicitada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMios)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCabecera.ResumeLayout(false);
            this.grpCabecera.PerformLayout();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            this.grpMios.ResumeLayout(false);
            this.grpMios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpCabecera;
        private System.Windows.Forms.Label lblSemana;
        private System.Windows.Forms.TextBox txtSemana;
        private System.Windows.Forms.Label lblConteo;
        private System.Windows.Forms.DateTimePicker dtpConteo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cboInsumo;
        private System.Windows.Forms.Label lblUnidadTxt;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblUtilizable;
        private System.Windows.Forms.NumericUpDown nudUtilizable;
        private System.Windows.Forms.Label lblNecesidad;
        private System.Windows.Forms.NumericUpDown nudNecesidad;
        private System.Windows.Forms.Label lblSolicitada;
        private System.Windows.Forms.NumericUpDown nudSolicitada;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblNotaConteo;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox grpMios;
        private System.Windows.Forms.DataGridView dgvMios;
        private System.Windows.Forms.Label lblObservacion;
        private System.Windows.Forms.Button btnCorregir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBorrador;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalir;
    }
}
