using System;
using System.Windows.Forms;
using CapaAccesoDatos;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>Punto de entrada: comprueba la conexion y abre el inicio de sesion.</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string mensaje;

            if (!Conexion.Instancia.ProbarConexion(out mensaje))
            {
                MessageBox.Show(
                    "No se pudo conectar con SQL Server." + Environment.NewLine + Environment.NewLine +
                    mensaje + Environment.NewLine + Environment.NewLine +
                    "Revise la cadena de conexion en App.config y que la base BD_DonWilly exista.",
                    Util.TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
