namespace CapaPresentacion
{
    partial class FrmRevisionRequerimiento
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
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.lblDet = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.grpRevision = new System.Windows.Forms.GroupBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.btnConformidad = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.lblNotaAut = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
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
            this.lblTitulo.Text = "Revisar requerimiento semanal (CUS-08)";
            this.lblTitulo.TabIndex = 0;
            // 
            // lblPend
            // 
            this.lblPend.AutoSize = true;
            this.lblPend.Location = new System.Drawing.Point(20, 62);
            this.lblPend.Name = "lblPend";
            this.lblPend.Text = "Requerimientos por revisar:";
            this.lblPend.TabIndex = 1;
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
            this.dgvPendientes.Size = new System.Drawing.Size(920, 140);
            this.dgvPendientes.TabIndex = 2;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged);
            // 
            // lblDet
            // 
            this.lblDet.AutoSize = true;
            this.lblDet.Location = new System.Drawing.Point(20, 234);
            this.lblDet.Name = "lblDet";
            this.lblDet.Text = "Semana, conteo, necesidades, cantidades y unidades:";
            this.lblDet.TabIndex = 3;
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
            this.dgvDetalle.Location = new System.Drawing.Point(20, 256);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Size = new System.Drawing.Size(600, 200);
            this.dgvDetalle.TabIndex = 4;
            // 
            // grpRevision
            // 
            this.grpRevision.Location = new System.Drawing.Point(640, 246);
            this.grpRevision.Name = "grpRevision";
            this.grpRevision.Size = new System.Drawing.Size(300, 220);
            this.grpRevision.Text = "  Revision del administrador  ";
            this.grpRevision.TabIndex = 5;
            this.grpRevision.Controls.Add(this.lblObs);
            this.grpRevision.Controls.Add(this.txtObservacion);
            this.grpRevision.Controls.Add(this.btnConformidad);
            this.grpRevision.Controls.Add(this.btnDevolver);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(15, 28);
            this.lblObs.Name = "lblObs";
            this.lblObs.Text = "Observaciones (para devolver):";
            this.lblObs.TabIndex = 6;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Multiline = true;
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Location = new System.Drawing.Point(15, 50);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(270, 90);
            this.txtObservacion.TabIndex = 7;
            // 
            // btnConformidad
            // 
            this.btnConformidad.UseVisualStyleBackColor = true;
            this.btnConformidad.Location = new System.Drawing.Point(15, 152);
            this.btnConformidad.Name = "btnConformidad";
            this.btnConformidad.Size = new System.Drawing.Size(125, 30);
            this.btnConformidad.Text = "Dar conformidad";
            this.btnConformidad.TabIndex = 8;
            this.btnConformidad.Click += new System.EventHandler(this.btnConformidad_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Location = new System.Drawing.Point(150, 152);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(135, 30);
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.TabIndex = 9;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // lblNotaAut
            // 
            this.lblNotaAut.AutoSize = false;
            this.lblNotaAut.Size = new System.Drawing.Size(700, 22);
            this.lblNotaAut.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblNotaAut.Location = new System.Drawing.Point(20, 466);
            this.lblNotaAut.Name = "lblNotaAut";
            this.lblNotaAut.Text = "No se establece autorizacion por monto: la conformidad habilita las compras del requerimiento.";
            this.lblNotaAut.TabIndex = 10;
            // 
            // btnActualizar
            // 
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Location = new System.Drawing.Point(20, 494);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.Text = "Actualizar lista";
            this.btnActualizar.TabIndex = 11;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(840, 494);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmRevisionRequerimiento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 546);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.lblPend);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.lblDet);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.grpRevision);
            this.Controls.Add(this.lblNotaAut);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmRevisionRequerimiento";
            this.Text = "Revisar requerimiento semanal (CUS-08)";
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmRevisionRequerimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
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
        private System.Windows.Forms.Label lblPend;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Label lblDet;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox grpRevision;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.Button btnConformidad;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label lblNotaAut;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
    }
}
