namespace CapaPresentacion
{
    partial class FrmUsuario
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
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblTrabajador = new System.Windows.Forms.Label();
            this.cboTrabajador = new System.Windows.Forms.ComboBox();
            this.lblUsuarioNom = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.txtConfirmar = new System.Windows.Forms.TextBox();
            this.lblAyudaClave = new System.Windows.Forms.Label();
            this.lblPerfiles = new System.Windows.Forms.Label();
            this.clbPerfiles = new System.Windows.Forms.CheckedListBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
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
            this.lblTitulo.Text = "Administrar usuarios y perfiles (CUS-18)";
            this.lblTitulo.TabIndex = 0;
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
            this.dgvLista.Location = new System.Drawing.Point(20, 70);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(840, 190);
            this.dgvLista.TabIndex = 1;
            this.dgvLista.SelectionChanged += new System.EventHandler(this.dgvLista_SelectionChanged);
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellDoubleClick);
            // 
            // grpDatos
            // 
            this.grpDatos.Location = new System.Drawing.Point(20, 270);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(840, 200);
            this.grpDatos.Text = "  Datos del acceso  ";
            this.grpDatos.TabIndex = 2;
            this.grpDatos.Controls.Add(this.lblTrabajador);
            this.grpDatos.Controls.Add(this.cboTrabajador);
            this.grpDatos.Controls.Add(this.lblUsuarioNom);
            this.grpDatos.Controls.Add(this.txtUsuario);
            this.grpDatos.Controls.Add(this.lblClave);
            this.grpDatos.Controls.Add(this.txtClave);
            this.grpDatos.Controls.Add(this.lblConfirmar);
            this.grpDatos.Controls.Add(this.txtConfirmar);
            this.grpDatos.Controls.Add(this.lblAyudaClave);
            this.grpDatos.Controls.Add(this.lblPerfiles);
            this.grpDatos.Controls.Add(this.clbPerfiles);
            // 
            // lblTrabajador
            // 
            this.lblTrabajador.AutoSize = true;
            this.lblTrabajador.Location = new System.Drawing.Point(20, 36);
            this.lblTrabajador.Name = "lblTrabajador";
            this.lblTrabajador.Text = "Trabajador:";
            this.lblTrabajador.TabIndex = 3;
            // 
            // cboTrabajador
            // 
            this.cboTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrabajador.FormattingEnabled = true;
            this.cboTrabajador.Location = new System.Drawing.Point(130, 32);
            this.cboTrabajador.Name = "cboTrabajador";
            this.cboTrabajador.Size = new System.Drawing.Size(280, 23);
            this.cboTrabajador.TabIndex = 4;
            // 
            // lblUsuarioNom
            // 
            this.lblUsuarioNom.AutoSize = true;
            this.lblUsuarioNom.Location = new System.Drawing.Point(20, 70);
            this.lblUsuarioNom.Name = "lblUsuarioNom";
            this.lblUsuarioNom.Text = "Usuario:";
            this.lblUsuarioNom.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.MaxLength = 30;
            this.txtUsuario.Location = new System.Drawing.Point(130, 66);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 23);
            this.txtUsuario.TabIndex = 6;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(20, 104);
            this.lblClave.Name = "lblClave";
            this.lblClave.Text = "Contrasena:";
            this.lblClave.TabIndex = 7;
            // 
            // txtClave
            // 
            this.txtClave.PasswordChar = '*';
            this.txtClave.MaxLength = 50;
            this.txtClave.Location = new System.Drawing.Point(130, 100);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(200, 23);
            this.txtClave.TabIndex = 8;
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.AutoSize = true;
            this.lblConfirmar.Location = new System.Drawing.Point(20, 138);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Text = "Confirmar:";
            this.lblConfirmar.TabIndex = 9;
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.PasswordChar = '*';
            this.txtConfirmar.MaxLength = 50;
            this.txtConfirmar.Location = new System.Drawing.Point(130, 134);
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Size = new System.Drawing.Size(200, 23);
            this.txtConfirmar.TabIndex = 10;
            // 
            // lblAyudaClave
            // 
            this.lblAyudaClave.AutoSize = true;
            this.lblAyudaClave.ForeColor = System.Drawing.Color.FromArgb(110, 110, 110);
            this.lblAyudaClave.Location = new System.Drawing.Point(130, 164);
            this.lblAyudaClave.Name = "lblAyudaClave";
            this.lblAyudaClave.Text = "Deje la contrasena vacia para conservar la actual.";
            this.lblAyudaClave.TabIndex = 11;
            // 
            // lblPerfiles
            // 
            this.lblPerfiles.AutoSize = true;
            this.lblPerfiles.Location = new System.Drawing.Point(450, 36);
            this.lblPerfiles.Name = "lblPerfiles";
            this.lblPerfiles.Text = "Perfiles asignados:";
            this.lblPerfiles.TabIndex = 12;
            // 
            // clbPerfiles
            // 
            this.clbPerfiles.CheckOnClick = true;
            this.clbPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbPerfiles.Location = new System.Drawing.Point(450, 58);
            this.clbPerfiles.Name = "clbPerfiles";
            this.clbPerfiles.Size = new System.Drawing.Size(300, 120);
            this.clbPerfiles.TabIndex = 13;
            // 
            // btnNuevo
            // 
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Location = new System.Drawing.Point(20, 484);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Location = new System.Drawing.Point(128, 484);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 30);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEstado
            // 
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Location = new System.Drawing.Point(236, 484);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(120, 30);
            this.btnEstado.Text = "Desactivar";
            this.btnEstado.TabIndex = 16;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Location = new System.Drawing.Point(540, 484);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Location = new System.Drawing.Point(648, 484);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Location = new System.Drawing.Point(756, 484);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmUsuario
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(880, 530);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmUsuario";
            this.Text = "Administrar usuarios y perfiles (CUS-18)";
            this.AcceptButton = this.btnGuardar;
            this.CancelButton = this.btnSalir;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblTrabajador;
        private System.Windows.Forms.ComboBox cboTrabajador;
        private System.Windows.Forms.Label lblUsuarioNom;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Label lblAyudaClave;
        private System.Windows.Forms.Label lblPerfiles;
        private System.Windows.Forms.CheckedListBox clbPerfiles;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
    }
}
