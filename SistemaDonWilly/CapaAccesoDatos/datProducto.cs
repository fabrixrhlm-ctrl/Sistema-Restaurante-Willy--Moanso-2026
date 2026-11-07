using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos del mantenedor de productos de la carta (CUS-12 / RF-07).</summary>
    public class datProducto
    {
        #region singleton

        private static readonly datProducto _instancia = new datProducto();

        private datProducto()
        {
        }

        public static datProducto Instancia
        {
            get { return datProducto._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entProducto> Listar()
        {
            return Ejecutar("spListarProducto", null, null);
        }

        public List<entProducto> ListarActivos()
        {
            return Ejecutar("spListarProductoActivo", null, null);
        }

        public List<entProducto> Buscar(string texto)
        {
            return Ejecutar("spBuscarProducto", "@texto", texto);
        }

        public int Insertar(entProducto obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obj.nombre);
            cmd.Parameters.AddWithValue("@tipoProducto", obj.tipoProducto);
            cmd.Parameters.AddWithValue("@precio", obj.precio);
            cmd.Parameters.AddWithValue("@disponible", obj.disponible);
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

        public void Editar(entProducto obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", obj.idProducto);
            cmd.Parameters.AddWithValue("@nombre", obj.nombre);
            cmd.Parameters.AddWithValue("@tipoProducto", obj.tipoProducto);
            cmd.Parameters.AddWithValue("@precio", obj.precio);
            cmd.Parameters.AddWithValue("@disponible", obj.disponible);
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

        public void Deshabilitar(int idProducto)
        {
            EjecutarEstado("spDeshabilitarProducto", idProducto);
        }

        public void Habilitar(int idProducto)
        {
            EjecutarEstado("spHabilitarProducto", idProducto);
        }

        #endregion metodos

        #region privados

        private List<entProducto> Ejecutar(string procedimiento, string parametro, object valor)
        {
            List<entProducto> lista = new List<entProducto>();
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
            cmd.Parameters.AddWithValue("@idProducto", id);

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

        private entProducto Mapear(IDataRecord dr)
        {
            entProducto obj = new entProducto();
            obj.idProducto = Lectura.Entero(dr, "idProducto");
            obj.nombre = Lectura.Texto(dr, "nombre");
            obj.tipoProducto = Lectura.Texto(dr, "tipoProducto");
            obj.precio = Lectura.Decimal(dr, "precio");
            obj.disponible = Lectura.Logico(dr, "disponible");
            obj.estProducto = Lectura.Logico(dr, "estProducto");
            return obj;
        }

        #endregion privados
    }
}
