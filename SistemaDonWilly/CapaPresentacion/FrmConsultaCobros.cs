using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Consultar cobros (CUS-20 / RF-15). El total recaudado suma los importes
    /// aplicados y excluye el vuelto. No es un reporte contable ni tributario.
    /// </summary>
    public partial class FrmConsultaCobros : Form
    {
        private const string TODOS = "(Todos)";

        public FrmConsultaCobros()
        {
            InitializeComponent();
        }

        private void FrmConsultaCobros_Load(object sender, EventArgs e)
        {
            try
            {
                cboMedio.Items.Add(TODOS);
                cboMedio.Items.Add("EFECTIVO");
                cboMedio.Items.Add("YAPE");
                cboMedio.SelectedIndex = 0;

                List<entTrabajador> cajeras = new List<entTrabajador>();
                entTrabajador todas = new entTrabajador();
                todas.idTrabajador = 0;
                todas.nombres = TODOS;
                todas.apellidos = string.Empty;
                cajeras.Add(todas);
                cajeras.AddRange(logTrabajador.Instancia.ListarActivos());

                cboCajera.DataSource = cajeras;
                cboCajera.DisplayMember = "nombreCompleto";
                cboCajera.ValueMember = "idTrabajador";

                dtpDesde.Value = DateTime.Today.AddDays(-7);
                dtpHasta.Value = DateTime.Today;
                Consultar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                string medio = Convert.ToString(cboMedio.SelectedItem);
                List<entConsultaCobro> lista = logConsulta.Instancia.ConsultarCobros(
                    dtpDesde.Value, dtpHasta.Value, medio == TODOS ? null : medio,
                    Util.AEntero(cboCajera.SelectedValue));

                dgvResultados.DataSource = null;
                dgvResultados.DataSource = lista;
                Util.FormatearGrilla(dgvResultados, "idPedido", "fecPago", "modalidad", "importe",
                    "medioPago", "referencia", "cajera");
                Util.FormatoMoneda(dgvResultados, "importe");
                Util.Encabezado(dgvResultados, "idPedido", "Pedido");
                Util.Encabezado(dgvResultados, "fecPago", "Fecha de pago");
                Util.Encabezado(dgvResultados, "importe", "Importe aplicado (S/)");
                Util.Encabezado(dgvResultados, "medioPago", "Medio");

                lblTotal.Text = logConsulta.Instancia.TotalRecaudado(lista).ToString("N2");

                if (lista.Count == 0)
                {
                    Util.Informar("No se encontraron registros.");
                }
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
