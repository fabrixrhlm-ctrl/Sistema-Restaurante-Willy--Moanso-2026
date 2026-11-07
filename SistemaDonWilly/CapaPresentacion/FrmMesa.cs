using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Mantenedor de mesas del local (CUS-15 / RF-12).
    /// Flujo basico B1-B6 y alternativos A1 modificar, A2 baja logica,
    /// A3 busqueda y A4 datos invalidos.
    /// </summary>
    public partial class FrmMesa : Form
    {
        private List<entMesa> _registros = new List<entMesa>();
        private bool _editando;
        private bool _nuevo;

        public FrmMesa()
        {
            InitializeComponent();
        }

        #region carga

        private void FrmMesa_Load(object sender, EventArgs e)
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
            _registros = logMesa.Instancia.Listar();
            MostrarEnGrilla();
        }

        private void MostrarEnGrilla()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = _registros;
            Util.FormatearGrilla(dgvLista, "idMesa", "codigo", "ubicacion", "capacidad", "estMesa");
            lblEstadoRegistro.Text = _registros.Count + " registro(s)";
        }

        #endregion carga

        #region acciones

        /// <summary>A3: busqueda por criterio; informa cuando no hay coincidencias.</summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _registros = logMesa.Instancia.Buscar(txtBuscar.Text);
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
            entMesa obj = Seleccionado();

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
                entMesa obj = LeerCampos();

                if (_nuevo)
                {
                    logMesa.Instancia.Insertar(obj);
                }
                else
                {
                    obj.idMesa = Seleccionado().idMesa;
                    logMesa.Instancia.Editar(obj);
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
            entMesa obj = Seleccionado();

            if (obj == null)
            {
                Util.Advertir("Seleccione un registro de la lista.");
                return;
            }

            bool activo = obj.estMesa;
            string accion = activo ? "desactivar" : "activar";

            if (!Util.Confirmar("Desea " + accion + " el registro seleccionado?"))
            {
                return;
            }

            try
            {
                if (activo)
                {
                    logMesa.Instancia.Deshabilitar(obj.idMesa);
                }
                else
                {
                    logMesa.Instancia.Habilitar(obj.idMesa);
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
            entMesa obj = Seleccionado();

            if (obj != null && !_editando)
            {
                btnEstado.Text = obj.estMesa ? "Desactivar" : "Activar";
            }
        }

        #endregion acciones

        #region apoyo

        private entMesa Seleccionado()
        {
            if (dgvLista.CurrentRow == null)
            {
                return null;
            }
            return dgvLista.CurrentRow.DataBoundItem as entMesa;
        }

        private entMesa LeerCampos()
        {
            entMesa obj = new entMesa();
            obj.codigo = txtCodigo.Text.Trim();
            obj.capacidad = (int)nudCapacidad.Value;
            obj.ubicacion = txtUbicacion.Text.Trim();
            return obj;
        }

        private void MostrarEnCampos(entMesa obj)
        {
            txtCodigo.Text = obj.codigo;
            nudCapacidad.Value = obj.capacidad;
            txtUbicacion.Text = obj.ubicacion;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            nudCapacidad.Value = nudCapacidad.Minimum;
            txtUbicacion.Text = string.Empty;
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
