using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos del mantenedor de proveedores (CUS-14 / RF-09).</summary>
    public class datProveedor
    {
        #region singleton

        private static readonly datProveedor _instancia = new datProveedor();

        private datProveedor()
        {
        }

        public static datProveedor Instancia
        {
            get { return datProveedor._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entProveedor> Listar()
        {
            return Ejecutar("spListarProveedor", null, null);
        }

        public List<entProveedor> ListarActivos()
        {
            return Ejecutar("spListarProveedorActivo", null, null);
        }

        public List<entProveedor> Buscar(string texto)
        {
            return Ejecutar("spBuscarProveedor", "@texto", texto);
        }

        public int Insertar(entProveedor obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarProveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@razonSocial", obj.razonSocial);
            cmd.Parameters.AddWithValue("@documento", obj.documento);
            cmd.Parameters.AddWithValue("@direccion", obj.direccion);
            cmd.Parameters.AddWithValue("@telefono", obj.telefono);
            try
            {
                cn.Open();
                object resultado = cmd.ExecuteScalar();
                return resultado == null ? 0 : Convert.ToInt32(resultado);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Editar(entProveedor obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarProveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProveedor", obj.idProveedor);
            cmd.Parameters.AddWithValue("@razonSocial", obj.razonSocial);
            cmd.Parameters.AddWithValue("@documento", obj.documento);
            cmd.Parameters.AddWithValue("@direccion", obj.direccion);
            cmd.Parameters.AddWithValue("@telefono", obj.telefono);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }

        public void Deshabilitar(int idProveedor)
        {
            EjecutarEstado("spDeshabilitarProveedor", idProveedor);
        }

        public void Habilitar(int idProveedor)
        {
            EjecutarEstado("spHabilitarProveedor", idProveedor);
        }

        #endregion metodos

        #region privados

        private List<entProveedor> Ejecutar(string procedimiento, string parametro, object valor)
        {
            List<entProveedor> lista = new List<entProveedor>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand(procedimiento, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parametro != null)
            {
                cmd.Parameters.AddWithValue(parametro, valor);
            }

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Mapear(dr));
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        private void EjecutarEstado(string procedimiento, int id)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand(procedimiento, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProveedor", id);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }
        }

        private entProveedor Mapear(IDataRecord dr)
        {
            entProveedor obj = new entProveedor();
            obj.idProveedor = Lectura.Entero(dr, "idProveedor");
            obj.razonSocial = Lectura.Texto(dr, "razonSocial");
            obj.documento = Lectura.Texto(dr, "documento");
            obj.direccion = Lectura.Texto(dr, "direccion");
            obj.telefono = Lectura.Texto(dr, "telefono");
            obj.estProveedor = Lectura.Logico(dr, "estProveedor");
            return obj;
        }

        #endregion privados
    }
}
