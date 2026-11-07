using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Registrar y confirmar solicitudes (CUS-01 / CUS-03 / RF-01).
    /// La mesera registra las solicitudes en mesa y la cajera las de para llevar.
    /// </summary>
    public partial class FrmSolicitud : Form
    {
        private BindingList<entDetallePedido> _carrito = new BindingList<entDetallePedido>();
        private List<entProducto> _productos = new List<entProducto>();
        private int _idPedidoEnCambio;   // A1 de CUS-03: pedido cuyo contenido se modifica

        public FrmSolicitud()
        {
            InitializeComponent();
            rbMesa.CheckedChanged += new EventHandler(ModalidadCambiada);
        }

        #region carga

        private void FrmSolicitud_Load(object sender, EventArgs e)
        {
            try
            {
                _productos = logProducto.Instancia.ListarDisponibles();   // ACT-01
                cboProducto.DataSource = _productos;
                cboProducto.DisplayMember = "nombre";
                cboProducto.ValueMember = "idProducto";

                cboMesa.DataSource = logMesa.Instancia.ListarActivas();
                cboMesa.DisplayMember = "codigo";
                cboMesa.ValueMember = "idMesa";

                // La mesera atiende en mesa y la cajera los pedidos para llevar
                bool soloCajera = entSesion.TienePerfil(entSesion.PERFIL_CAJERA)
                                  && !entSesion.TienePerfil(entSesion.PERFIL_MESERA);
                bool soloMesera = entSesion.TienePerfil(entSesion.PERFIL_MESERA)
                                  && !entSesion.TienePerfil(entSesion.PERFIL_CAJERA);

                if (soloCajera)
                {
                    rbLlevar.Checked = true;
                    rbMesa.Enabled = false;
                }
                else if (soloMesera)
                {
                    rbMesa.Checked = true;
                    rbLlevar.Enabled = false;
                }

                dgvCarrito.DataSource = _carrito;
                Util.FormatearGrilla(dgvCarrito, "producto", "cantidad", "precioAplicado", "subtotal");
                Util.FormatoMoneda(dgvCarrito, "precioAplicado", "subtotal");
                Util.Encabezado(dgvCarrito, "precioAplicado", "Precio (S/)");
                Util.Encabezado(dgvCarrito, "subtotal", "Subtotal (S/)");

                ModalidadCambiada(null, EventArgs.Empty);
                ListarRespondidas();
                ActualizarTotal();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void ListarRespondidas()
        {
            dgvRespondidas.DataSource = null;
            dgvRespondidas.DataSource = logPedido.Instancia.ListarSolicitudesRespondidas();
            Util.FormatearGrilla(dgvRespondidas, "idPedido", "modalidad", "mesa", "total", "resultado");
            Util.FormatoMoneda(dgvRespondidas, "total");
            Util.Encabezado(dgvRespondidas, "idPedido", "Nro.");
            Util.Encabezado(dgvRespondidas, "total", "Total (S/)");
            MostrarRespuesta();
        }

        #endregion carga

        #region CUS-01  registrar solicitud

        private void ModalidadCambiada(object sender, EventArgs e)
        {
            cboMesa.Enabled = rbMesa.Checked;
            lblMesa.Enabled = rbMesa.Checked;
        }

        /// <summary>B3: indica productos y cantidades; el precio vigente se aplica al pedido.</summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            entProducto p = cboProducto.SelectedItem as entProducto;

            if (p == null)
            {
                Util.Advertir("Seleccione un producto.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;

            foreach (entDetallePedido existente in _carrito)
            {
                if (existente.idProducto == p.idProducto)
                {
                    existente.cantidad += cantidad;
                    _carrito.ResetBindings();
                    ActualizarTotal();
                    return;
                }
            }

            entDetallePedido d = new entDetallePedido();
            d.idProducto = p.idProducto;
            d.producto = p.nombre;
            d.tipoProducto = p.tipoProducto;
            d.cantidad = cantidad;
            d.precioAplicado = p.precio;
            _carrito.Add(d);
            ActualizarTotal();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                return;
            }

            _carrito.Remove((entDetallePedido)dgvCarrito.CurrentRow.DataBoundItem);
            ActualizarTotal();
        }

        /// <summary>B3-B5: envia la solicitud a cocina, o el cambio de una ya respondida.</summary>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                entPedido p = new entPedido();
                p.modalidad = rbMesa.Checked ? "MESA" : "LLEVAR";
                p.idMesa = rbMesa.Checked ? Util.AEntero(cboMesa.SelectedValue) : 0;
                p.detalles = new List<entDetallePedido>(_carrito);

                if (_idPedidoEnCambio > 0)
                {
                    p.idPedido = _idPedidoEnCambio;
                    logPedido.Instancia.ModificarSolicitud(p);
                    Util.Informar("Solicitud " + _idPedidoEnCambio +
                        " modificada. Cocina debe responder nuevamente.");
                }
                else
                {
                    int numero = logPedido.Instancia.RegistrarSolicitud(p);
                    Util.Informar("Solicitud registrada. Numero de pedido: " + numero);
                }

                Reiniciar();
                ListarRespondidas();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A1: revise los productos, las cantidades y la mesa
            }
        }

        /// <summary>A2: cancela y descarta el registro nuevo.</summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        #endregion CUS-01  registrar solicitud

        #region CUS-03  confirmar solicitud

        private entPedido PedidoSeleccionado()
        {
            return dgvRespondidas.CurrentRow == null
                ? null
                : dgvRespondidas.CurrentRow.DataBoundItem as entPedido;
        }

        private void dgvRespondidas_SelectionChanged(object sender, EventArgs e)
        {
            MostrarRespuesta();
        }

        /// <summary>B2: presenta la respuesta de cocina de la solicitud elegida.</summary>
        private void MostrarRespuesta()
        {
            entPedido p = PedidoSeleccionado();

            if (p == null)
            {
                lblRespuesta.Text = "Sin solicitudes respondidas.";
                btnConfirmar.Enabled = false;
                btnModificar.Enabled = false;
                btnDesistir.Enabled = false;
                return;
            }

            bool favorable = p.resultado == "FAVORABLE";
            lblRespuesta.Text = favorable
                ? "Disponibilidad completa."
                : "Faltantes: " + p.observacion;
            btnConfirmar.Enabled = favorable;
            btnModificar.Enabled = true;
            btnDesistir.Enabled = true;
        }

        /// <summary>B3-B5: registra la aceptacion del cliente y confirma el pedido.</summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            entPedido p = PedidoSeleccionado();

            if (p == null)
            {
                return;
            }

            try
            {
                logPedido.Instancia.ConfirmarSolicitud(p.idPedido);
                string aviso = p.modalidad == "MESA"
                    ? "Pedido " + p.idPedido + " confirmado. Cocina puede iniciar la preparacion."
                    : "Pedido " + p.idPedido + " confirmado. Queda pendiente de pago previo.";
                Util.Informar(aviso);
                ListarRespondidas();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A3: se requiere una respuesta favorable de cocina
            }
        }

        /// <summary>A1: carga el contenido para que el cliente cambie productos o cantidades.</summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            entPedido p = PedidoSeleccionado();

            if (p == null)
            {
                return;
            }

            try
            {
                entPedido completo = logPedido.Instancia.Obtener(p.idPedido);
                _carrito.Clear();

                foreach (entDetallePedido d in completo.detalles)
                {
                    _carrito.Add(d);
                }

                _idPedidoEnCambio = completo.idPedido;
                rbMesa.Checked = completo.modalidad == "MESA";
                rbLlevar.Checked = completo.modalidad == "LLEVAR";
                rbMesa.Enabled = false;
                rbLlevar.Enabled = false;
                cboMesa.Enabled = false;
                grpNueva.Text = "  Cambio de la solicitud " + completo.idPedido + "  ";
                btnEnviar.Text = "Enviar cambio a cocina";
                ActualizarTotal();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>A2: el cliente desiste; se cierra sin preparacion ni cobro.</summary>
        private void btnDesistir_Click(object sender, EventArgs e)
        {
            entPedido p = PedidoSeleccionado();

            if (p == null)
            {
                return;
            }

            string motivo = Interaccion.Pedir("Indique el motivo del desistimiento:", "Desistir de la solicitud");

            if (motivo == null)
            {
                return;
            }

            try
            {
                logPedido.Instancia.DesistirSolicitud(p.idPedido, motivo);
                Util.Informar("La solicitud fue cerrada sin preparacion ni cobro.");
                ListarRespondidas();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        #endregion CUS-03  confirmar solicitud

        #region apoyo

        private void ActualizarTotal()
        {
            decimal total = 0;

            foreach (entDetallePedido d in _carrito)
            {
                total += d.subtotal;
            }
            lblTotal.Text = total.ToString("N2");
        }

        private void Reiniciar()
        {
            _carrito.Clear();
            _idPedidoEnCambio = 0;
            nudCantidad.Value = 1;
            grpNueva.Text = "  Nueva solicitud (CUS-01)  ";
            btnEnviar.Text = "Enviar a cocina";

            bool soloCajera = entSesion.TienePerfil(entSesion.PERFIL_CAJERA)
                              && !entSesion.TienePerfil(entSesion.PERFIL_MESERA);
            bool soloMesera = entSesion.TienePerfil(entSesion.PERFIL_MESERA)
                              && !entSesion.TienePerfil(entSesion.PERFIL_CAJERA);

            rbMesa.Enabled = !soloCajera;
            rbLlevar.Enabled = !soloMesera;
            ModalidadCambiada(null, EventArgs.Empty);
            ActualizarTotal();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ListarRespondidas();
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

        #endregion apoyo
    }
}
