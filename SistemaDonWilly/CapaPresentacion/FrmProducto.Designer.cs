namespace CapaPresentacion
{
    partial class FrmProducto
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
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.chkDisponible = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblEstadoRegistro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpDatos.SuspendLayout();
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
            this.lblTitulo.Text = "Mantenedor de productos (CUS-12)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(20, 74);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Text = "Buscar:";
            this.lblBuscar.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(75, 70);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(240, 23);
            this.txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Location = new System.Drawing.Point(325, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Location = new System.Drawing.Point(423, 68);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(90, 30);
            this.btnRefrescar.Text = "Ver todos";
            this.btnRefrescar.TabIndex = 4;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ReadOnly = true;
            this.dgvLista.MultiSelect = false;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            this.dgvLista.AllowUserToResizeRows = false;
            this.dgvLista.Location = new System.Drawing.Point(20, 106);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(880, 210);
            this.dgvLista.TabIndex = 5;
            this.dgvLista.SelectionChanged += new System.EventHandler(this.dgvLista_SelectionChanged);
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellDoubleClick);
            // 
            // grpDatos
            // 
            this.grpDatos.Location = new System.Drawing.Point(20, 326);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(880, 136);
            this.grpDatos.Text = "  Datos del registro  ";
            this.grpDatos.TabIndex = 6;
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblTipo);
            this.grpDatos.Controls.Add(this.cboTipo);
            this.grpDatos.Controls.Add(this.lblPrecio);
            this.grpDatos.Controls.Add(this.nudPrecio);
            this.grpDatos.Controls.Add(this.chkDisponible);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Location = new System.Drawing.Point(130, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 23);
            this.txtNombre.TabIndex = 8;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(450, 36);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.TabIndex = 9;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(560, 32);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(160, 23);
            this.cboTipo.TabIndex = 10;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(20, 70);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Text = "Precio (S/):";
            this.lblPrecio.TabIndex = 11;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Maximum = new decimal(new int[] { 999900, 0, 0, 131072 });
            this.nudPrecio.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudPrecio.Location = new System.Drawing.Point(130, 66);
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(120, 23);
            this.nudPrecio.TabIndex = 12;
            // 
            // chkDisponible
            // 
            this.chkDisponible.Location = new System.Drawing.Point(560, 66);
            this.chkDisponible.Name = "chkDisponible";
            this.chkDisponible.Size = new System.Drawing.Size(260, 21);
            this.chkDisponible.Text = "Disponible en la oferta del dia";
            this.chkDisponible.TabIndex = 13;
            // 
            // btnNuevo
            // 
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Location = new System.Drawing.Point(20, 476);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Location = new System.Drawing.Point(128, 476);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 30);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEstado
            // 
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Location = new System.Drawing.Point(236, 476);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(120, 30);
            this.btnEstado.Text = "Desactivar";
            this.btnEstado.TabIndex = 16;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Location = new System.Drawing.Point(580, 476);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Location = new System.Drawing.Point(688, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(796, 476);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblEstadoRegistro
            // 
            this.lblEstadoRegistro.AutoSize = true;
            this.lblEstadoRegistro.ForeColor = System.Drawing.Color.FromArgb(122, 46, 22);
            this.lblEstadoRegistro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstadoRegistro.Location = new System.Drawing.Point(364, 483);
            this.lblEstadoRegistro.Name = "lblEstadoRegistro";
            this.lblEstadoRegistro.Text = "";
            this.lblEstadoRegistro.TabIndex = 20;
            // 
            // FrmProducto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(920, 528);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblEstadoRegistro);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmProducto";
            this.Text = "Mantenedor de productos (CUS-12)";
            this.AcceptButton = this.btnGuardar;
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblEstadoRegistro;
    }
}
