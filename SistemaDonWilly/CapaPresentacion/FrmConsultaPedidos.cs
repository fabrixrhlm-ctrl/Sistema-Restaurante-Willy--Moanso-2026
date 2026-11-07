using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Consultar pedidos (CUS-19 / RF-10). Filtra por fecha, modalidad, estado
    /// de atencion y estado de pago sin alterar informacion operativa.
    /// </summary>
    public partial class FrmConsultaPedidos : Form
    {
        private const string TODOS = "(Todos)";

        public FrmConsultaPedidos()
        {
            InitializeComponent();
        }

        private void FrmConsultaPedidos_Load(object sender, EventArgs e)
        {
            Llenar(cboModalidad, "MESA", "LLEVAR");
            Llenar(cboAtencion, "SIN_INICIAR", "PREPARACION", "LISTO", "POR_CORREGIR", "ENTREGADO");
            Llenar(cboPago, "PENDIENTE", "PARCIAL", "PAGADO");

            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
            Consultar();
        }

        private void Llenar(ComboBox combo, params string[] valores)
        {
            combo.Items.Add(TODOS);

            foreach (string v in valores)
            {
                combo.Items.Add(v);
            }
            combo.SelectedIndex = 0;
        }

        private string Valor(ComboBox combo)
        {
            string v = Convert.ToString(combo.SelectedItem);
            return v == TODOS ? null : v;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        /// <summary>B3-B4: valida los filtros y presenta las coincidencias o el aviso correspondiente.</summary>
        private void Consultar()
        {
            try
            {
                List<entConsultaPedido> lista = logConsulta.Instancia.ConsultarPedidos(
                    dtpDesde.Value, dtpHasta.Value, Valor(cboModalidad), Valor(cboAtencion), Valor(cboPago));

                dgvResultados.DataSource = null;
                dgvResultados.DataSource = lista;
                Util.FormatearGrilla(dgvResultados, "idPedido", "fecRegistro", "modalidad", "mesa",
                    "productos", "total", "saldo", "estAtencion", "estPago", "responsable");
                Util.FormatoMoneda(dgvResultados, "total", "saldo");
                Util.Encabezado(dgvResultados, "idPedido", "Nro.");
                Util.Encabezado(dgvResultados, "fecRegistro", "Fecha");
                Util.Encabezado(dgvResultados, "total", "Total (S/)");
                Util.Encabezado(dgvResultados, "saldo", "Saldo (S/)");
                Util.Encabezado(dgvResultados, "estAtencion", "Atencion");
                Util.Encabezado(dgvResultados, "estPago", "Pago");

                if (dgvResultados.Columns.Contains("productos"))
                {
                    dgvResultados.Columns["productos"].FillWeight = 220;
                }

                lblResumen.Text = lista.Count == 0
                    ? "No se encontraron registros."
                    : lista.Count + " pedido(s) encontrado(s).";
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A1: filtros invalidos
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
