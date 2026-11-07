using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Responder disponibilidad (CUS-02 / RF-01). El personal de cocina comprueba
    /// fisicamente los productos; el sistema solo conserva su respuesta.
    /// </summary>
    public partial class FrmDisponibilidad : Form
    {
        public FrmDisponibilidad()
        {
            InitializeComponent();
            rbFaltantes.CheckedChanged += new EventHandler(RespuestaCambiada);
        }

        private void FrmDisponibilidad_Load(object sender, EventArgs e)
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

        /// <summary>B1: solicitudes pendientes de respuesta.</summary>
        private void Listar()
        {
            dgvPendientes.DataSource = null;
            dgvPendientes.DataSource = logPedido.Instancia.ListarSolicitudesPendientes();
            Util.FormatearGrilla(dgvPendientes, "idPedido", "modalidad", "mesa", "fecRegistro",
                "total", "registradoPor");
            Util.FormatoMoneda(dgvPendientes, "total");
            Util.Encabezado(dgvPendientes, "idPedido", "Nro.");
            Util.Encabezado(dgvPendientes, "fecRegistro", "Registrado");
            Util.Encabezado(dgvPendientes, "total", "Total (S/)");
            Util.Encabezado(dgvPendientes, "registradoPor", "Registrado por");
            MostrarDetalle();
        }

        private entPedido Seleccionado()
        {
            return dgvPendientes.CurrentRow == null
                ? null
                : dgvPendientes.CurrentRow.DataBoundItem as entPedido;
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalle();
        }

        /// <summary>B2: productos y cantidades solicitados.</summary>
        private void MostrarDetalle()
        {
            entPedido p = Seleccionado();
            btnResponder.Enabled = p != null;

            if (p == null)
            {
                dgvDetalle.DataSource = null;
                return;
            }

            dgvDetalle.DataSource = logPedido.Instancia.ListarDetalle(p.idPedido);
            Util.FormatearGrilla(dgvDetalle, "producto", "tipoProducto", "cantidad");
            Util.Encabezado(dgvDetalle, "tipoProducto", "Tipo");
        }

        private void RespuestaCambiada(object sender, EventArgs e)
        {
            txtObservacion.Enabled = rbFaltantes.Checked;
            lblObs.Enabled = rbFaltantes.Checked;

            if (!rbFaltantes.Checked)
            {
                txtObservacion.Text = string.Empty;
            }
        }

        /// <summary>B3-B4 y A1: registra disponibilidad completa o faltantes con alternativas.</summary>
        private void btnResponder_Click(object sender, EventArgs e)
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                Util.Advertir("Seleccione una solicitud pendiente.");
                return;
            }

            try
            {
                logPedido.Instancia.ResponderDisponibilidad(p.idPedido, rbFavorable.Checked,
                    txtObservacion.Text);

                Util.Informar("Respuesta registrada. La solicitud sigue sin confirmar.");
                rbFavorable.Checked = true;
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
