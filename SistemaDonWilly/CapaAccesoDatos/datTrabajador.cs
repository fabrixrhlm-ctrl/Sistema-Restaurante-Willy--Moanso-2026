using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos del mantenedor de trabajadores (CUS-16 / RF-13).</summary>
    public class datTrabajador
    {
        #region singleton

        private static readonly datTrabajador _instancia = new datTrabajador();

        private datTrabajador()
        {
        }

        public static datTrabajador Instancia
        {
            get { return datTrabajador._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entTrabajador> Listar()
        {
            return Ejecutar("spListarTrabajador", null, null);
        }

        public List<entTrabajador> ListarActivos()
        {
            return Ejecutar("spListarTrabajadorActivo", null, null);
        }

        public List<entTrabajador> Buscar(string texto)
        {
            return Ejecutar("spBuscarTrabajador", "@texto", texto);
        }

        public int Insertar(entTrabajador obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarTrabajador", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@documento", obj.documento);
            cmd.Parameters.AddWithValue("@nombres", obj.nombres);
            cmd.Parameters.AddWithValue("@apellidos", obj.apellidos);
            cmd.Parameters.AddWithValue("@cargo", obj.cargo);
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

        public void Editar(entTrabajador obj)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarTrabajador", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTrabajador", obj.idTrabajador);
            cmd.Parameters.AddWithValue("@documento", obj.documento);
            cmd.Parameters.AddWithValue("@nombres", obj.nombres);
            cmd.Parameters.AddWithValue("@apellidos", obj.apellidos);
            cmd.Parameters.AddWithValue("@cargo", obj.cargo);
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

        public void Deshabilitar(int idTrabajador)
        {
            EjecutarEstado("spDeshabilitarTrabajador", idTrabajador);
        }

        public void Habilitar(int idTrabajador)
        {
            EjecutarEstado("spHabilitarTrabajador", idTrabajador);
        }

        #endregion metodos

        #region privados

        private List<entTrabajador> Ejecutar(string procedimiento, string parametro, object valor)
        {
            List<entTrabajador> lista = new List<entTrabajador>();
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
            cmd.Parameters.AddWithValue("@idTrabajador", id);

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

        private entTrabajador Mapear(IDataRecord dr)
        {
            entTrabajador obj = new entTrabajador();
            obj.idTrabajador = Lectura.Entero(dr, "idTrabajador");
            obj.documento = Lectura.Texto(dr, "documento");
            obj.nombres = Lectura.Texto(dr, "nombres");
            obj.apellidos = Lectura.Texto(dr, "apellidos");
            obj.cargo = Lectura.Texto(dr, "cargo");
            obj.telefono = Lectura.Texto(dr, "telefono");
            obj.estTrabajador = Lectura.Logico(dr, "estTrabajador");
            return obj;
        }

        #endregion privados
    }
}
