namespace CapaPresentacion
{
    partial class FrmPreparacion
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
            this.lblAyuda = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnListo = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
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
            this.lblTitulo.Text = "Actualizar preparacion (CUS-04)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblPedidos
            // 
            this.lblPedidos.AutoSize = true;
            this.lblPedidos.Location = new System.Drawing.Point(20, 62);
            this.lblPedidos.Name = "lblPedidos";
            this.lblPedidos.Text = "Pedidos para preparar:";
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
            this.dgvPedidos.Size = new System.Drawing.Size(920, 180);
            this.dgvPedidos.TabIndex = 2;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(20, 274);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Text = "Detalle del pedido seleccionado:";
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
            this.dgvDetalle.Location = new System.Drawing.Point(20, 296);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(600, 180);
            this.dgvDetalle.TabIndex = 4;
            // 
            // lblAyuda
            // 
            this.lblAyuda.AutoSize = false;
            this.lblAyuda.Size = new System.Drawing.Size(300, 80);
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.lblAyuda.Location = new System.Drawing.Point(640, 296);
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Text = "";
            this.lblAyuda.TabIndex = 5;
            // 
            // btnIniciar
            // 
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Location = new System.Drawing.Point(640, 390);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(150, 34);
            this.btnIniciar.Text = "Iniciar preparacion";
            this.btnIniciar.TabIndex = 6;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnListo
            // 
            this.btnListo.UseVisualStyleBackColor = true;
            this.btnListo.Location = new System.Drawing.Point(800, 390);
            this.btnListo.Name = "btnListo";
            this.btnListo.Size = new System.Drawing.Size(140, 34);
            this.btnListo.Text = "Marcar listo";
            this.btnListo.TabIndex = 7;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(20, 494);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 494);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmPreparacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 546);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPedidos);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnListo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmPreparacion";
            this.Text = "Actualizar preparacion (CUS-04)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmPreparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
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
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnListo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
