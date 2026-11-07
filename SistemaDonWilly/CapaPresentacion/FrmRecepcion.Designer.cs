namespace CapaPresentacion
{
    partial class FrmRecepcion
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
            this.lblCompra = new System.Windows.Forms.Label();
            this.cboCompra = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblDet = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlTitulo.SuspendLayout();
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
            this.lblTitulo.Text = "Registrar recepcion de insumos (CUS-10 / CUS-23)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.Location = new System.Drawing.Point(20, 66);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Text = "Compra a recibir:";
            this.lblCompra.TabIndex = 1;
            // 
            // cboCompra
            // 
            this.cboCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompra.FormattingEnabled = true;
            this.cboCompra.Location = new System.Drawing.Point(130, 62);
            this.cboCompra.Name = "cboCompra";
            this.cboCompra.Size = new System.Drawing.Size(460, 23);
            this.cboCompra.TabIndex = 2;
            this.cboCompra.SelectedIndexChanged += new System.EventHandler(this.cboCompra_SelectedIndexChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(620, 66);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Text = "Fecha de recepcion:";
            this.lblFecha.TabIndex = 3;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(740, 62);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 23);
            this.dtpFecha.TabIndex = 4;
            // 
            // lblDet
            // 
            this.lblDet.AutoSize = true;
            this.lblDet.Location = new System.Drawing.Point(20, 100);
            this.lblDet.Name = "lblDet";
            this.lblDet.Text = "Complete cantidades recibidas y aceptadas; la cantidad observada se calcula (B3):";
            this.lblDet.TabIndex = 5;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.ReadOnly = false;
            this.dgvDetalle.Location = new System.Drawing.Point(20, 124);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(920, 230);
            this.dgvDetalle.TabIndex = 6;
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = false;
            this.lblNota.Size = new System.Drawing.Size(920, 20);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNota.Location = new System.Drawing.Point(20, 360);
            this.lblNota.Name = "lblNota";
            this.lblNota.Text = "Aceptado + observado = recibido. No se acepta mas de lo comprado pendiente. Toda cantidad observada exige su motivo (CUS-23).";
            this.lblNota.TabIndex = 7;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(20, 394);
            this.lblObs.Name = "lblObs";
            this.lblObs.Text = "Observacion general:";
            this.lblObs.TabIndex = 8;
            // 
            // txtObservacion
            // 
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Location = new System.Drawing.Point(150, 390);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(500, 23);
            this.txtObservacion.TabIndex = 9;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Location = new System.Drawing.Point(20, 436);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(170, 34);
            this.btnConfirmar.Text = "Confirmar recepcion";
            this.btnConfirmar.TabIndex = 10;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(200, 436);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 34);
            this.btnActualizar.Text = "Actualizar compras";
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 436);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 34);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmRecepcion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 490);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblCompra);
            this.Controls.Add(this.cboCompra);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblDet);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.lblObs);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmRecepcion";
            this.Text = "Registrar recepcion de insumos (CUS-10 / CUS-23)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmRecepcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.ComboBox cboCompra;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblDet;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
