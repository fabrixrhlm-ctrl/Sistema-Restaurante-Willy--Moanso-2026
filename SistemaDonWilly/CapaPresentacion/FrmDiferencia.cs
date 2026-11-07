using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Regularizar diferencia de recepcion (CUS-11 / RF-06). Documenta la solucion
    /// sin modificar las cantidades historicas de la recepcion.
    /// </summary>
    public partial class FrmDiferencia : Form
    {
        public FrmDiferencia()
        {
            InitializeComponent();
        }

        private void FrmDiferencia_Load(object sender, EventArgs e)
        {
            try
            {
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>B1: diferencias pendientes con su compra, recepcion y proveedor.</summary>
        private void Listar()
        {
            dgvDiferencias.DataSource = null;
            dgvDiferencias.DataSource = logAbastecimiento.Instancia.ListarDiferenciasPendientes();
            Util.FormatearGrilla(dgvDiferencias, "idDiferencia", "idCompra", "idRecepcion", "fecRecepcion",
                "insumo", "unidad", "cantObservada", "proveedor");
            Util.Encabezado(dgvDiferencias, "idDiferencia", "Nro.");
            Util.Encabezado(dgvDiferencias, "idCompra", "Compra");
            Util.Encabezado(dgvDiferencias, "idRecepcion", "Recepcion");
            Util.Encabezado(dgvDiferencias, "fecRecepcion", "Fecha de recepcion");
            Util.Encabezado(dgvDiferencias, "cantObservada", "Cantidad observada");
            MostrarSeleccion();
        }

        private entDiferenciaRecepcion Seleccionada()
        {
            return dgvDiferencias.CurrentRow == null
                ? null
                : dgvDiferencias.CurrentRow.DataBoundItem as entDiferenciaRecepcion;
        }

        private void dgvDiferencias_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccion();
        }

        /// <summary>B2: muestra compra, recepcion y motivo.</summary>
        private void MostrarSeleccion()
        {
            entDiferenciaRecepcion d = Seleccionada();
            grpRegularizar.Enabled = d != null;
            lblMotivo.Text = d == null ? "-" : d.motivo;
            txtSolucion.Text = string.Empty;
            txtSustento.Text = string.Empty;
            dtpFecha.Value = DateTime.Today;
        }

        /// <summary>B3-B4 y A2: valida el sustento y conserva la regularizacion con su responsable.</summary>
        private void btnRegularizar_Click(object sender, EventArgs e)
        {
            entDiferenciaRecepcion d = Seleccionada();

            if (d == null)
            {
                return;
            }

            try
            {
                d.solucion = txtSolucion.Text.Trim();
                d.sustento = txtSustento.Text.Trim();
                d.fecRegularizacion = dtpFecha.Value.Date;

                logAbastecimiento.Instancia.RegularizarDiferencia(d);
                Util.Informar("Diferencia regularizada. Las cantidades de la recepcion no se modifican.");
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
