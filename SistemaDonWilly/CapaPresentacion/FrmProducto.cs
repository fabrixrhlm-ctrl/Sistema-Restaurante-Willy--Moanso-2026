using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Mantenedor de productos de la carta (CUS-12 / RF-07).
    /// Flujo basico B1-B6 y alternativos A1 modificar, A2 baja logica,
    /// A3 busqueda y A4 datos invalidos.
    /// </summary>
    public partial class FrmProducto : Form
    {
        private List<entProducto> _registros = new List<entProducto>();
        private bool _editando;
        private bool _nuevo;

        public FrmProducto()
        {
            InitializeComponent();
        }

        #region carga

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                cboTipo.Items.Add("PLATO");
                cboTipo.Items.Add("MENU");
                cboTipo.Items.Add("BEBIDA");
                cboTipo.SelectedIndex = 0;
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
            _registros = logProducto.Instancia.Listar();
            MostrarEnGrilla();
        }

        private void MostrarEnGrilla()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = _registros;
            Util.FormatearGrilla(dgvLista, "idProducto", "nombre", "tipoProducto", "precio", "disponible", "estProducto");
            Util.FormatoMoneda(dgvLista, "precio");
            lblEstadoRegistro.Text = _registros.Count + " registro(s)";
        }

        #endregion carga

        #region acciones

        /// <summary>A3: busqueda por criterio; informa cuando no hay coincidencias.</summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _registros = logProducto.Instancia.Buscar(txtBuscar.Text);
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
            entProducto obj = Seleccionado();

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
                entProducto obj = LeerCampos();

                if (_nuevo)
                {
                    logProducto.Instancia.Insertar(obj);
                }
                else
                {
                    obj.idProducto = Seleccionado().idProducto;
                    logProducto.Instancia.Editar(obj);
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
            entProducto obj = Seleccionado();

            if (obj == null)
            {
                Util.Advertir("Seleccione un registro de la lista.");
                return;
            }

            bool activo = obj.estProducto;
            string accion = activo ? "desactivar" : "activar";

            if (!Util.Confirmar("Desea " + accion + " el registro seleccionado?"))
            {
                return;
            }

            try
            {
                if (activo)
                {
                    logProducto.Instancia.Deshabilitar(obj.idProducto);
                }
                else
                {
                    logProducto.Instancia.Habilitar(obj.idProducto);
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
            entProducto obj = Seleccionado();

            if (obj != null && !_editando)
            {
                btnEstado.Text = obj.estProducto ? "Desactivar" : "Activar";
            }
        }

        #endregion acciones

        #region apoyo

        private entProducto Seleccionado()
        {
            if (dgvLista.CurrentRow == null)
            {
                return null;
            }
            return dgvLista.CurrentRow.DataBoundItem as entProducto;
        }

        private entProducto LeerCampos()
        {
            entProducto obj = new entProducto();
            obj.nombre = txtNombre.Text.Trim();
            obj.tipoProducto = Convert.ToString(cboTipo.SelectedItem);
            obj.precio = nudPrecio.Value;
            obj.disponible = chkDisponible.Checked;
            return obj;
        }

        private void MostrarEnCampos(entProducto obj)
        {
            txtNombre.Text = obj.nombre;
            cboTipo.SelectedItem = obj.tipoProducto;
            nudPrecio.Value = obj.precio;
            chkDisponible.Checked = obj.disponible;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            cboTipo.SelectedIndex = cboTipo.Items.Count > 0 ? 0 : -1;
            nudPrecio.Value = nudPrecio.Minimum;
            chkDisponible.Checked = true;
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
