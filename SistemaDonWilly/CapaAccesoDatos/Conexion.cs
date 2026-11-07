using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    /// <summary>
    /// Punto unico de conexion con SQL Server (patron Singleton).
    /// La cadena se lee de App.config para no exponerla en el codigo (RNF-02).
    /// </summary>
    public class Conexion
    {
        #region singleton

        private static readonly Conexion _instancia = new Conexion();

        private Conexion()
        {
        }

        public static Conexion Instancia
        {
            get { return _instancia; }
        }

        #endregion singleton

        #region metodos

        /// <summary>Devuelve una conexion cerrada lista para abrirse.</summary>
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = ObtenerCadena();
            return cn;
        }

        /// <summary>Cadena de conexion configurada en App.config.</summary>
        public string ObtenerCadena()
        {
            ConnectionStringSettings cfg = ConfigurationManager.ConnectionStrings["BD_DonWilly"];

            if (cfg != null && !string.IsNullOrEmpty(cfg.ConnectionString))
            {
                return cfg.ConnectionString;
            }

            // Valor de respaldo para un equipo con instancia local.
            return "Data Source=.;Initial Catalog=BD_DonWilly;Integrated Security=true;";
        }

        /// <summary>Comprueba que el servidor responda (iteracion 2 del plan).</summary>
        public bool ProbarConexion(out string mensaje)
        {
            mensaje = string.Empty;
            SqlConnection cn = null;
            try
            {
                cn = Conectar();
                cn.Open();
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
            finally
            {
                if (cn != null && cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        #endregion metodos
    }
}
