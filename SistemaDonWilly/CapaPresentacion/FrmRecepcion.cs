using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Registrar recepcion de insumos (CUS-10 / RF-06) con el registro de
    /// diferencias (CUS-23, extension condicional). Admite recepciones parciales:
    /// lo no recibido queda pendiente.
    /// </summary>
    public partial class FrmRecepcion : Form
    {
        private BindingList<entDetalleRecepcion> _detalle = new BindingList<entDetalleRecepcion>();

        public FrmRecepcion()
        {
            InitializeComponent();
        }

        private void FrmRecepcion_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = _detalle;
                FormatearDetalle();
                CargarCompras();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void FormatearDetalle()
        {
            Util.FormatearGrilla(dgvDetalle, "insumo", "unidad", "cantComprada", "cantAceptadaAcum",
                "pendiente", "cantRecibida", "cantAceptada", "cantObservada", "motivo");
            Util.Encabezado(dgvDetalle, "cantComprada", "Comprado");
            Util.Encabezado(dgvDetalle, "cantAceptadaAcum", "Aceptado antes");
            Util.Encabezado(dgvDetalle, "pendiente", "Pendiente");
            Util.Encabezado(dgvDetalle, "cantRecibida", "Recibido ahora");
            Util.Encabezado(dgvDetalle, "cantAceptada", "Aceptado ahora");
            Util.Encabezado(dgvDetalle, "cantObservada", "Observado");
            Util.Encabezado(dgvDetalle, "motivo", "Motivo de la diferencia");

            foreach (DataGridViewColumn columna in dgvDetalle.Columns)
            {
                columna.ReadOnly = columna.Name != "cantRecibida" && columna.Name != "cantAceptada"
                                   && columna.Name != "motivo";
            }

            dgvDetalle.Columns["cantRecibida"].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
            dgvDetalle.Columns["cantAceptada"].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
            dgvDetalle.Columns["motivo"].DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
        }

        private void CargarCompras()
        {
            cboCompra.DataSource = logAbastecimiento.Instancia.ListarComprasPendientesRecepcion();
            cboCompra.DisplayMember = "descripcion";
            cboCompra.ValueMember = "idCompra";
            MostrarDetalle();
        }

        private void cboCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDetalle();
        }

        /// <summary>B2: detalles de la compra con sus cantidades pendientes de aceptacion.</summary>
        private void MostrarDetalle()
        {
            _detalle.Clear();
            int idCompra = Util.AEntero(cboCompra.SelectedValue);
            btnConfirmar.Enabled = idCompra > 0;

            if (idCompra <= 0)
            {
                return;
            }

            try
            {
                foreach (entDetalleRecepcion d in logAbastecimiento.Instancia.ListarDetalleCompraPendiente(idCompra))
                {
                    if (d.pendiente > 0)
                    {
                        _detalle.Add(d);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>B3: el observado se calcula; aceptado mas observado equivale a recibido.</summary>
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            entDetalleRecepcion d = _detalle[e.RowIndex];

            if (d.cantRecibida < 0)
            {
                d.cantRecibida = 0;
            }

            if (d.cantAceptada > d.cantRecibida)
            {
                Util.Advertir("Lo aceptado no puede superar lo recibido (" + d.insumo + ").");
                d.cantAceptada = d.cantRecibida;
            }

            if (d.cantAceptada > d.pendiente)
            {
                Util.Advertir("No se puede aceptar mas de lo comprado pendiente (" + d.insumo + ").");
                d.cantAceptada = d.pendiente;
            }

            d.cantObservada = d.cantRecibida - d.cantAceptada;
            _detalle.ResetItem(e.RowIndex);
        }

        /// <summary>B4-B6: valida, compara con la compra, pide los motivos y confirma.</summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDetalle.EndEdit();

                entRecepcion r = new entRecepcion();
                r.idCompra = Util.AEntero(cboCompra.SelectedValue);
                r.fecRecepcion = dtpFecha.Value.Date;
                r.observacion = txtObservacion.Text.Trim();
                r.detalles = new List<entDetalleRecepcion>();

                foreach (entDetalleRecepcion d in _detalle)
                {
                    if (d.cantRecibida > 0)
                    {
                        r.detalles.Add(d);
                    }
                }

                // CUS-23: las diferencias se detectan despues de validar las cantidades
                int diferencias = 0;

                foreach (entDetalleRecepcion d in r.detalles)
                {
                    if (d.cantObservada > 0)
                    {
                        diferencias++;
                    }
                }

                if (!Util.Confirmar(diferencias > 0
                    ? "Se detectaron " + diferencias + " diferencia(s) que quedaran pendientes de regularizacion. Confirmar la recepcion?"
                    : "Confirmar la recepcion?"))
                {
                    return;
                }

                int numero = logAbastecimiento.Instancia.RegistrarRecepcion(r);
                Util.Informar("Recepcion registrada. Numero: " + numero);

                txtObservacion.Text = string.Empty;
                CargarCompras();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A2 y CUS-23 A1: cantidades inconsistentes o motivo faltante
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarCompras();
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
