using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Registrar cobro (CUS-06 / RF-03) con el calculo de saldo CUS-22, que se
    /// ejecuta siempre al seleccionar el pedido. El vuelto no es ingreso y
    /// Yape se verifica manualmente.
    /// </summary>
    public partial class FrmCobro : Form
    {
        public FrmCobro()
        {
            InitializeComponent();
            nudRecibido.ValueChanged += new EventHandler(CalcularVuelto);
            nudImporte.ValueChanged += new EventHandler(CalcularVuelto);
        }

        private void FrmCobro_Load(object sender, EventArgs e)
        {
            try
            {
                cboMedio.Items.Add("EFECTIVO");
                cboMedio.Items.Add("YAPE");
                cboMedio.SelectedIndex = 0;
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>B1: pedidos por cobrar (mesa entregada o para llevar confirmado).</summary>
        private void Listar()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = logPedido.Instancia.ListarPedidosPorCobrar();
            Util.FormatearGrilla(dgvPedidos, "idPedido", "modalidad", "mesa", "estPago", "total", "saldo");
            Util.FormatoMoneda(dgvPedidos, "total", "saldo");
            Util.Encabezado(dgvPedidos, "idPedido", "Nro.");
            Util.Encabezado(dgvPedidos, "estPago", "Estado de pago");
            Util.Encabezado(dgvPedidos, "total", "Total (S/)");
            Util.Encabezado(dgvPedidos, "saldo", "Saldo (S/)");
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

        /// <summary>B2 y CUS-22: muestra consumo completo, total, pagos y saldo.</summary>
        private void MostrarSeleccion()
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                dgvDetalle.DataSource = null;
                dgvPagos.DataSource = null;
                lblTotal.Text = "0.00";
                lblPagado.Text = "0.00";
                lblSaldo.Text = "0.00";
                lblVuelto.Text = "0.00";
                grpCobro.Enabled = false;
                return;
            }

            try
            {
                dgvDetalle.DataSource = logPedido.Instancia.ListarDetalle(p.idPedido);
                Util.FormatearGrilla(dgvDetalle, "producto", "tipoProducto", "cantidad",
                    "precioAplicado", "subtotal");
                Util.FormatoMoneda(dgvDetalle, "precioAplicado", "subtotal");
                Util.Encabezado(dgvDetalle, "tipoProducto", "Tipo");
                Util.Encabezado(dgvDetalle, "precioAplicado", "Precio (S/)");
                Util.Encabezado(dgvDetalle, "subtotal", "Subtotal (S/)");

                dgvPagos.DataSource = logPedido.Instancia.ListarPagos(p.idPedido);
                Util.FormatearGrilla(dgvPagos, "fecPago", "importe", "medioPago", "vuelto", "cajera");
                Util.FormatoMoneda(dgvPagos, "importe", "vuelto");
                Util.Encabezado(dgvPagos, "fecPago", "Fecha");
                Util.Encabezado(dgvPagos, "importe", "Importe (S/)");
                Util.Encabezado(dgvPagos, "medioPago", "Medio");
                Util.Encabezado(dgvPagos, "vuelto", "Vuelto (S/)");

                entSaldoPedido s = logPedido.Instancia.CalcularSaldo(p.idPedido);   // CUS-22
                lblTotal.Text = s.total.ToString("N2");
                lblPagado.Text = s.pagado.ToString("N2");
                lblSaldo.Text = s.saldo.ToString("N2");

                if (s.saldo <= 0)
                {
                    grpCobro.Enabled = false;   // A1 de CUS-22
                    Util.Informar("El pedido ya esta pagado.");
                    return;
                }

                grpCobro.Enabled = true;
                nudImporte.Maximum = s.saldo;
                nudImporte.Value = s.saldo;
                nudRecibido.Value = s.saldo;
                CalcularVuelto(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void cboMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool efectivo = Convert.ToString(cboMedio.SelectedItem) == "EFECTIVO";
            nudRecibido.Enabled = efectivo;
            lblRecibido.Enabled = efectivo;
            lblVuelto.Enabled = efectivo;
            lblVueltoTxt.Enabled = efectivo;
            txtReferencia.Enabled = !efectivo;
            lblReferencia.Enabled = !efectivo;
            lblNotaYape.Visible = !efectivo;
            CalcularVuelto(null, EventArgs.Empty);
        }

        /// <summary>B4: determina el vuelto; no se considera ingreso.</summary>
        private void CalcularVuelto(object sender, EventArgs e)
        {
            if (Convert.ToString(cboMedio.SelectedItem) != "EFECTIVO")
            {
                lblVuelto.Text = "0.00";
                return;
            }

            decimal vuelto = nudRecibido.Value - nudImporte.Value;
            lblVuelto.Text = (vuelto > 0 ? vuelto : 0).ToString("N2");
        }

        /// <summary>B5-B6: confirma el cobro; un pago parcial deja el saldo pendiente (A3).</summary>
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            entPedido p = Seleccionado();

            if (p == null)
            {
                return;
            }

            string medio = Convert.ToString(cboMedio.SelectedItem);

            if (!Util.Confirmar("Se verifico el pago de S/ " + nudImporte.Value.ToString("N2") +
                " con " + medio + "?"))
            {
                return;   // A1: pago no verificado, no se registra ingreso
            }

            try
            {
                entPago pago = new entPago();
                pago.idPedido = p.idPedido;
                pago.importe = nudImporte.Value;
                pago.medioPago = medio;
                pago.montoRecibido = nudRecibido.Value;
                pago.referencia = txtReferencia.Text.Trim();

                entSaldoPedido r = logPedido.Instancia.RegistrarCobro(pago);

                string mensaje = "Cobro registrado." + Environment.NewLine +
                    "Saldo pendiente: S/ " + r.saldo.ToString("N2");

                if (r.vuelto > 0)
                {
                    mensaje += Environment.NewLine + "Vuelto: S/ " + r.vuelto.ToString("N2");
                }

                if (r.saldo <= 0 && p.modalidad == "LLEVAR")
                {
                    mensaje += Environment.NewLine + "El pedido para llevar queda habilitado para preparacion.";
                }

                Util.Informar(mensaje);
                txtReferencia.Text = string.Empty;
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A2: revise el importe y el saldo pendiente
                MostrarSeleccion();
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
