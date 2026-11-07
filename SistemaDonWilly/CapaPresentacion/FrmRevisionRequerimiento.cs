using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Revisar requerimiento semanal (CUS-08 / RF-04). El administrador da
    /// conformidad, que habilita las compras, o lo devuelve con observaciones.
    /// </summary>
    public partial class FrmRevisionRequerimiento : Form
    {
        public FrmRevisionRequerimiento()
        {
            InitializeComponent();
        }

        private void FrmRevisionRequerimiento_Load(object sender, EventArgs e)
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

        /// <summary>B1: requerimientos pendientes de revision.</summary>
        private void Listar()
        {
            dgvPendientes.DataSource = null;
            dgvPendientes.DataSource = logAbastecimiento.Instancia.ListarRequerimientos("PENDIENTE");
            Util.FormatearGrilla(dgvPendientes, "idRequerimiento", "semana", "fecConteo", "fecRegistro",
                "almacenero", "insumos");
            Util.Encabezado(dgvPendientes, "idRequerimiento", "Nro.");
            Util.Encabezado(dgvPendientes, "fecConteo", "Fecha de conteo");
            Util.Encabezado(dgvPendientes, "fecRegistro", "Enviado");
            Util.Encabezado(dgvPendientes, "insumos", "Insumos");
            MostrarDetalle();
        }

        private entRequerimiento Seleccionado()
        {
            return dgvPendientes.CurrentRow == null
                ? null
                : dgvPendientes.CurrentRow.DataBoundItem as entRequerimiento;
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalle();
        }

        /// <summary>B2: semana, conteo, necesidades, cantidades y unidades.</summary>
        private void MostrarDetalle()
        {
            entRequerimiento r = Seleccionado();
            btnConformidad.Enabled = r != null;
            btnDevolver.Enabled = r != null;
            txtObservacion.Text = string.Empty;

            if (r == null)
            {
                dgvDetalle.DataSource = null;
                return;
            }

            dgvDetalle.DataSource = logAbastecimiento.Instancia.ListarDetalle(r.idRequerimiento);
            Util.FormatearGrilla(dgvDetalle, "insumo", "unidad", "cantUtilizable", "cantNecesidad", "cantSolicitada");
            Util.Encabezado(dgvDetalle, "cantUtilizable", "Utilizable (conteo)");
            Util.Encabezado(dgvDetalle, "cantNecesidad", "Necesidad prevista");
            Util.Encabezado(dgvDetalle, "cantSolicitada", "Cantidad solicitada");
        }

        /// <summary>B3-B4: registra el requerimiento revisado y su responsable.</summary>
        private void btnConformidad_Click(object sender, EventArgs e)
        {
            entRequerimiento r = Seleccionado();

            if (r == null)
            {
                return;
            }

            try
            {
                logAbastecimiento.Instancia.RevisarRequerimiento(r.idRequerimiento, true, txtObservacion.Text);
                Util.Informar("Requerimiento " + r.idRequerimiento + " revisado. Ya puede usarse para compras.");
                Listar();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        /// <summary>A1: devuelve a almacen con observaciones, sin habilitar compras.</summary>
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            entRequerimiento r = Seleccionado();

            if (r == null)
            {
                return;
            }

            try
            {
                logAbastecimiento.Instancia.RevisarRequerimiento(r.idRequerimiento, false, txtObservacion.Text);
                Util.Informar("Requerimiento devuelto al encargado de almacen.");
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
