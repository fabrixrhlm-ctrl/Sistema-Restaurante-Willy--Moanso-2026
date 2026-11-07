namespace CapaPresentacion
{
    partial class FrmCobro
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
            this.lblPedidos = new System.Windows.Forms.Label();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblPagos = new System.Windows.Forms.Label();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.grpSaldo = new System.Windows.Forms.GroupBox();
            this.lblTotalTxt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPagadoTxt = new System.Windows.Forms.Label();
            this.lblPagado = new System.Windows.Forms.Label();
            this.lblSaldoTxt = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.grpCobro = new System.Windows.Forms.GroupBox();
            this.lblMedio = new System.Windows.Forms.Label();
            this.cboMedio = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.nudImporte = new System.Windows.Forms.NumericUpDown();
            this.lblRecibido = new System.Windows.Forms.Label();
            this.nudRecibido = new System.Windows.Forms.NumericUpDown();
            this.lblVueltoTxt = new System.Windows.Forms.Label();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lblNotaYape = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecibido)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpSaldo.SuspendLayout();
            this.grpCobro.SuspendLayout();
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
            this.lblTitulo.Text = "Registrar cobro (CUS-06 / CUS-22)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblPedidos
            // 
            this.lblPedidos.AutoSize = true;
            this.lblPedidos.Location = new System.Drawing.Point(20, 62);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Text = "Pedidos por cobrar:";
            this.lblPedidos.TabIndex = 1;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.Location = new System.Drawing.Point(20, 84);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(560, 170);
            this.dgvPedidos.TabIndex = 2;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(20, 262);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Text = "Consumo del pedido (incluye bebidas):";
            this.lblDetalle.TabIndex = 3;
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
            this.dgvDetalle.Location = new System.Drawing.Point(20, 284);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(560, 150);
            this.dgvDetalle.TabIndex = 4;
            // 
            // lblPagos
            // 
            this.lblPagos.AutoSize = true;
            this.lblPagos.Location = new System.Drawing.Point(20, 442);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Text = "Pagos registrados:";
            this.lblPagos.TabIndex = 5;
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.MultiSelect = false;
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagos.AllowUserToResizeRows = false;
            this.dgvPagos.Location = new System.Drawing.Point(20, 464);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.Size = new System.Drawing.Size(560, 90);
            this.dgvPagos.TabIndex = 6;
            // 
            // grpSaldo
            // 
            this.grpSaldo.Location = new System.Drawing.Point(600, 62);
            this.grpSaldo.Name = "grpSaldo";
            this.grpSaldo.Size = new System.Drawing.Size(340, 130);
            this.grpSaldo.Text = "  Saldo del pedido (CUS-22)  ";
            this.grpSaldo.TabIndex = 7;
            this.grpSaldo.Controls.Add(this.lblTotalTxt);
            this.grpSaldo.Controls.Add(this.lblTotal);
            this.grpSaldo.Controls.Add(this.lblPagadoTxt);
            this.grpSaldo.Controls.Add(this.lblPagado);
            this.grpSaldo.Controls.Add(this.lblSaldoTxt);
            this.grpSaldo.Controls.Add(this.lblSaldo);
            // 
            // lblTotalTxt
            // 
            this.lblTotalTxt.AutoSize = true;
            this.lblTotalTxt.Location = new System.Drawing.Point(15, 32);
            this.lblTotalTxt.Name = "lblTotalTxt";
            this.lblTotalTxt.Text = "Total (S/):";
            this.lblTotalTxt.TabIndex = 8;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.AutoSize = false;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Size = new System.Drawing.Size(110, 24);
            this.lblTotal.Location = new System.Drawing.Point(215, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "0.00";
            this.lblTotal.TabIndex = 9;
            // 
            // lblPagadoTxt
            // 
            this.lblPagadoTxt.AutoSize = true;
            this.lblPagadoTxt.Location = new System.Drawing.Point(15, 62);
            this.lblPagadoTxt.Name = "lblPagadoTxt";
            this.lblPagadoTxt.Text = "Pagado (S/):";
            this.lblPagadoTxt.TabIndex = 10;
            // 
            // lblPagado
            // 
            this.lblPagado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPagado.AutoSize = false;
            this.lblPagado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagado.Size = new System.Drawing.Size(110, 24);
            this.lblPagado.Location = new System.Drawing.Point(215, 58);
            this.lblPagado.Name = "lblPagado";
            this.lblPagado.Text = "0.00";
            this.lblPagado.TabIndex = 11;
            // 
            // lblSaldoTxt
            // 
            this.lblSaldoTxt.AutoSize = true;
            this.lblSaldoTxt.Location = new System.Drawing.Point(15, 92);
            this.lblSaldoTxt.Name = "lblSaldoTxt";
            this.lblSaldoTxt.Text = "Saldo pendiente (S/):";
            this.lblSaldoTxt.TabIndex = 12;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.AutoSize = false;
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldo.Size = new System.Drawing.Size(110, 24);
            this.lblSaldo.Location = new System.Drawing.Point(215, 88);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Text = "0.00";
            this.lblSaldo.TabIndex = 13;
            // 
            // grpCobro
            // 
            this.grpCobro.Location = new System.Drawing.Point(600, 202);
            this.grpCobro.Name = "grpCobro";
            this.grpCobro.Size = new System.Drawing.Size(340, 292);
            this.grpCobro.Text = "  Registrar cobro (CUS-06)  ";
            this.grpCobro.TabIndex = 14;
            this.grpCobro.Controls.Add(this.lblMedio);
            this.grpCobro.Controls.Add(this.cboMedio);
            this.grpCobro.Controls.Add(this.lblImporte);
            this.grpCobro.Controls.Add(this.nudImporte);
            this.grpCobro.Controls.Add(this.lblRecibido);
            this.grpCobro.Controls.Add(this.nudRecibido);
            this.grpCobro.Controls.Add(this.lblVueltoTxt);
            this.grpCobro.Controls.Add(this.lblVuelto);
            this.grpCobro.Controls.Add(this.lblReferencia);
            this.grpCobro.Controls.Add(this.txtReferencia);
            this.grpCobro.Controls.Add(this.lblNotaYape);
            this.grpCobro.Controls.Add(this.btnCobrar);
            // 
            // lblMedio
            // 
            this.lblMedio.AutoSize = true;
            this.lblMedio.Location = new System.Drawing.Point(15, 36);
            this.lblMedio.Name = "lblMedio";
            this.lblMedio.Text = "Medio de pago:";
            this.lblMedio.TabIndex = 15;
            // 
            // cboMedio
            // 
            this.cboMedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedio.FormattingEnabled = true;
            this.cboMedio.Location = new System.Drawing.Point(130, 32);
            this.cboMedio.Name = "cboMedio";
            this.cboMedio.Size = new System.Drawing.Size(195, 23);
            this.cboMedio.TabIndex = 16;
            this.cboMedio.SelectedIndexChanged += new System.EventHandler(this.cboMedio_SelectedIndexChanged);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(15, 72);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Text = "Importe a cobrar:";
            this.lblImporte.TabIndex = 17;
            // 
            // nudImporte
            // 
            this.nudImporte.DecimalPlaces = 2;
            this.nudImporte.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudImporte.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudImporte.Location = new System.Drawing.Point(130, 68);
            this.nudImporte.Name = "nudImporte";
            this.nudImporte.Size = new System.Drawing.Size(195, 23);
            this.nudImporte.TabIndex = 18;
            // 
            // lblRecibido
            // 
            this.lblRecibido.AutoSize = true;
            this.lblRecibido.Location = new System.Drawing.Point(15, 108);
            this.lblRecibido.Name = "lblRecibido";
            this.lblRecibido.Text = "Monto recibido:";
            this.lblRecibido.TabIndex = 19;
            // 
            // nudRecibido
            // 
            this.nudRecibido.DecimalPlaces = 2;
            this.nudRecibido.Maximum = new decimal(new int[] { 9999900, 0, 0, 131072 });
            this.nudRecibido.Minimum = new decimal(new int[] { 0, 0, 0, 131072 });
            this.nudRecibido.Location = new System.Drawing.Point(130, 104);
            this.nudRecibido.Name = "nudRecibido";
            this.nudRecibido.Size = new System.Drawing.Size(195, 23);
            this.nudRecibido.TabIndex = 20;
            // 
            // lblVueltoTxt
            // 
            this.lblVueltoTxt.AutoSize = true;
            this.lblVueltoTxt.Location = new System.Drawing.Point(15, 144);
            this.lblVueltoTxt.Name = "lblVueltoTxt";
            this.lblVueltoTxt.Text = "Vuelto (S/):";
            this.lblVueltoTxt.TabIndex = 21;
            // 
            // lblVuelto
            // 
            this.lblVuelto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVuelto.AutoSize = false;
            this.lblVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVuelto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVuelto.Size = new System.Drawing.Size(110, 24);
            this.lblVuelto.Location = new System.Drawing.Point(215, 140);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Text = "0.00";
            this.lblVuelto.TabIndex = 22;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Location = new System.Drawing.Point(15, 180);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Text = "Referencia Yape:";
            this.lblReferencia.TabIndex = 23;
            // 
            // txtReferencia
            // 
            this.txtReferencia.MaxLength = 40;
            this.txtReferencia.Location = new System.Drawing.Point(130, 176);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(195, 23);
            this.txtReferencia.TabIndex = 24;
            // 
            // lblNotaYape
            // 
            this.lblNotaYape.AutoSize = false;
            this.lblNotaYape.Size = new System.Drawing.Size(310, 30);
            this.lblNotaYape.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNotaYape.Location = new System.Drawing.Point(15, 208);
            this.lblNotaYape.Name = "lblNotaYape";
            this.lblNotaYape.Text = "El pago con Yape se verifica manualmente en caja.";
            this.lblNotaYape.TabIndex = 25;
            // 
            // btnCobrar
            // 
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Location = new System.Drawing.Point(15, 244);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(310, 34);
            this.btnCobrar.Text = "Confirmar cobro";
            this.btnCobrar.TabIndex = 26;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(600, 510);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.TabIndex = 27;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmCobro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 566);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPedidos);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblPagos);
            this.Controls.Add(this.dgvPagos);
            this.Controls.Add(this.grpSaldo);
            this.Controls.Add(this.grpCobro);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmCobro";
            this.Text = "Registrar cobro (CUS-06 / CUS-22)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmCobro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecibido)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpSaldo.ResumeLayout(false);
            this.grpSaldo.PerformLayout();
            this.grpCobro.ResumeLayout(false);
            this.grpCobro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPedidos;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.GroupBox grpSaldo;
        private System.Windows.Forms.Label lblTotalTxt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPagadoTxt;
        private System.Windows.Forms.Label lblPagado;
        private System.Windows.Forms.Label lblSaldoTxt;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.GroupBox grpCobro;
        private System.Windows.Forms.Label lblMedio;
        private System.Windows.Forms.ComboBox cboMedio;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.NumericUpDown nudImporte;
        private System.Windows.Forms.Label lblRecibido;
        private System.Windows.Forms.NumericUpDown nudRecibido;
        private System.Windows.Forms.Label lblVueltoTxt;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lblNotaYape;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
