namespace CapaPresentacion
{
    partial class FrmCompra
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
            this.lblReq = new System.Windows.Forms.Label();
            this.cboRequerimiento = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblAv = new System.Windows.Forms.Label();
            this.dgvAvance = new System.Windows.Forms.DataGridView();
            this.grpCompra = new System.Windows.Forms.GroupBox();
            this.lblInsumo = new System.Windows.Forms.Label();
            this.cboInsumo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblDoc = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.lblTotalTxt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNotaDif = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpCompra.SuspendLayout();
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
            this.lblTitulo.Text = "Registrar compra de insumos (CUS-09)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblReq
            // 
            this.lblReq.AutoSize = true;
            this.lblReq.Location = new System.Drawing.Point(20, 66);
            this.lblReq.Name = "lblReq";
            this.lblReq.Text = "Requerimiento revisado:";
            this.lblReq.TabIndex = 1;
            // 
            // cboRequerimiento
            // 
            this.cboRequerimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRequerimiento.FormattingEnabled = true;
            this.cboRequerimiento.Location = new System.Drawing.Point(160, 62);
            this.cboRequerimiento.Name = "cboRequerimiento";
            this.cboRequerimiento.Size = new System.Drawing.Size(260, 23);
            this.cboRequerimiento.TabIndex = 2;
            this.cboRequerimiento.SelectedIndexChanged += new System.EventHandler(this.cboRequerimiento_SelectedIndexChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(440, 66);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Text = "Proveedor:";
            this.lblProveedor.TabIndex = 3;
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(510, 62);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(260, 23);
            this.cboProveedor.TabIndex = 4;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(790, 66);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.TabIndex = 5;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(835, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(105, 23);
            this.dtpFecha.TabIndex = 6;
            // 
            // lblAv
            // 
            this.lblAv.AutoSize = true;
            this.lblAv.Location = new System.Drawing.Point(20, 98);
            this.lblAv.Name = "lblAv";
            this.lblAv.Text = "Cantidades solicitadas y compras acumuladas (B2):";
            this.lblAv.TabIndex = 7;
            // 
            // dgvAvance
            // 
            this.dgvAvance.AllowUserToAddRows = false;
            this.dgvAvance.AllowUserToDeleteRows = false;
            this.dgvAvance.ReadOnly = true;
            this.dgvAvance.MultiSelect = false;
            this.dgvAvance.RowHeadersVisible = false;
            this.dgvAvance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvance.BackgroundColor = System.Drawing.Color.White;
            this.dgvAvance.AllowUserToResizeRows = false;
            this.dgvAvance.Location = new System.Drawing.Point(20, 120);
            this.dgvAvance.Name = "dgvAvance";
            this.dgvAvance.Size = new System.Drawing.Size(920, 120);
            this.dgvAvance.TabIndex = 8;
            // 
            // grpCompra
            // 
            this.grpCompra.Location = new System.Drawing.Point(20, 248);
            this.grpCompra.Name = "grpCompra";
            this.grpCompra.Size = new System.Drawing.Size(920, 262);
            this.grpCompra.Text = "  Datos de la compra  ";
            this.grpCompra.TabIndex = 9;
            this.grpCompra.Controls.Add(this.lblInsumo);
            this.grpCompra.Controls.Add(this.cboInsumo);
            this.grpCompra.Controls.Add(this.lblCantidad);
            this.grpCompra.Controls.Add(this.nudCantidad);
            this.grpCompra.Controls.Add(this.lblPrecio);
            this.grpCompra.Controls.Add(this.nudPrecio);
            this.grpCompra.Controls.Add(this.btnAgregar);
            this.grpCompra.Controls.Add(this.btnQuitar);
            this.grpCompra.Controls.Add(this.dgvDetalle);
            this.grpCompra.Controls.Add(this.lblDoc);
            this.grpCompra.Controls.Add(this.txtDocumento);
            this.grpCompra.Controls.Add(this.lblObs);
            this.grpCompra.Controls.Add(this.txtObservacion);
            this.grpCompra.Controls.Add(this.lblTotalTxt);
            this.grpCompra.Controls.Add(this.lblTotal);
            this.grpCompra.Controls.Add(this.lblNotaDif);
            this.grpCompra.Controls.Add(this.btnConfirmar);
            // 
            // lblInsumo
            // 
            this.lblInsumo.AutoSize = true;
            this.lblInsumo.Location = new System.Drawing.Point(15, 31);
            this.lblInsumo.Name = "lblInsumo";
            this.lblInsumo.Text = "Insumo:";
            this.lblInsumo.TabIndex = 10;
            // 
            // cboInsumo
            // 
            this.cboInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInsumo.FormattingEnabled = true;
            this.cboInsumo.Location = new System.Drawing.Point(70, 27);
            this.cboInsumo.Name = "cboInsumo";
            this.cboInsumo.Size = new System.Drawing.Size(220, 23);
            this.cboInsumo.TabIndex = 11;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(305, 31);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad:";
            this.lblCantidad.TabIndex = 12;
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudCantidad.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudCantidad.Location = new System.Drawing.Point(370, 27);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(90, 23);
            this.nudCantidad.TabIndex = 13;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(475, 31);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Text = "Precio unit. (S/):";
            this.lblPrecio.TabIndex = 14;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudPrecio.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudPrecio.Location = new System.Drawing.Point(580, 27);
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(90, 23);
            this.nudPrecio.TabIndex = 15;
            // 
            // btnAgregar
            // 
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Location = new System.Drawing.Point(685, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Location = new System.Drawing.Point(783, 25);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(90, 30);
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TabIndex = 17;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
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
            this.dgvDetalle.Location = new System.Drawing.Point(15, 62);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(560, 130);
            this.dgvDetalle.TabIndex = 18;
            // 
            // lblDoc
            // 
            this.lblDoc.AutoSize = true;
            this.lblDoc.Location = new System.Drawing.Point(595, 66);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Text = "Documento de respaldo:";
            this.lblDoc.TabIndex = 19;
            // 
            // txtDocumento
            // 
            this.txtDocumento.MaxLength = 30;
            this.txtDocumento.Location = new System.Drawing.Point(595, 88);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(290, 23);
            this.txtDocumento.TabIndex = 20;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(595, 120);
            this.lblObs.Name = "lblObs";
            this.lblObs.Text = "Observacion:";
            this.lblObs.TabIndex = 21;
            // 
            // txtObservacion
            // 
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Location = new System.Drawing.Point(595, 142);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(290, 23);
            this.txtObservacion.TabIndex = 22;
            // 
            // lblTotalTxt
            // 
            this.lblTotalTxt.AutoSize = true;
            this.lblTotalTxt.Location = new System.Drawing.Point(15, 206);
            this.lblTotalTxt.Name = "lblTotalTxt";
            this.lblTotalTxt.Text = "Total de la compra (S/):";
            this.lblTotalTxt.TabIndex = 23;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.AutoSize = false;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Size = new System.Drawing.Size(110, 24);
            this.lblTotal.Location = new System.Drawing.Point(160, 202);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "0.00";
            this.lblTotal.TabIndex = 24;
            // 
            // lblNotaDif
            // 
            this.lblNotaDif.AutoSize = false;
            this.lblNotaDif.Size = new System.Drawing.Size(560, 20);
            this.lblNotaDif.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNotaDif.Location = new System.Drawing.Point(290, 204);
            this.lblNotaDif.Name = "lblNotaDif";
            this.lblNotaDif.Text = "Si la compra difiere de lo solicitado, la observacion es obligatoria.";
            this.lblNotaDif.TabIndex = 25;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Location = new System.Drawing.Point(15, 226);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(190, 30);
            this.btnConfirmar.Text = "Confirmar compra";
            this.btnConfirmar.TabIndex = 26;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(20, 522);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar listas";
            this.btnActualizar.TabIndex = 27;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 522);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmCompra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 574);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblReq);
            this.Controls.Add(this.cboRequerimiento);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblAv);
            this.Controls.Add(this.dgvAvance);
            this.Controls.Add(this.grpCompra);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmCompra";
            this.Text = "Registrar compra de insumos (CUS-09)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpCompra.ResumeLayout(false);
            this.grpCompra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReq;
        private System.Windows.Forms.ComboBox cboRequerimiento;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblAv;
        private System.Windows.Forms.DataGridView dgvAvance;
        private System.Windows.Forms.GroupBox grpCompra;
        private System.Windows.Forms.Label lblInsumo;
        private System.Windows.Forms.ComboBox cboInsumo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Label lblTotalTxt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNotaDif;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
