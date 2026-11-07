using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Registrar compra de insumos (CUS-09 / RF-05). Vincula la compra con un
    /// requerimiento revisado y un proveedor, admite varias compras por
    /// requerimiento y conserva el precio aplicado.
    /// </summary>
    public partial class FrmCompra : Form
    {
        private BindingList<entDetalleCompra> _detalle = new BindingList<entDetalleCompra>();
        private List<entAvanceRequerimiento> _avance = new List<entAvanceRequerimiento>();

        public FrmCompra()
        {
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = _detalle;
                Util.FormatearGrilla(dgvDetalle, "insumo", "unidad", "cantidad", "precioUnitario", "subtotal");
                Util.FormatoMoneda(dgvDetalle, "precioUnitario", "subtotal");
                Util.Encabezado(dgvDetalle, "precioUnitario", "Precio unit. (S/)");
                Util.Encabezado(dgvDetalle, "subtotal", "Subtotal (S/)");
                CargarListas();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void CargarListas()
        {
            cboRequerimiento.DataSource = logAbastecimiento.Instancia.ListarRequerimientosRevisados();
            cboRequerimiento.DisplayMember = "descripcion";
            cboRequerimiento.ValueMember = "idRequerimiento";

            cboProveedor.DataSource = logProveedor.Instancia.ListarActivos();
            cboProveedor.DisplayMember = "razonSocial";
            cboProveedor.ValueMember = "idProveedor";

            cboInsumo.DataSource = logInsumo.Instancia.ListarActivos();
            cboInsumo.DisplayMember = "nombre";
            cboInsumo.ValueMember = "idInsumo";

            MostrarAvance();
        }

        /// <summary>B2: cantidades solicitadas y compras acumuladas del requerimiento.</summary>
        private void cboRequerimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarAvance();
        }

        private void MostrarAvance()
        {
            int id = Util.AEntero(cboRequerimiento.SelectedValue);

            if (id <= 0)
            {
                _avance = new List<entAvanceRequerimiento>();
                dgvAvance.DataSource = null;
                return;
            }

            try
            {
                _avance = logAbastecimiento.Instancia.ListarAvance(id);
                dgvAvance.DataSource = null;
                dgvAvance.DataSource = _avance;
                Util.FormatearGrilla(dgvAvance, "insumo", "unidad", "cantSolicitada", "comprado", "pendiente");
                Util.Encabezado(dgvAvance, "cantSolicitada", "Solicitado");
                Util.Encabezado(dgvAvance, "comprado", "Comprado acumulado");
                Util.Encabezado(dgvAvance, "pendiente", "Pendiente de compra");
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            entInsumo i = cboInsumo.SelectedItem as entInsumo;

            if (i == null)
            {
                Util.Advertir("Seleccione un insumo.");
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                Util.Advertir("La cantidad comprada debe ser mayor que cero.");
                return;
            }

            foreach (entDetalleCompra existente in _detalle)
            {
                if (existente.idInsumo == i.idInsumo)
                {
                    Util.Advertir("El insumo " + i.nombre + " ya esta en la compra.");
                    return;
                }
            }

            entDetalleCompra d = new entDetalleCompra();
            d.idInsumo = i.idInsumo;
            d.insumo = i.nombre;
            d.idUnidad = i.idUnidad;
            d.unidad = i.unidad;
            d.cantidad = nudCantidad.Value;
            d.precioUnitario = nudPrecio.Value;
            d.subtotal = Math.Round(d.cantidad * d.precioUnitario, 2);
            _detalle.Add(d);

            nudCantidad.Value = 0;
            nudPrecio.Value = 0;
            ActualizarTotal();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                _detalle.Remove((entDetalleCompra)dgvDetalle.CurrentRow.DataBoundItem);
                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            decimal total = 0;

            foreach (entDetalleCompra d in _detalle)
            {
                total += d.subtotal;
            }
            lblTotal.Text = total.ToString("N2");
        }

        /// <summary>
        /// B4: compara lo comprado con lo pendiente del requerimiento.
        /// Devuelve el texto de las diferencias o vacio si coinciden.
        /// </summary>
        private string CalcularDiferencias()
        {
            StringBuilder sb = new StringBuilder();

            foreach (entDetalleCompra d in _detalle)
            {
                entAvanceRequerimiento a = _avance.Find(x => x.idInsumo == d.idInsumo);

                if (a == null)
                {
                    sb.AppendLine("- " + d.insumo + ": no figura en el requerimiento.");
                }
                else if (d.cantidad != a.pendiente)
                {
                    sb.AppendLine("- " + d.insumo + ": se compra " + d.cantidad.ToString("N2") + " " + d.unidad +
                        " y quedaban " + a.pendiente.ToString("N2") + " " + a.unidad + " por comprar.");
                }
            }
            return sb.ToString();
        }

        /// <summary>B5-B6: confirma la compra; una diferencia sin justificar exige observacion (A2).</summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string diferencias = CalcularDiferencias();

                entCompra c = new entCompra();
                c.idRequerimiento = Util.AEntero(cboRequerimiento.SelectedValue);
                c.idProveedor = Util.AEntero(cboProveedor.SelectedValue);
                c.fecCompra = dtpFecha.Value.Date;
                c.documento = txtDocumento.Text.Trim();
                c.observacion = txtObservacion.Text.Trim();
                c.detalles = new List<entDetalleCompra>(_detalle);

                bool hayDiferencias = diferencias.Length > 0;

                if (hayDiferencias && c.observacion.Length == 0)
                {
                    Util.Advertir("La compra difiere de lo solicitado:" + Environment.NewLine + diferencias +
                        Environment.NewLine + "Escriba la observacion que lo justifica.");
                    txtObservacion.Focus();
                    return;
                }

                if (!Util.Confirmar("Confirmar la compra por S/ " + lblTotal.Text + "?"))
                {
                    return;
                }

                int numero = logAbastecimiento.Instancia.RegistrarCompra(c, hayDiferencias);
                Util.Informar("Compra registrada. Numero: " + numero);

                _detalle.Clear();
                txtDocumento.Text = string.Empty;
                txtObservacion.Text = string.Empty;
                ActualizarTotal();
                MostrarAvance();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A1: datos por corregir
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarListas();
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
