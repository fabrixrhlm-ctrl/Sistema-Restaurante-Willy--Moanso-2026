using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Elaborar requerimiento semanal (CUS-07 / RF-04). El encargado de almacen
    /// registra el conteo fisico con su fecha, las necesidades de cocina y las
    /// cantidades por adquirir. Admite borrador (A2) y correccion de devueltos (A3).
    /// </summary>
    public partial class FrmRequerimiento : Form
    {
        private BindingList<entDetalleRequerimiento> _detalle = new BindingList<entDetalleRequerimiento>();
        private List<entInsumo> _insumos = new List<entInsumo>();
        private int _idEnCorreccion;

        public FrmRequerimiento()
        {
            InitializeComponent();
        }

        private void FrmRequerimiento_Load(object sender, EventArgs e)
        {
            try
            {
                _insumos = logInsumo.Instancia.ListarActivos();
                cboInsumo.DataSource = _insumos;
                cboInsumo.DisplayMember = "nombre";
                cboInsumo.ValueMember = "idInsumo";

                dgvDetalle.DataSource = _detalle;
                Util.FormatearGrilla(dgvDetalle, "insumo", "unidad", "cantUtilizable",
                    "cantNecesidad", "cantSolicitada");
                Util.Encabezado(dgvDetalle, "cantUtilizable", "Utilizable (conteo)");
                Util.Encabezado(dgvDetalle, "cantNecesidad", "Necesidad prevista");
                Util.Encabezado(dgvDetalle, "cantSolicitada", "Cantidad a solicitar");

                dtpConteo.MaxDate = DateTime.Today;
                dtpConteo.Value = DateTime.Today;
                txtSemana.Text = SemanaActual();
                cboInsumo_SelectedIndexChanged(null, EventArgs.Empty);
                ListarPropios();
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private string SemanaActual()
        {
            System.Globalization.Calendar cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int semana = cal.GetWeekOfYear(DateTime.Today,
                System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return DateTime.Today.Year + "-S" + semana.ToString("00");
        }

        /// <summary>B2: muestra los insumos con su unidad de medida.</summary>
        private void cboInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            entInsumo i = cboInsumo.SelectedItem as entInsumo;
            lblUnidad.Text = i == null ? "-" : i.unidad;
        }

        private void ListarPropios()
        {
            List<entRequerimiento> lista = new List<entRequerimiento>();
            lista.AddRange(logAbastecimiento.Instancia.ListarRequerimientos("BORRADOR"));
            lista.AddRange(logAbastecimiento.Instancia.ListarRequerimientos("DEVUELTO"));

            dgvMios.DataSource = null;
            dgvMios.DataSource = lista;
            Util.FormatearGrilla(dgvMios, "idRequerimiento", "semana", "fecConteo", "estRequerimiento", "insumos");
            Util.Encabezado(dgvMios, "idRequerimiento", "Nro.");
            Util.Encabezado(dgvMios, "fecConteo", "Conteo");
            Util.Encabezado(dgvMios, "estRequerimiento", "Estado");
            Util.Encabezado(dgvMios, "insumos", "Insumos");
            MostrarObservacion();
        }

        private entRequerimiento Propio()
        {
            return dgvMios.CurrentRow == null
                ? null
                : dgvMios.CurrentRow.DataBoundItem as entRequerimiento;
        }

        private void dgvMios_SelectionChanged(object sender, EventArgs e)
        {
            MostrarObservacion();
        }

        private void MostrarObservacion()
        {
            entRequerimiento r = Propio();
            lblObservacion.Text = r != null && r.estRequerimiento == "DEVUELTO"
                ? "Observaciones del administrador: " + r.observacion
                : string.Empty;
            btnCorregir.Enabled = r != null;
        }

        /// <summary>B3: agrega un insumo; la unidad es la del catalogo y no se mezclan unidades.</summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            entInsumo i = cboInsumo.SelectedItem as entInsumo;

            if (i == null)
            {
                Util.Advertir("Seleccione un insumo.");
                return;
            }

            if (nudSolicitada.Value <= 0)
            {
                Util.Advertir("La cantidad a solicitar debe ser mayor que cero.");
                return;
            }

            foreach (entDetalleRequerimiento existente in _detalle)
            {
                if (existente.idInsumo == i.idInsumo)
                {
                    Util.Advertir("El insumo " + i.nombre + " ya esta en el requerimiento.");
                    return;
                }
            }

            entDetalleRequerimiento d = new entDetalleRequerimiento();
            d.idInsumo = i.idInsumo;
            d.insumo = i.nombre;
            d.idUnidad = i.idUnidad;
            d.unidad = i.unidad;
            d.cantUtilizable = nudUtilizable.Value;
            d.cantNecesidad = nudNecesidad.Value;
            d.cantSolicitada = nudSolicitada.Value;
            _detalle.Add(d);

            nudUtilizable.Value = 0;
            nudNecesidad.Value = 0;
            nudSolicitada.Value = 0;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null)
            {
                _detalle.Remove((entDetalleRequerimiento)dgvDetalle.CurrentRow.DataBoundItem);
            }
        }

        private entRequerimiento Armar()
        {
            entRequerimiento r = new entRequerimiento();
            r.idRequerimiento = _idEnCorreccion;
            r.semana = txtSemana.Text;
            r.fecConteo = dtpConteo.Value.Date;
            r.detalles = new List<entDetalleRequerimiento>(_detalle);
            return r;
        }

        /// <summary>B3-B5: valida y envia el requerimiento al administrador.</summary>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Guardar(true);
        }

        /// <summary>A2: conserva el borrador sin habilitar compras.</summary>
        private void btnBorrador_Click(object sender, EventArgs e)
        {
            Guardar(false);
        }

        private void Guardar(bool enviar)
        {
            try
            {
                entRequerimiento r = Armar();

                if (_idEnCorreccion > 0)
                {
                    logAbastecimiento.Instancia.ActualizarRequerimiento(r, enviar);
                    Util.Informar(enviar
                        ? "Requerimiento " + _idEnCorreccion + " corregido y enviado a revision."
                        : "Borrador actualizado.");
                }
                else
                {
                    int numero = logAbastecimiento.Instancia.RegistrarRequerimiento(r, enviar);
                    Util.Informar(enviar
                        ? "Requerimiento enviado al administrador. Numero: " + numero
                        : "Borrador guardado. Numero: " + numero);
                }

                Nuevo();
                ListarPropios();
            }
            catch (Exception ex)
            {
                Util.Error(ex);   // A1: senala los detalles que deben corregirse
            }
        }

        /// <summary>A3: presenta las observaciones y los detalles del requerimiento devuelto.</summary>
        private void btnCorregir_Click(object sender, EventArgs e)
        {
            entRequerimiento r = Propio();

            if (r == null)
            {
                return;
            }

            try
            {
                _detalle.Clear();

                foreach (entDetalleRequerimiento d in logAbastecimiento.Instancia.ListarDetalle(r.idRequerimiento))
                {
                    _detalle.Add(d);
                }

                _idEnCorreccion = r.idRequerimiento;
                txtSemana.Text = r.semana;
                dtpConteo.Value = r.fecConteo > dtpConteo.MaxDate ? DateTime.Today : r.fecConteo;
                lblEstado.Text = "Corrigiendo requerimiento " + r.idRequerimiento;
            }
            catch (Exception ex)
            {
                Util.Error(ex);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            _detalle.Clear();
            _idEnCorreccion = 0;
            txtSemana.Text = SemanaActual();
            dtpConteo.Value = DateTime.Today;
            lblEstado.Text = "Requerimiento nuevo";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
