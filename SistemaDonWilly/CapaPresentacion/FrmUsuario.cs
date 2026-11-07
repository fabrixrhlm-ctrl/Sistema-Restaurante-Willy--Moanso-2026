using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Administrar usuarios y perfiles (CUS-18 / RF-11). La contrasena
    /// almacenada nunca se muestra y debe quedar al menos un administrador activo.
    /// </summary>
    public partial class FrmUsuario : Form
    {
        private List<entUsuario> _usuarios = new List<entUsuario>();
        private List<entPerfil> _perfiles = new List<entPerfil>();
        private bool _nuevo;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        #region carga

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                cboTrabajador.DataSource = logTrabajador.Instancia.ListarActivos();
                cboTrabajador.DisplayMember = "nombreCompleto";
                cboTrabajador.ValueMember = "idTrabajador";

                _perfiles = logUsuario.Instancia.ListarPerfiles();
                clbPerfiles.Items.Clear();

                foreach (entPerfil p in _perfiles)
                {
                    clbPerfiles.Items.Add(p);
                }

                Listar();
                ModoLectura();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
                Close();
            }
        }

        /// <summary>B2: usuarios, trabajadores y perfiles asignados.</summary>
        private void Listar()
        {
            _usuarios = logUsuario.Instancia.Listar();
            dgvLista.DataSource = null;
            dgvLista.DataSource = _usuarios;
            Util.FormatearGrilla(dgvLista, "idUsuario", "nomUsuario", "trabajador",
                "perfilesTexto", "estUsuario");
            Util.Encabezado(dgvLista, "nomUsuario", "Usuario");
            Util.Encabezado(dgvLista, "perfilesTexto", "Perfiles");
            Util.Encabezado(dgvLista, "estUsuario", "Activo");
        }

        #endregion carga

        #region acciones

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            _nuevo = true;
            ModoEdicion();
        }

        /// <summary>A1: actualizacion de perfiles o de contrasena.</summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            entUsuario u = Seleccionado();

            if (u == null)
            {
                Util.Advertir("Seleccione un usuario de la lista.");
                return;
            }

            cboTrabajador.SelectedValue = u.idTrabajador;
            txtUsuario.Text = u.nomUsuario;
            txtClave.Text = string.Empty;
            txtConfirmar.Text = string.Empty;
            MarcarPerfiles(logUsuario.Instancia.ListarPerfilesDe(u.idUsuario));

            _nuevo = false;
            ModoEdicion();
            cboTrabajador.Enabled = false;
        }

        /// <summary>B4: valida la asignacion y registra el acceso.</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClave.Text != txtConfirmar.Text)
                {
                    Util.Advertir("La contrasena y su confirmacion no coinciden.");
                    return;
                }

                entUsuario u = new entUsuario();
                u.idTrabajador = Util.AEntero(cboTrabajador.SelectedValue);
                u.nomUsuario = txtUsuario.Text.Trim();
                u.perfiles = PerfilesMarcados();

                if (_nuevo)
                {
                    logUsuario.Instancia.Insertar(u, txtClave.Text);
                    Util.Informar("Usuario registrado.");
                }
                else
                {
                    u.idUsuario = Seleccionado().idUsuario;
                    logUsuario.Instancia.Editar(u, txtClave.Text);
                    Util.Informar("Registro guardado.");
                }

                Listar();
                ModoLectura();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A3: impedimentos como el ultimo administrador activo
            }
        }

        /// <summary>A2: bloquea el acceso conservando el historial.</summary>
        private void btnEstado_Click(object sender, EventArgs e)
        {
            entUsuario u = Seleccionado();

            if (u == null)
            {
                Util.Advertir("Seleccione un usuario de la lista.");
                return;
            }

            string accion = u.estUsuario ? "desactivar" : "activar";

            if (!Util.Confirmar("Desea " + accion + " el acceso de " + u.nomUsuario + "?"))
            {
                return;
            }

            try
            {
                if (u.estUsuario)
                {
                    logUsuario.Instancia.Deshabilitar(u.idUsuario);
                }
                else
                {
                    logUsuario.Instancia.Habilitar(u.idUsuario);
                }

                Listar();
                ModoLectura();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoLectura();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar_Click(sender, EventArgs.Empty);
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            entUsuario u = Seleccionado();

            if (u != null && !grpDatos.Enabled)
            {
                btnEstado.Text = u.estUsuario ? "Desactivar" : "Activar";
            }
        }

        #endregion acciones

        #region apoyo

        private entUsuario Seleccionado()
        {
            return dgvLista.CurrentRow == null
                ? null
                : dgvLista.CurrentRow.DataBoundItem as entUsuario;
        }

        private List<entPerfil> PerfilesMarcados()
        {
            List<entPerfil> seleccionados = new List<entPerfil>();

            foreach (object item in clbPerfiles.CheckedItems)
            {
                seleccionados.Add((entPerfil)item);
            }
            return seleccionados;
        }

        private void MarcarPerfiles(List<entPerfil> asignados)
        {
            for (int i = 0; i < clbPerfiles.Items.Count; i++)
            {
                entPerfil actual = (entPerfil)clbPerfiles.Items[i];
                bool marcado = false;

                foreach (entPerfil p in asignados)
                {
                    if (p.idPerfil == actual.idPerfil)
                    {
                        marcado = true;
                        break;
                    }
                }
                clbPerfiles.SetItemChecked(i, marcado);
            }
        }

        private void Limpiar()
        {
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtConfirmar.Text = string.Empty;
            MarcarPerfiles(new List<entPerfil>());
        }

        private void ModoEdicion()
        {
            grpDatos.Enabled = true;
            cboTrabajador.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnEstado.Enabled = false;
            dgvLista.Enabled = false;
        }

        private void ModoLectura()
        {
            grpDatos.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnEstado.Enabled = true;
            dgvLista.Enabled = true;
            Limpiar();
        }

        #endregion apoyo
    }
}
