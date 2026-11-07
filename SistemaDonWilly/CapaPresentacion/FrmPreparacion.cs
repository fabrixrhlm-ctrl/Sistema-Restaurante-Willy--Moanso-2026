using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Actualizar preparacion (CUS-04 / RF-02). Solo aparecen pedidos en mesa
    /// confirmados y pedidos para llevar con pago completo. El software registra
    /// el avance; la elaboracion fisica corresponde a cocina.
    /// </summary>
    public partial class FrmPreparacion : Form
    {
        public FrmPreparacion()
        {
            InitializeComponent();
        }

        private void FrmPreparacion_Load(object sender, EventArgs e)
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

        /// <summary>B2: pedidos habilitados segun modalidad y pago.</summary>
        private void Listar()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = logPedido.Instancia.ListarPedidosParaPreparar();
            Util.FormatearGrilla(dgvPedidos, "idPedido", "modalidad", "mesa", "fecRegistro",
                "estAtencion", "estPago", "total");
            Util.FormatoMoneda(dgvPedidos, "total");
            Util.Encabezado(dgvPedidos, "idPedido", "Nro.");
            Util.Encabezado(dgvPedidos, "fecRegistro", "Registrado");
            Util.Encabezado(dgvPedidos, "estAtencion", "Estado de atencion");
            Util.Encabezado(dgvPedidos, "estPago", "Estado de pago");
            Util.Encabezado(dgvPedidos, "total", "Total (S/)");
            MostrarSeleccion();
        }

        private entPedido Seleccionado()
        {
            return dgvPedidos.CurrentRow == null
                ? null
                : dgvPedidos.CurrentRow.DataBoundItem as entPedido;
        }

        private void dgvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccion();
        }

        private void MostrarSeleccion()
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                dgvDetalle.DataSource = null;
                btnIniciar.Enabled = false;
                btnListo.Enabled = false;
                lblAyuda.Text = "No hay pedidos habilitados para preparar.";
                return;
            }

            dgvDetalle.DataSource = logPedido.Instancia.ListarDetalle(p.idPedido);
            Util.FormatearGrilla(dgvDetalle, "producto", "tipoProducto", "cantidad");
            Util.Encabezado(dgvDetalle, "tipoProducto", "Tipo");

            bool enPreparacion = p.estAtencion == "PREPARACION";
            btnIniciar.Enabled = !enPreparacion;
            btnListo.Enabled = enPreparacion;
            btnIniciar.Text = p.estAtencion == "POR_CORREGIR" ? "Iniciar correccion" : "Iniciar preparacion";

            lblAyuda.Text = p.estAtencion == "POR_CORREGIR"
                ? "La mesera encontro diferencias. Corrija el pedido y vuelva a marcarlo como listo."
                : enPreparacion
                    ? "Marque el pedido como listo al terminar la preparacion fisica."
                    : "Inicie la preparacion del pedido seleccionado.";
        }

        /// <summary>B3-B4 y A2: registra el estado en preparacion.</summary>
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                return;
            }

            try
            {
                logPedido.Instancia.IniciarPreparacion(p.idPedido);
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>B5-B6: registra el pedido listo para revision.</summary>
        private void btnListo_Click(object sender, EventArgs e)
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                return;
            }

            try
            {
                logPedido.Instancia.MarcarListo(p.idPedido);
                Util.Informar("Pedido " + p.idPedido + " listo para revision.");
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
