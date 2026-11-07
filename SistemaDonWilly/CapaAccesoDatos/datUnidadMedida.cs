using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos del mantenedor de unidades de medida (CUS-17 / RF-14).</summary>
    public class datUnidadMedida
    {
        #region singleton

        private static readonly datUnidadMedida _instancia = new datUnidadMedida();

        private datUnidadMedida()
        {
        }

        public static datUnidadMedida Instancia
        {
            get { return datUnidadMedida._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entUnidadMedida> Listar()
        {
            return Ejecutar("spListarUnidad", null, null);
        }

        public List<entUnidadMedida> ListarActivos()
        {
            return Ejecutar("spListarUnidadActiva", null, null);
        }

        public List<entUnidadMedida> Buscar(string texto)
        {
            return Ejecutar("spBuscarUnidad", "@texto", texto);
        }

        public int Insertar(entUnidadMedida obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarUnidad", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obj.nombre);
            cmd.Parameters.AddWithValue("@abreviatura", obj.abreviatura);
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

        public void Editar(entUnidadMedida obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarUnidad", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUnidad", obj.idUnidad);
            cmd.Parameters.AddWithValue("@nombre", obj.nombre);
            cmd.Parameters.AddWithValue("@abreviatura", obj.abreviatura);
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

        public void Deshabilitar(int idUnidad)
        {
            EjecutarEstado("spDeshabilitarUnidad", idUnidad);
        }

        public void Habilitar(int idUnidad)
        {
            EjecutarEstado("spHabilitarUnidad", idUnidad);
        }

        #endregion metodos

        #region privados

        private List<entUnidadMedida> Ejecutar(string procedimiento, string parametro, object valor)
        {
            List<entUnidadMedida> lista = new List<entUnidadMedida>();
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
            cmd.Parameters.AddWithValue("@idUnidad", id);

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

        private entUnidadMedida Mapear(IDataRecord dr)
        {
            entUnidadMedida obj = new entUnidadMedida();
            obj.idUnidad = Lectura.Entero(dr, "idUnidad");
            obj.nombre = Lectura.Texto(dr, "nombre");
            obj.abreviatura = Lectura.Texto(dr, "abreviatura");
            obj.estUnidad = Lectura.Logico(dr, "estUnidad");
            return obj;
        }

        #endregion privados
    }
}
