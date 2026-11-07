using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos del mantenedor de insumos (CUS-13 / RF-08).</summary>
    public class datInsumo
    {
        #region singleton

        private static readonly datInsumo _instancia = new datInsumo();

        private datInsumo()
        {
        }

        public static datInsumo Instancia
        {
            get { return datInsumo._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entInsumo> Listar()
        {
            return Ejecutar("spListarInsumo", null, null);
        }

        public List<entInsumo> ListarActivos()
        {
            return Ejecutar("spListarInsumoActivo", null, null);
        }

        public List<entInsumo> Buscar(string texto)
        {
            return Ejecutar("spBuscarInsumo", "@texto", texto);
        }

        public int Insertar(entInsumo obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarInsumo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obj.nombre);
            cmd.Parameters.AddWithValue("@idUnidad", obj.idUnidad);
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

        public void Editar(entInsumo obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarInsumo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idInsumo", obj.idInsumo);
            cmd.Parameters.AddWithValue("@nombre", obj.nombre);
            cmd.Parameters.AddWithValue("@idUnidad", obj.idUnidad);
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

        public void Deshabilitar(int idInsumo)
        {
            EjecutarEstado("spDeshabilitarInsumo", idInsumo);
        }

        public void Habilitar(int idInsumo)
        {
            EjecutarEstado("spHabilitarInsumo", idInsumo);
        }

        #endregion metodos

        #region privados

        private List<entInsumo> Ejecutar(string procedimiento, string parametro, object valor)
        {
            List<entInsumo> lista = new List<entInsumo>();
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
            cmd.Parameters.AddWithValue("@idInsumo", id);

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

        private entInsumo Mapear(IDataRecord dr)
        {
            entInsumo obj = new entInsumo();
            obj.idInsumo = Lectura.Entero(dr, "idInsumo");
            obj.nombre = Lectura.Texto(dr, "nombre");
            obj.idUnidad = Lectura.Entero(dr, "idUnidad");
            obj.unidad = Lectura.Texto(dr, "unidad");
            obj.estInsumo = Lectura.Logico(dr, "estInsumo");
            return obj;
        }

        #endregion privados
    }
}
