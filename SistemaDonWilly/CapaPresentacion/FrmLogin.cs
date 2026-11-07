using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Inicio de sesion. RNF-01 exige una sesion autenticada antes de
    /// cualquier operacion y RNF-02 que la clave no viaje en texto legible.
    /// </summary>
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblTitulo.Text = "Sistema Don Willy";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            Cursor = Cursors.WaitCursor;

            try
            {
                logUsuario.Instancia.Autenticar(txtUsuario.Text, txtClave.Text);

                Hide();
                using (FrmPrincipal principal = new FrmPrincipal())
                {
                    principal.ShowDialog();
                }

                txtClave.Text = string.Empty;
                txtUsuario.Focus();
                Show();
            }
            catch (ReglaNegocioException ex)
            {
                lblMensaje.Text = ex.Message;
                txtClave.Text = string.Empty;
                txtClave.Focus();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se pudo conectar con la base de datos.";
                Util.Error(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
