using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Menu principal. Muestra solo las opciones del perfil en sesion (RNF-01);
    /// la capa logica vuelve a comprobar el permiso en cada operacion.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioSesion.Text = "Usuario: " + entSesion.trabajador + " (" + entSesion.nomUsuario + ")";
            lblPerfilesSesion.Text = "Perfil: " + PerfilesTexto();
            lblFecha.Text = DateTime.Now.ToString("dddd dd/MM/yyyy");
            AplicarPermisos();
        }

        #region permisos

        private string PerfilesTexto()
        {
            string[] nombres = new string[entSesion.Usuario.perfiles.Count];

            for (int i = 0; i < nombres.Length; i++)
            {
                nombres[i] = entSesion.Usuario.perfiles[i].nombre;
            }
            return string.Join(", ", nombres);
        }

        private void AplicarPermisos()
        {
            bool admin = entSesion.TienePerfil(entSesion.PERFIL_ADMINISTRADOR);
            bool mesera = entSesion.TienePerfil(entSesion.PERFIL_MESERA);
            bool cocina = entSesion.TienePerfil(entSesion.PERFIL_COCINA);
            bool cajera = entSesion.TienePerfil(entSesion.PERFIL_CAJERA);
            bool almacen = entSesion.TienePerfil(entSesion.PERFIL_ALMACEN);

            mnuRegistrarSolicitud.Visible = mesera || cajera;
            mnuDisponibilidad.Visible = cocina;
            mnuSolicitudes.Visible = mesera || cajera || cocina;

            mnuPreparacion.Visible = cocina;
            mnuDespacho.Visible = mesera;
            mnuAtencion.Visible = cocina || mesera;

            mnuCobranza.Visible = cajera;

            mnuRequerimiento.Visible = almacen;
            mnuRevision.Visible = admin;
            mnuCompra.Visible = admin;
            mnuRecepcion.Visible = almacen;
            mnuDiferencias.Visible = admin;
            mnuAbastecimiento.Visible = almacen || admin;

            mnuProductos.Visible = admin;
            mnuProveedores.Visible = admin;
            mnuMesas.Visible = admin;
            mnuTrabajadores.Visible = admin;
            mnuInsumos.Visible = almacen;
            mnuUnidades.Visible = almacen;
            mnuUsuarios.Visible = admin;
            sepMantenedores.Visible = admin;
            mnuMantenedores.Visible = admin || almacen;

            // CUS-19: mesera, cocina, cajera y administrador. CUS-20: cajera. CUS-21: almacen.
            mnuConsultaPedidos.Visible = mesera || cocina || cajera;
            mnuConsultaCobros.Visible = cajera;
            mnuConsultaAbastecimiento.Visible = almacen;
        }

        #endregion permisos

        #region apertura de pantallas

        private void Abrir(Form formulario)
        {
            try
            {
                formulario.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
            finally
            {
                formulario.Dispose();
            }
        }

        private void mnuRegistrarSolicitud_Click(object sender, EventArgs e) { Abrir(new FrmSolicitud()); }
        private void mnuDisponibilidad_Click(object sender, EventArgs e) { Abrir(new FrmDisponibilidad()); }
        private void mnuPreparacion_Click(object sender, EventArgs e) { Abrir(new FrmPreparacion()); }
        private void mnuDespacho_Click(object sender, EventArgs e) { Abrir(new FrmDespacho()); }
        private void mnuCobro_Click(object sender, EventArgs e) { Abrir(new FrmCobro()); }
        private void mnuRequerimiento_Click(object sender, EventArgs e) { Abrir(new FrmRequerimiento()); }
        private void mnuRevision_Click(object sender, EventArgs e) { Abrir(new FrmRevisionRequerimiento()); }
        private void mnuCompra_Click(object sender, EventArgs e) { Abrir(new FrmCompra()); }
        private void mnuRecepcion_Click(object sender, EventArgs e) { Abrir(new FrmRecepcion()); }
        private void mnuDiferencias_Click(object sender, EventArgs e) { Abrir(new FrmDiferencia()); }

        private void mnuProductos_Click(object sender, EventArgs e) { Abrir(new FrmProducto()); }
        private void mnuInsumos_Click(object sender, EventArgs e) { Abrir(new FrmInsumo()); }
        private void mnuProveedores_Click(object sender, EventArgs e) { Abrir(new FrmProveedor()); }
        private void mnuMesas_Click(object sender, EventArgs e) { Abrir(new FrmMesa()); }
        private void mnuTrabajadores_Click(object sender, EventArgs e) { Abrir(new FrmTrabajador()); }
        private void mnuUnidades_Click(object sender, EventArgs e) { Abrir(new FrmUnidadMedida()); }
        private void mnuUsuarios_Click(object sender, EventArgs e) { Abrir(new FrmUsuario()); }

        private void mnuConsultaPedidos_Click(object sender, EventArgs e) { Abrir(new FrmConsultaPedidos()); }
        private void mnuConsultaCobros_Click(object sender, EventArgs e) { Abrir(new FrmConsultaCobros()); }
        private void mnuConsultaAbastecimiento_Click(object sender, EventArgs e) { Abrir(new FrmConsultaAbastecimiento()); }

        #endregion apertura de pantallas

        #region sesion

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Util.Confirmar("Desea cerrar la sesion?"))
            {
                logUsuario.Instancia.CerrarSesion();
                Close();
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            if (Util.Confirmar("Desea salir del sistema?"))
            {
                logUsuario.Instancia.CerrarSesion();
                Application.Exit();
            }
        }

        #endregion sesion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
