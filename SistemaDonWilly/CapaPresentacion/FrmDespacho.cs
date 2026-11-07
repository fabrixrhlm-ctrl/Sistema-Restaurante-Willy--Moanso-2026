using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Registrar despacho (CUS-05 / RF-02). La mesera revisa platos y bebidas
    /// contra lo confirmado; si hay diferencias devuelve el pedido a cocina.
    /// </summary>
    public partial class FrmDespacho : Form
    {
        public FrmDespacho()
        {
            InitializeComponent();
        }

        private void FrmDespacho_Load(object sender, EventArgs e)
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

        private void Listar()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = logPedido.Instancia.ListarPedidosParaDespacho();
            Util.FormatearGrilla(dgvPedidos, "idPedido", "modalidad", "mesa", "fecRegistro",
                "estPago", "total");
            Util.FormatoMoneda(dgvPedidos, "total");
            Util.Encabezado(dgvPedidos, "idPedido", "Nro.");
            Util.Encabezado(dgvPedidos, "fecRegistro", "Registrado");
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

        /// <summary>B2: productos y cantidades confirmados.</summary>
        private void MostrarSeleccion()
        {
            entPedido p = Seleccionado();
            btnEntrega.Enabled = p != null;
            btnCorreccion.Enabled = p != null;
            txtDiferencia.Text = string.Empty;

            if (p == null)
            {
                dgvDetalle.DataSource = null;
                return;
            }

            dgvDetalle.DataSource = logPedido.Instancia.ListarDetalle(p.idPedido);
            Util.FormatearGrilla(dgvDetalle, "producto", "tipoProducto", "cantidad");
            Util.Encabezado(dgvDetalle, "tipoProducto", "Tipo");
        }

        /// <summary>B3-B4: conformidad y entrega; el estado de pago no se altera.</summary>
        private void btnEntrega_Click(object sender, EventArgs e)
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                return;
            }

            if (!Util.Confirmar("Confirma que el pedido " + p.idPedido +
                " fue revisado y entregado conforme?"))
            {
                return;
            }

            try
            {
                logPedido.Instancia.RegistrarDespacho(p.idPedido);
                Util.Informar("Entrega registrada.");
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>A1: registra la diferencia y deja el pedido por corregir.</summary>
        private void btnCorreccion_Click(object sender, EventArgs e)
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                return;
            }

            try
            {
                logPedido.Instancia.SolicitarCorreccion(p.idPedido, txtDiferencia.Text);
                Util.Informar("El pedido volvio a cocina para su correccion.");
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
