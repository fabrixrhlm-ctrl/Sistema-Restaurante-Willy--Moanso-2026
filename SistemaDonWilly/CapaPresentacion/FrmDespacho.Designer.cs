namespace CapaPresentacion
{
    partial class FrmDespacho
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
            this.grpRevision = new System.Windows.Forms.GroupBox();
            this.lblDif = new System.Windows.Forms.Label();
            this.txtDiferencia = new System.Windows.Forms.TextBox();
            this.btnEntrega = new System.Windows.Forms.Button();
            this.btnCorreccion = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpRevision.SuspendLayout();
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
            this.lblTitulo.Text = "Registrar despacho (CUS-05)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblPedidos
            // 
            this.lblPedidos.AutoSize = true;
            this.lblPedidos.Location = new System.Drawing.Point(20, 62);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Text = "Pedidos listos para revision:";
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
            this.dgvPedidos.Size = new System.Drawing.Size(920, 160);
            this.dgvPedidos.TabIndex = 2;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(20, 254);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Text = "Productos y cantidades confirmados:";
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
            this.dgvDetalle.Location = new System.Drawing.Point(20, 276);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(560, 190);
            this.dgvDetalle.TabIndex = 4;
            // 
            // grpRevision
            // 
            this.grpRevision.Location = new System.Drawing.Point(600, 266);
            this.grpRevision.Name = "grpRevision";
            this.grpRevision.Size = new System.Drawing.Size(340, 200);
            this.grpRevision.Text = "  Revision del pedido  ";
            this.grpRevision.TabIndex = 5;
            this.grpRevision.Controls.Add(this.lblDif);
            this.grpRevision.Controls.Add(this.txtDiferencia);
            this.grpRevision.Controls.Add(this.btnEntrega);
            this.grpRevision.Controls.Add(this.btnCorreccion);
            // 
            // lblDif
            // 
            this.lblDif.AutoSize = true;
            this.lblDif.Location = new System.Drawing.Point(15, 28);
            this.lblDif.Name = "lblDif";
            this.lblDif.Text = "Diferencia encontrada (si existe):";
            this.lblDif.TabIndex = 6;
            // 
            // txtDiferencia
            // 
            this.txtDiferencia.Multiline = true;
            this.txtDiferencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiferencia.MaxLength = 250;
            this.txtDiferencia.Location = new System.Drawing.Point(15, 50);
            this.txtDiferencia.Name = "txtDiferencia";
            this.txtDiferencia.Size = new System.Drawing.Size(310, 80);
            this.txtDiferencia.TabIndex = 7;
            // 
            // btnEntrega
            // 
            this.btnEntrega.UseVisualStyleBackColor = true;
            this.btnEntrega.Location = new System.Drawing.Point(15, 144);
            this.btnEntrega.Name = "btnEntrega";
            this.btnEntrega.Size = new System.Drawing.Size(145, 30);
            this.btnEntrega.Text = "Registrar entrega";
            this.btnEntrega.TabIndex = 8;
            this.btnEntrega.Click += new System.EventHandler(this.btnEntrega_Click);
            // 
            // btnCorreccion
            // 
            this.btnCorreccion.UseVisualStyleBackColor = true;
            this.btnCorreccion.Location = new System.Drawing.Point(170, 144);
            this.btnCorreccion.Name = "btnCorreccion";
            this.btnCorreccion.Size = new System.Drawing.Size(155, 30);
            this.btnCorreccion.Text = "Solicitar correccion";
            this.btnCorreccion.TabIndex = 9;
            this.btnCorreccion.Click += new System.EventHandler(this.btnCorreccion_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(20, 482);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 482);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmDespacho
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 534);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPedidos);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.grpRevision);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDespacho";
            this.Text = "Registrar despacho (CUS-05)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmDespacho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpRevision.ResumeLayout(false);
            this.grpRevision.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpRevision;
        private System.Windows.Forms.Label lblDif;
        private System.Windows.Forms.TextBox txtDiferencia;
        private System.Windows.Forms.Button btnEntrega;
        private System.Windows.Forms.Button btnCorreccion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
