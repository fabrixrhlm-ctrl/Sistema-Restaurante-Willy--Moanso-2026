namespace CapaPresentacion
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuSolicitudes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrarSolicitud = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisponibilidad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtencion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreparacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDespacho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCobranza = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCobro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbastecimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRequerimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRevision = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecepcion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiferencias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMantenedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsumos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMesas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrabajadores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUnidades = new System.Windows.Forms.ToolStripMenuItem();
            this.sepMantenedores = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaCobros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultaAbastecimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPerfilesSesion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlBienvenida = new System.Windows.Forms.Panel();
            this.lblNombreSistema = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuPrincipal.SuspendLayout();
            this.barraEstado.SuspendLayout();
            this.pnlBienvenida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSolicitudes,
            this.mnuAtencion,
            this.mnuCobranza,
            this.mnuAbastecimiento,
            this.mnuMantenedores,
            this.mnuConsultas,
            this.mnuSesion});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1000, 24);
            this.menuPrincipal.TabIndex = 0;
            // 
            // mnuSolicitudes
            // 
            this.mnuSolicitudes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegistrarSolicitud,
            this.mnuDisponibilidad});
            this.mnuSolicitudes.Name = "mnuSolicitudes";
            this.mnuSolicitudes.Size = new System.Drawing.Size(76, 20);
            this.mnuSolicitudes.Text = "&Solicitudes";
            // 
            // mnuRegistrarSolicitud
            // 
            this.mnuRegistrarSolicitud.Name = "mnuRegistrarSolicitud";
            this.mnuRegistrarSolicitud.Size = new System.Drawing.Size(332, 22);
            this.mnuRegistrarSolicitud.Text = "Registrar y confirmar solicitud (CUS-01 / CUS-03)";
            this.mnuRegistrarSolicitud.Click += new System.EventHandler(this.mnuRegistrarSolicitud_Click);
            // 
            // mnuDisponibilidad
            // 
            this.mnuDisponibilidad.Name = "mnuDisponibilidad";
            this.mnuDisponibilidad.Size = new System.Drawing.Size(332, 22);
            this.mnuDisponibilidad.Text = "Responder disponibilidad (CUS-02)";
            this.mnuDisponibilidad.Click += new System.EventHandler(this.mnuDisponibilidad_Click);
            // 
            // mnuAtencion
            // 
            this.mnuAtencion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPreparacion,
            this.mnuDespacho});
            this.mnuAtencion.Name = "mnuAtencion";
            this.mnuAtencion.Size = new System.Drawing.Size(67, 20);
            this.mnuAtencion.Text = "&Atencion";
            // 
            // mnuPreparacion
            // 
            this.mnuPreparacion.Name = "mnuPreparacion";
            this.mnuPreparacion.Size = new System.Drawing.Size(242, 22);
            this.mnuPreparacion.Text = "Actualizar preparacion (CUS-04)";
            this.mnuPreparacion.Click += new System.EventHandler(this.mnuPreparacion_Click);
            // 
            // mnuDespacho
            // 
            this.mnuDespacho.Name = "mnuDespacho";
            this.mnuDespacho.Size = new System.Drawing.Size(242, 22);
            this.mnuDespacho.Text = "Registrar despacho (CUS-05)";
            this.mnuDespacho.Click += new System.EventHandler(this.mnuDespacho_Click);
            // 
            // mnuCobranza
            // 
            this.mnuCobranza.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCobro});
            this.mnuCobranza.Name = "mnuCobranza";
            this.mnuCobranza.Size = new System.Drawing.Size(69, 20);
            this.mnuCobranza.Text = "&Cobranza";
            // 
            // mnuCobro
            // 
            this.mnuCobro.Name = "mnuCobro";
            this.mnuCobro.Size = new System.Drawing.Size(254, 22);
            this.mnuCobro.Text = "Registrar cobro (CUS-06 / CUS-22)";
            this.mnuCobro.Click += new System.EventHandler(this.mnuCobro_Click);
            // 
            // mnuAbastecimiento
            // 
            this.mnuAbastecimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRequerimiento,
            this.mnuRevision,
            this.mnuCompra,
            this.mnuRecepcion,
            this.mnuDiferencias});
            this.mnuAbastecimiento.Name = "mnuAbastecimiento";
            this.mnuAbastecimiento.Size = new System.Drawing.Size(102, 20);
            this.mnuAbastecimiento.Text = "A&bastecimiento";
            // 
            // mnuRequerimiento
            // 
            this.mnuRequerimiento.Name = "mnuRequerimiento";
            this.mnuRequerimiento.Size = new System.Drawing.Size(339, 22);
            this.mnuRequerimiento.Text = "Elaborar requerimiento semanal (CUS-07)";
            this.mnuRequerimiento.Click += new System.EventHandler(this.mnuRequerimiento_Click);
            // 
            // mnuRevision
            // 
            this.mnuRevision.Name = "mnuRevision";
            this.mnuRevision.Size = new System.Drawing.Size(339, 22);
            this.mnuRevision.Text = "Revisar requerimiento semanal (CUS-08)";
            this.mnuRevision.Click += new System.EventHandler(this.mnuRevision_Click);
            // 
            // mnuCompra
            // 
            this.mnuCompra.Name = "mnuCompra";
            this.mnuCompra.Size = new System.Drawing.Size(339, 22);
            this.mnuCompra.Text = "Registrar compra de insumos (CUS-09)";
            this.mnuCompra.Click += new System.EventHandler(this.mnuCompra_Click);
            // 
            // mnuRecepcion
            // 
            this.mnuRecepcion.Name = "mnuRecepcion";
            this.mnuRecepcion.Size = new System.Drawing.Size(339, 22);
            this.mnuRecepcion.Text = "Registrar recepcion de insumos (CUS-10 / CUS-23)";
            this.mnuRecepcion.Click += new System.EventHandler(this.mnuRecepcion_Click);
            // 
            // mnuDiferencias
            // 
            this.mnuDiferencias.Name = "mnuDiferencias";
            this.mnuDiferencias.Size = new System.Drawing.Size(339, 22);
            this.mnuDiferencias.Text = "Regularizar diferencia de recepcion (CUS-11)";
            this.mnuDiferencias.Click += new System.EventHandler(this.mnuDiferencias_Click);
            // 
            // mnuMantenedores
            // 
            this.mnuMantenedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProductos,
            this.mnuInsumos,
            this.mnuProveedores,
            this.mnuMesas,
            this.mnuTrabajadores,
            this.mnuUnidades,
            this.sepMantenedores,
            this.mnuUsuarios});
            this.mnuMantenedores.Name = "mnuMantenedores";
            this.mnuMantenedores.Size = new System.Drawing.Size(95, 20);
            this.mnuMantenedores.Text = "&Mantenedores";
            // 
            // mnuProductos
            // 
            this.mnuProductos.Name = "mnuProductos";
            this.mnuProductos.Size = new System.Drawing.Size(232, 22);
            this.mnuProductos.Text = "Productos (CUS-12)";
            this.mnuProductos.Click += new System.EventHandler(this.mnuProductos_Click);
            // 
            // mnuInsumos
            // 
            this.mnuInsumos.Name = "mnuInsumos";
            this.mnuInsumos.Size = new System.Drawing.Size(232, 22);
            this.mnuInsumos.Text = "Insumos (CUS-13)";
            this.mnuInsumos.Click += new System.EventHandler(this.mnuInsumos_Click);
            // 
            // mnuProveedores
            // 
            this.mnuProveedores.Name = "mnuProveedores";
            this.mnuProveedores.Size = new System.Drawing.Size(232, 22);
            this.mnuProveedores.Text = "Proveedores (CUS-14)";
            this.mnuProveedores.Click += new System.EventHandler(this.mnuProveedores_Click);
            // 
            // mnuMesas
            // 
            this.mnuMesas.Name = "mnuMesas";
            this.mnuMesas.Size = new System.Drawing.Size(232, 22);
            this.mnuMesas.Text = "Mesas (CUS-15)";
            this.mnuMesas.Click += new System.EventHandler(this.mnuMesas_Click);
            // 
            // mnuTrabajadores
            // 
            this.mnuTrabajadores.Name = "mnuTrabajadores";
            this.mnuTrabajadores.Size = new System.Drawing.Size(232, 22);
            this.mnuTrabajadores.Text = "Trabajadores (CUS-16)";
            this.mnuTrabajadores.Click += new System.EventHandler(this.mnuTrabajadores_Click);
            // 
            // mnuUnidades
            // 
            this.mnuUnidades.Name = "mnuUnidades";
            this.mnuUnidades.Size = new System.Drawing.Size(232, 22);
            this.mnuUnidades.Text = "Unidades de medida (CUS-17)";
            this.mnuUnidades.Click += new System.EventHandler(this.mnuUnidades_Click);
            // 
            // sepMantenedores
            // 
            this.sepMantenedores.Name = "sepMantenedores";
            this.sepMantenedores.Size = new System.Drawing.Size(229, 6);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(232, 22);
            this.mnuUsuarios.Text = "Usuarios y perfiles (CUS-18)";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConsultaPedidos,
            this.mnuConsultaCobros,
            this.mnuConsultaAbastecimiento});
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.Size = new System.Drawing.Size(71, 20);
            this.mnuConsultas.Text = "C&onsultas";
            // 
            // mnuConsultaPedidos
            // 
            this.mnuConsultaPedidos.Name = "mnuConsultaPedidos";
            this.mnuConsultaPedidos.Size = new System.Drawing.Size(259, 22);
            this.mnuConsultaPedidos.Text = "Consultar pedidos (CUS-19)";
            this.mnuConsultaPedidos.Click += new System.EventHandler(this.mnuConsultaPedidos_Click);
            // 
            // mnuConsultaCobros
            // 
            this.mnuConsultaCobros.Name = "mnuConsultaCobros";
            this.mnuConsultaCobros.Size = new System.Drawing.Size(259, 22);
            this.mnuConsultaCobros.Text = "Consultar cobros (CUS-20)";
            this.mnuConsultaCobros.Click += new System.EventHandler(this.mnuConsultaCobros_Click);
            // 
            // mnuConsultaAbastecimiento
            // 
            this.mnuConsultaAbastecimiento.Name = "mnuConsultaAbastecimiento";
            this.mnuConsultaAbastecimiento.Size = new System.Drawing.Size(259, 22);
            this.mnuConsultaAbastecimiento.Text = "Consultar abastecimiento (CUS-21)";
            this.mnuConsultaAbastecimiento.Click += new System.EventHandler(this.mnuConsultaAbastecimiento_Click);
            // 
            // mnuSesion
            // 
            this.mnuSesion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrarSesion,
            this.mnuSalir});
            this.mnuSesion.Name = "mnuSesion";
            this.mnuSesion.Size = new System.Drawing.Size(53, 20);
            this.mnuSesion.Text = "S&esion";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(158, 22);
            this.mnuCerrarSesion.Text = "Cerrar sesion";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(158, 22);
            this.mnuSalir.Text = "Salir del sistema";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // barraEstado
            // 
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioSesion,
            this.lblSeparador,
            this.lblPerfilesSesion,
            this.lblFecha});
            this.barraEstado.Location = new System.Drawing.Point(0, 578);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.Size = new System.Drawing.Size(1000, 22);
            this.barraEstado.TabIndex = 1;
            // 
            // lblUsuarioSesion
            // 
            this.lblUsuarioSesion.Name = "lblUsuarioSesion";
            this.lblUsuarioSesion.Size = new System.Drawing.Size(47, 17);
            this.lblUsuarioSesion.Text = "Usuario";
            // 
            // lblSeparador
            // 
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(10, 17);
            this.lblSeparador.Text = "|";
            // 
            // lblPerfilesSesion
            // 
            this.lblPerfilesSesion.Name = "lblPerfilesSesion";
            this.lblPerfilesSesion.Size = new System.Drawing.Size(45, 17);
            this.lblPerfilesSesion.Text = "Perfiles";
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(883, 17);
            this.lblFecha.Spring = true;
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlBienvenida
            // 
            this.pnlBienvenida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(46)))), ((int)(((byte)(22)))));
            this.pnlBienvenida.Controls.Add(this.lblNombreSistema);
            this.pnlBienvenida.Controls.Add(this.lblDescripcion);
            this.pnlBienvenida.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBienvenida.Location = new System.Drawing.Point(0, 24);
            this.pnlBienvenida.Name = "pnlBienvenida";
            this.pnlBienvenida.Size = new System.Drawing.Size(1000, 80);
            this.pnlBienvenida.TabIndex = 2;
            // 
            // lblNombreSistema
            // 
            this.lblNombreSistema.AutoSize = true;
            this.lblNombreSistema.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNombreSistema.ForeColor = System.Drawing.Color.White;
            this.lblNombreSistema.Location = new System.Drawing.Point(24, 14);
            this.lblNombreSistema.Name = "lblNombreSistema";
            this.lblNombreSistema.Size = new System.Drawing.Size(222, 32);
            this.lblNombreSistema.TabIndex = 0;
            this.lblNombreSistema.Text = "Sistema Don Willy";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblDescripcion.Location = new System.Drawing.Point(27, 52);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(397, 15);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Servicio de alimentacion: solicitudes, atencion, cobranza y abastecimiento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 474);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBienvenida);
            this.Controls.Add(this.barraEstado);
            this.Controls.Add(this.menuPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Don Willy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.pnlBienvenida.ResumeLayout(false);
            this.pnlBienvenida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuSolicitudes;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrarSolicitud;
        private System.Windows.Forms.ToolStripMenuItem mnuDisponibilidad;
        private System.Windows.Forms.ToolStripMenuItem mnuAtencion;
        private System.Windows.Forms.ToolStripMenuItem mnuPreparacion;
        private System.Windows.Forms.ToolStripMenuItem mnuDespacho;
        private System.Windows.Forms.ToolStripMenuItem mnuCobranza;
        private System.Windows.Forms.ToolStripMenuItem mnuCobro;
        private System.Windows.Forms.ToolStripMenuItem mnuAbastecimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuRequerimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuRevision;
        private System.Windows.Forms.ToolStripMenuItem mnuCompra;
        private System.Windows.Forms.ToolStripMenuItem mnuRecepcion;
        private System.Windows.Forms.ToolStripMenuItem mnuDiferencias;
        private System.Windows.Forms.ToolStripMenuItem mnuMantenedores;
        private System.Windows.Forms.ToolStripMenuItem mnuProductos;
        private System.Windows.Forms.ToolStripMenuItem mnuInsumos;
        private System.Windows.Forms.ToolStripMenuItem mnuProveedores;
        private System.Windows.Forms.ToolStripMenuItem mnuMesas;
        private System.Windows.Forms.ToolStripMenuItem mnuTrabajadores;
        private System.Windows.Forms.ToolStripMenuItem mnuUnidades;
        private System.Windows.Forms.ToolStripSeparator sepMantenedores;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaPedidos;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaCobros;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultaAbastecimiento;
        private System.Windows.Forms.ToolStripMenuItem mnuSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioSesion;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador;
        private System.Windows.Forms.ToolStripStatusLabel lblPerfilesSesion;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
        private System.Windows.Forms.Panel pnlBienvenida;
        private System.Windows.Forms.Label lblNombreSistema;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
