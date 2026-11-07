using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Mantenedor de trabajadores del restaurante (CUS-16 / RF-13).
    /// Flujo basico B1-B6 y alternativos A1 modificar, A2 baja logica,
    /// A3 busqueda y A4 datos invalidos.
    /// </summary>
    public partial class FrmTrabajador : Form
    {
        private List<entTrabajador> _registros = new List<entTrabajador>();
        private bool _editando;
        private bool _nuevo;

        public FrmTrabajador()
        {
            InitializeComponent();
        }

        #region carga

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            try
            {
                Listar();
                ModoLectura();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>B2: muestra la lista de registros y su estado.</summary>
        private void Listar()
        {
            _registros = logTrabajador.Instancia.Listar();
            MostrarEnGrilla();
        }

        private void MostrarEnGrilla()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = _registros;
            Util.FormatearGrilla(dgvLista, "idTrabajador", "documento", "nombres", "apellidos", "cargo", "telefono", "estTrabajador");
            lblEstadoRegistro.Text = _registros.Count + " registro(s)";
        }

        #endregion carga

        #region acciones

        /// <summary>A3: busqueda por criterio; informa cuando no hay coincidencias.</summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _registros = logTrabajador.Instancia.Buscar(txtBuscar.Text);
                MostrarEnGrilla();

                if (_registros.Count == 0)
                {
                    Util.Informar("No se encontraron registros.");
                }
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Text = string.Empty;
                Listar();
                ModoLectura();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>B3-B4: habilita el panel para un registro nuevo.</summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            _nuevo = true;
            ModoEdicion();
        }

        /// <summary>A1: presenta los datos del registro seleccionado.</summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            entTrabajador obj = Seleccionado();

            if (obj == null)
            {
                Util.Advertir("Seleccione un registro de la lista.");
                return;
            }

            MostrarEnCampos(obj);
            _nuevo = false;
            ModoEdicion();
        }

        /// <summary>B5-B6: valida y registra la informacion.</summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entTrabajador obj = LeerCampos();

                if (_nuevo)
                {
                    logTrabajador.Instancia.Insertar(obj);
                }
                else
                {
                    obj.idTrabajador = Seleccionado().idTrabajador;
                    logTrabajador.Instancia.Editar(obj);
                }

                Util.Informar("Registro guardado.");
                Listar();
                ModoLectura();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A4: identifica los datos por corregir
            }
        }

        /// <summary>A2: baja logica que conserva el historial del registro.</summary>
        private void btnEstado_Click(object sender, EventArgs e)
        {
            entTrabajador obj = Seleccionado();

            if (obj == null)
            {
                Util.Advertir("Seleccione un registro de la lista.");
                return;
            }

            bool activo = obj.estTrabajador;
            string accion = activo ? "desactivar" : "activar";

            if (!Util.Confirmar("Desea " + accion + " el registro seleccionado?"))
            {
                return;
            }

            try
            {
                if (activo)
                {
                    logTrabajador.Instancia.Deshabilitar(obj.idTrabajador);
                }
                else
                {
                    logTrabajador.Instancia.Habilitar(obj.idTrabajador);
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
            entTrabajador obj = Seleccionado();

            if (obj != null && !_editando)
            {
                btnEstado.Text = obj.estTrabajador ? "Desactivar" : "Activar";
            }
        }

        #endregion acciones

        #region apoyo

        private entTrabajador Seleccionado()
        {
            if (dgvLista.CurrentRow == null)
            {
                return null;
            }
            return dgvLista.CurrentRow.DataBoundItem as entTrabajador;
        }

        private entTrabajador LeerCampos()
        {
            entTrabajador obj = new entTrabajador();
            obj.documento = txtDocumento.Text.Trim();
            obj.cargo = txtCargo.Text.Trim();
            obj.nombres = txtNombres.Text.Trim();
            obj.apellidos = txtApellidos.Text.Trim();
            obj.telefono = txtTelefono.Text.Trim();
            return obj;
        }

        private void MostrarEnCampos(entTrabajador obj)
        {
            txtDocumento.Text = obj.documento;
            txtCargo.Text = obj.cargo;
            txtNombres.Text = obj.nombres;
            txtApellidos.Text = obj.apellidos;
            txtTelefono.Text = obj.telefono;
        }

        private void LimpiarCampos()
        {
            txtDocumento.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        private void ModoEdicion()
        {
            _editando = true;
            grpDatos.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnEstado.Enabled = false;
            dgvLista.Enabled = false;
        }

        private void ModoLectura()
        {
            _editando = false;
            _nuevo = false;
            grpDatos.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnEstado.Enabled = true;
            dgvLista.Enabled = true;
            LimpiarCampos();
        }

        #endregion apoyo
    }
}
