namespace CapaPresentacion
{
    partial class FrmDisponibilidad
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
            this.lblPendientes = new System.Windows.Forms.Label();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.grpRespuesta = new System.Windows.Forms.GroupBox();
            this.rbFavorable = new System.Windows.Forms.RadioButton();
            this.rbFaltantes = new System.Windows.Forms.RadioButton();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.btnResponder = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlTitulo.SuspendLayout();
            this.grpRespuesta.SuspendLayout();
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
            this.lblTitulo.Text = "Responder disponibilidad (CUS-02)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Location = new System.Drawing.Point(20, 62);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Text = "Solicitudes pendientes de disponibilidad:";
            this.lblPendientes.TabIndex = 1;
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPendientes.AllowUserToResizeRows = false;
            this.dgvPendientes.Location = new System.Drawing.Point(20, 84);
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.Size = new System.Drawing.Size(920, 150);
            this.dgvPendientes.TabIndex = 2;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(20, 244);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Text = "Productos y cantidades solicitados:";
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
            this.dgvDetalle.Location = new System.Drawing.Point(20, 266);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(520, 190);
            this.dgvDetalle.TabIndex = 4;
            // 
            // grpRespuesta
            // 
            this.grpRespuesta.Location = new System.Drawing.Point(560, 254);
            this.grpRespuesta.Name = "grpRespuesta";
            this.grpRespuesta.Size = new System.Drawing.Size(380, 220);
            this.grpRespuesta.Text = "  Respuesta de cocina  ";
            this.grpRespuesta.TabIndex = 5;
            this.grpRespuesta.Controls.Add(this.rbFavorable);
            this.grpRespuesta.Controls.Add(this.rbFaltantes);
            this.grpRespuesta.Controls.Add(this.lblObs);
            this.grpRespuesta.Controls.Add(this.txtObservacion);
            // 
            // rbFavorable
            // 
            this.rbFavorable.Checked = true;
            this.rbFavorable.Location = new System.Drawing.Point(15, 28);
            this.rbFavorable.Name = "rbFavorable";
            this.rbFavorable.Size = new System.Drawing.Size(220, 21);
            this.rbFavorable.Text = "Disponibilidad completa";
            this.rbFavorable.TabIndex = 6;
            // 
            // rbFaltantes
            // 
            this.rbFaltantes.Location = new System.Drawing.Point(15, 54);
            this.rbFaltantes.Name = "rbFaltantes";
            this.rbFaltantes.Size = new System.Drawing.Size(220, 21);
            this.rbFaltantes.Text = "Hay faltantes";
            this.rbFaltantes.TabIndex = 7;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(15, 86);
            this.lblObs.Name = "lblObs";
            this.lblObs.Text = "Faltantes y alternativas:";
            this.lblObs.TabIndex = 8;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Multiline = true;
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Location = new System.Drawing.Point(15, 108);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(350, 90);
            this.txtObservacion.TabIndex = 9;
            // 
            // btnResponder
            // 
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Location = new System.Drawing.Point(700, 484);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(130, 34);
            this.btnResponder.Text = "Responder";
            this.btnResponder.TabIndex = 10;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 484);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 34);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmDisponibilidad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.grpRespuesta);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDisponibilidad";
            this.Text = "Responder disponibilidad (CUS-02)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmDisponibilidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.grpRespuesta.ResumeLayout(false);
            this.grpRespuesta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox grpRespuesta;
        private System.Windows.Forms.RadioButton rbFavorable;
        private System.Windows.Forms.RadioButton rbFaltantes;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnResponder;
        private System.Windows.Forms.Button btnSalir;
    }
}
