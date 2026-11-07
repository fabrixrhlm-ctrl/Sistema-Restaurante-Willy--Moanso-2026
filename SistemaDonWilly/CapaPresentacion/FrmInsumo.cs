using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Mantenedor de insumos y su unidad de medida (CUS-13 / RF-08).
    /// Flujo basico B1-B6 y alternativos A1 modificar, A2 baja logica,
    /// A3 busqueda y A4 datos invalidos.
    /// </summary>
    public partial class FrmInsumo : Form
    {
        private List<entInsumo> _registros = new List<entInsumo>();
        private bool _editando;
        private bool _nuevo;

        public FrmInsumo()
        {
            InitializeComponent();
        }

        #region carga

        private void FrmInsumo_Load(object sender, EventArgs e)
        {
            try
            {
                cboUnidad.DataSource = logUnidadMedida.Instancia.ListarActivas();
                cboUnidad.DisplayMember = "nombre";
                cboUnidad.ValueMember = "idUnidad";
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
            _registros = logInsumo.Instancia.Listar();
            MostrarEnGrilla();
        }

        private void MostrarEnGrilla()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = _registros;
            Util.FormatearGrilla(dgvLista, "idInsumo", "nombre", "unidad", "estInsumo");
            lblEstadoRegistro.Text = _registros.Count + " registro(s)";
        }

        #endregion carga

        #region acciones

        /// <summary>A3: busqueda por criterio; informa cuando no hay coincidencias.</summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _registros = logInsumo.Instancia.Buscar(txtBuscar.Text);
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
            entInsumo obj = Seleccionado();

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
                entInsumo obj = LeerCampos();

                if (_nuevo)
                {
                    logInsumo.Instancia.Insertar(obj);
                }
                else
                {
                    obj.idInsumo = Seleccionado().idInsumo;
                    logInsumo.Instancia.Editar(obj);
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
            entInsumo obj = Seleccionado();

            if (obj == null)
            {
                Util.Advertir("Seleccione un registro de la lista.");
                return;
            }

            bool activo = obj.estInsumo;
            string accion = activo ? "desactivar" : "activar";

            if (!Util.Confirmar("Desea " + accion + " el registro seleccionado?"))
            {
                return;
            }

            try
            {
                if (activo)
                {
                    logInsumo.Instancia.Deshabilitar(obj.idInsumo);
                }
                else
                {
                    logInsumo.Instancia.Habilitar(obj.idInsumo);
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
            entInsumo obj = Seleccionado();

            if (obj != null && !_editando)
            {
                btnEstado.Text = obj.estInsumo ? "Desactivar" : "Activar";
            }
        }

        #endregion acciones

        #region apoyo

        private entInsumo Seleccionado()
        {
            if (dgvLista.CurrentRow == null)
            {
                return null;
            }
            return dgvLista.CurrentRow.DataBoundItem as entInsumo;
        }

        private entInsumo LeerCampos()
        {
            entInsumo obj = new entInsumo();
            obj.nombre = txtNombre.Text.Trim();
            obj.idUnidad = Util.AEntero(cboUnidad.SelectedValue);
            return obj;
        }

        private void MostrarEnCampos(entInsumo obj)
        {
            txtNombre.Text = obj.nombre;
            cboUnidad.SelectedValue = obj.idUnidad;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            cboUnidad.SelectedIndex = cboUnidad.Items.Count > 0 ? 0 : -1;
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
