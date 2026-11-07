using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos del mantenedor de mesas (CUS-15 / RF-12).</summary>
    public class datMesa
    {
        #region singleton

        private static readonly datMesa _instancia = new datMesa();

        private datMesa()
        {
        }

        public static datMesa Instancia
        {
            get { return datMesa._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entMesa> Listar()
        {
            return Ejecutar("spListarMesa", null, null);
        }

        public List<entMesa> ListarActivos()
        {
            return Ejecutar("spListarMesaActiva", null, null);
        }

        public List<entMesa> Buscar(string texto)
        {
            return Ejecutar("spBuscarMesa", "@texto", texto);
        }

        public int Insertar(entMesa obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarMesa", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obj.codigo);
            cmd.Parameters.AddWithValue("@ubicacion", obj.ubicacion);
            cmd.Parameters.AddWithValue("@capacidad", obj.capacidad);
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

        public void Editar(entMesa obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarMesa", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idMesa", obj.idMesa);
            cmd.Parameters.AddWithValue("@codigo", obj.codigo);
            cmd.Parameters.AddWithValue("@ubicacion", obj.ubicacion);
            cmd.Parameters.AddWithValue("@capacidad", obj.capacidad);
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

        public void Deshabilitar(int idMesa)
        {
            EjecutarEstado("spDeshabilitarMesa", idMesa);
        }

        public void Habilitar(int idMesa)
        {
            EjecutarEstado("spHabilitarMesa", idMesa);
        }

        #endregion metodos

        #region privados

        private List<entMesa> Ejecutar(string procedimiento, string parametro, object valor)
        {
            List<entMesa> lista = new List<entMesa>();
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
            cmd.Parameters.AddWithValue("@idMesa", id);

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

        private entMesa Mapear(IDataRecord dr)
        {
            entMesa obj = new entMesa();
            obj.idMesa = Lectura.Entero(dr, "idMesa");
            obj.codigo = Lectura.Texto(dr, "codigo");
            obj.ubicacion = Lectura.Texto(dr, "ubicacion");
            obj.capacidad = Lectura.Entero(dr, "capacidad");
            obj.estMesa = Lectura.Logico(dr, "estMesa");
            return obj;
        }

        #endregion privados
    }
}
