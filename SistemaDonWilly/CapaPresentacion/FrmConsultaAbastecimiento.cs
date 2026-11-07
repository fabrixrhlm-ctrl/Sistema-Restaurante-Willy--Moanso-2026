using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Consultar abastecimiento (CUS-21 / RF-16). Muestra por requerimiento e insumo
    /// lo solicitado, comprado y aceptado, y sus pendientes y diferencias.
    /// </summary>
    public partial class FrmConsultaAbastecimiento : Form
    {
        private const string TODOS = "(Todos)";

        public FrmConsultaAbastecimiento()
        {
            InitializeComponent();
        }

        private void FrmConsultaAbastecimiento_Load(object sender, EventArgs e)
        {
            try
            {
                entRequerimiento todosReq = new entRequerimiento();
                todosReq.idRequerimiento = 0;
                todosReq.semana = TODOS;
                List<entRequerimiento> reqs = new List<entRequerimiento>();
                reqs.Add(todosReq);
                reqs.AddRange(logAbastecimiento.Instancia.ListarRequerimientos(null));
                cboRequerimiento.DataSource = reqs;
                cboRequerimiento.DisplayMember = "descripcion";
                cboRequerimiento.ValueMember = "idRequerimiento";

                entProveedor todosProv = new entProveedor();
                todosProv.idProveedor = 0;
                todosProv.razonSocial = TODOS;
                List<entProveedor> provs = new List<entProveedor>();
                provs.Add(todosProv);
                provs.AddRange(logProveedor.Instancia.Listar());
                cboProveedor.DataSource = provs;
                cboProveedor.DisplayMember = "razonSocial";
                cboProveedor.ValueMember = "idProveedor";

                cboDiferencia.Items.Add(TODOS);
                cboDiferencia.Items.Add("PENDIENTE");
                cboDiferencia.Items.Add("REGULARIZADO");
                cboDiferencia.SelectedIndex = 0;

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
                string dif = Convert.ToString(cboDiferencia.SelectedItem);
                List<entConsultaAbastecimiento> lista = logConsulta.Instancia.ConsultarAbastecimiento(
                    Util.AEntero(cboRequerimiento.SelectedValue),
                    Util.AEntero(cboProveedor.SelectedValue),
                    dif == TODOS ? null : dif);

                dgvResultados.DataSource = null;
                dgvResultados.DataSource = lista;
                Util.FormatearGrilla(dgvResultados, "semana", "insumo", "unidad", "requerido", "comprado",
                    "aceptado", "pendienteCompra", "pendienteRecepcion", "difPendientes", "difRegularizadas");
                Util.Encabezado(dgvResultados, "requerido", "Requerido");
                Util.Encabezado(dgvResultados, "pendienteCompra", "Pendiente de compra");
                Util.Encabezado(dgvResultados, "pendienteRecepcion", "Pendiente de recepcion");
                Util.Encabezado(dgvResultados, "difPendientes", "Dif. pendientes");
                Util.Encabezado(dgvResultados, "difRegularizadas", "Dif. regularizadas");

                lblResumen.Text = lista.Count == 0
                    ? "No se encontraron registros."
                    : lista.Count + " insumo(s) en el resultado.";
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
