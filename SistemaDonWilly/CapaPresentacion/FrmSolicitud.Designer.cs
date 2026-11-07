namespace CapaPresentacion
{
    partial class FrmSolicitud
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
            this.grpNueva = new System.Windows.Forms.GroupBox();
            this.rbMesa = new System.Windows.Forms.RadioButton();
            this.rbLlevar = new System.Windows.Forms.RadioButton();
            this.lblMesa = new System.Windows.Forms.Label();
            this.cboMesa = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.lblTotalTxt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpRespondidas = new System.Windows.Forms.GroupBox();
            this.dgvRespondidas = new System.Windows.Forms.DataGridView();
            this.lblRespuestaTxt = new System.Windows.Forms.Label();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDesistir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespondidas)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpNueva.SuspendLayout();
            this.grpRespondidas.SuspendLayout();
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
            this.lblTitulo.Text = "Registrar y confirmar solicitudes";
            this.lblTitulo.TabIndex = 0;
            // 
            // grpNueva
            // 
            this.grpNueva.Location = new System.Drawing.Point(20, 64);
            this.grpNueva.Name = "grpNueva";
            this.grpNueva.Size = new System.Drawing.Size(920, 262);
            this.grpNueva.Text = "  Nueva solicitud (CUS-01)  ";
            this.grpNueva.TabIndex = 1;
            this.grpNueva.Controls.Add(this.rbMesa);
            this.grpNueva.Controls.Add(this.rbLlevar);
            this.grpNueva.Controls.Add(this.lblMesa);
            this.grpNueva.Controls.Add(this.cboMesa);
            this.grpNueva.Controls.Add(this.lblProducto);
            this.grpNueva.Controls.Add(this.cboProducto);
            this.grpNueva.Controls.Add(this.lblCantidad);
            this.grpNueva.Controls.Add(this.nudCantidad);
            this.grpNueva.Controls.Add(this.btnAgregar);
            this.grpNueva.Controls.Add(this.dgvCarrito);
            this.grpNueva.Controls.Add(this.btnQuitar);
            this.grpNueva.Controls.Add(this.lblTotalTxt);
            this.grpNueva.Controls.Add(this.lblTotal);
            this.grpNueva.Controls.Add(this.btnEnviar);
            this.grpNueva.Controls.Add(this.btnLimpiar);
            // 
            // rbMesa
            // 
            this.rbMesa.Checked = true;
            this.rbMesa.Location = new System.Drawing.Point(15, 28);
            this.rbMesa.Name = "rbMesa";
            this.rbMesa.Size = new System.Drawing.Size(130, 21);
            this.rbMesa.Text = "Consumo en mesa";
            this.rbMesa.TabIndex = 2;
            // 
            // rbLlevar
            // 
            this.rbLlevar.Location = new System.Drawing.Point(150, 28);
            this.rbLlevar.Name = "rbLlevar";
            this.rbLlevar.Size = new System.Drawing.Size(110, 21);
            this.rbLlevar.Text = "Para llevar";
            this.rbLlevar.TabIndex = 3;
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(290, 31);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Text = "Mesa:";
            this.lblMesa.TabIndex = 4;
            // 
            // cboMesa
            // 
            this.cboMesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesa.FormattingEnabled = true;
            this.cboMesa.Location = new System.Drawing.Point(335, 27);
            this.cboMesa.Name = "cboMesa";
            this.cboMesa.Size = new System.Drawing.Size(150, 23);
            this.cboMesa.TabIndex = 5;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(15, 66);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Text = "Producto:";
            this.lblProducto.TabIndex = 6;
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(80, 62);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(280, 23);
            this.cboProducto.TabIndex = 7;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(375, 66);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad:";
            this.lblCantidad.TabIndex = 8;
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 0;
            this.nudCantidad.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            this.nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCantidad.Location = new System.Drawing.Point(440, 62);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(60, 23);
            this.nudCantidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Location = new System.Drawing.Point(515, 60);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.MultiSelect = false;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.AllowUserToResizeRows = false;
            this.dgvCarrito.Location = new System.Drawing.Point(15, 98);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(590, 150);
            this.dgvCarrito.TabIndex = 11;
            // 
            // btnQuitar
            // 
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Location = new System.Drawing.Point(615, 98);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(100, 30);
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // lblTotalTxt
            // 
            this.lblTotalTxt.AutoSize = true;
            this.lblTotalTxt.Location = new System.Drawing.Point(615, 150);
            this.lblTotalTxt.Name = "lblTotalTxt";
            this.lblTotalTxt.Text = "Total (S/):";
            this.lblTotalTxt.TabIndex = 13;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.AutoSize = false;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Size = new System.Drawing.Size(110, 24);
            this.lblTotal.Location = new System.Drawing.Point(615, 172);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "0.00";
            this.lblTotal.TabIndex = 14;
            // 
            // btnEnviar
            // 
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Location = new System.Drawing.Point(740, 98);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(160, 36);
            this.btnEnviar.Text = "Enviar a cocina";
            this.btnEnviar.TabIndex = 15;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Location = new System.Drawing.Point(740, 140);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 30);
            this.btnLimpiar.Text = "Cancelar";
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grpRespondidas
            // 
            this.grpRespondidas.Location = new System.Drawing.Point(20, 334);
            this.grpRespondidas.Name = "grpRespondidas";
            this.grpRespondidas.Size = new System.Drawing.Size(920, 190);
            this.grpRespondidas.Text = "  Solicitudes respondidas por cocina (CUS-03)  ";
            this.grpRespondidas.TabIndex = 17;
            this.grpRespondidas.Controls.Add(this.dgvRespondidas);
            this.grpRespondidas.Controls.Add(this.lblRespuestaTxt);
            this.grpRespondidas.Controls.Add(this.lblRespuesta);
            this.grpRespondidas.Controls.Add(this.btnConfirmar);
            this.grpRespondidas.Controls.Add(this.btnModificar);
            this.grpRespondidas.Controls.Add(this.btnDesistir);
            // 
            // dgvRespondidas
            // 
            this.dgvRespondidas.AllowUserToAddRows = false;
            this.dgvRespondidas.AllowUserToDeleteRows = false;
            this.dgvRespondidas.ReadOnly = true;
            this.dgvRespondidas.MultiSelect = false;
            this.dgvRespondidas.RowHeadersVisible = false;
            this.dgvRespondidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRespondidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRespondidas.BackgroundColor = System.Drawing.Color.White;
            this.dgvRespondidas.AllowUserToResizeRows = false;
            this.dgvRespondidas.Location = new System.Drawing.Point(15, 26);
            this.dgvRespondidas.Name = "dgvRespondidas";
            this.dgvRespondidas.Size = new System.Drawing.Size(600, 150);
            this.dgvRespondidas.TabIndex = 18;
            this.dgvRespondidas.SelectionChanged += new System.EventHandler(this.dgvRespondidas_SelectionChanged);
            // 
            // lblRespuestaTxt
            // 
            this.lblRespuestaTxt.AutoSize = true;
            this.lblRespuestaTxt.Location = new System.Drawing.Point(625, 28);
            this.lblRespuestaTxt.Name = "lblRespuestaTxt";
            this.lblRespuestaTxt.Text = "Respuesta de cocina:";
            this.lblRespuestaTxt.TabIndex = 19;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = false;
            this.lblRespuesta.Size = new System.Drawing.Size(275, 60);
            this.lblRespuesta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRespuesta.Location = new System.Drawing.Point(625, 50);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Text = "";
            this.lblRespuesta.TabIndex = 20;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Location = new System.Drawing.Point(625, 116);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(130, 30);
            this.btnConfirmar.Text = "Confirmar pedido";
            this.btnConfirmar.TabIndex = 21;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Location = new System.Drawing.Point(765, 116);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(135, 30);
            this.btnModificar.Text = "Cambiar pedido";
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDesistir
            // 
            this.btnDesistir.UseVisualStyleBackColor = true;
            this.btnDesistir.Location = new System.Drawing.Point(625, 150);
            this.btnDesistir.Name = "btnDesistir";
            this.btnDesistir.Size = new System.Drawing.Size(130, 30);
            this.btnDesistir.Text = "Desistir";
            this.btnDesistir.TabIndex = 23;
            this.btnDesistir.Click += new System.EventHandler(this.btnDesistir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(20, 536);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar listas";
            this.btnActualizar.TabIndex = 24;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 536);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmSolicitud
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 584);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.grpNueva);
            this.Controls.Add(this.grpRespondidas);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmSolicitud";
            this.Text = "Registrar y confirmar solicitudes";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmSolicitud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespondidas)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpNueva.ResumeLayout(false);
            this.grpNueva.PerformLayout();
            this.grpRespondidas.ResumeLayout(false);
            this.grpRespondidas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpNueva;
        private System.Windows.Forms.RadioButton rbMesa;
        private System.Windows.Forms.RadioButton rbLlevar;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.ComboBox cboMesa;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label lblTotalTxt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox grpRespondidas;
        private System.Windows.Forms.DataGridView dgvRespondidas;
        private System.Windows.Forms.Label lblRespuestaTxt;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesistir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
