using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>Acceso a datos de usuarios, perfiles y credenciales (CUS-18 / RF-11).</summary>
    public class datUsuario
    {
        #region singleton

        private static readonly datUsuario _instancia = new datUsuario();

        private datUsuario()
        {
        }

        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entPerfil> ListarPerfiles()
        {
            List<entPerfil> lista = new List<entPerfil>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarPerfil", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entPerfil p = new entPerfil();
                        p.idPerfil = Lectura.Entero(dr, "idPerfil");
                        p.nombre = Lectura.Texto(dr, "nombre");
                        lista.Add(p);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<entUsuario> Listar()
        {
            List<entUsuario> lista = new List<entUsuario>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entUsuario u = new entUsuario();
                        u.idUsuario = Lectura.Entero(dr, "idUsuario");
                        u.idTrabajador = Lectura.Entero(dr, "idTrabajador");
                        u.nomUsuario = Lectura.Texto(dr, "nomUsuario");
                        u.trabajador = Lectura.Texto(dr, "trabajador");
                        u.perfilesTexto = Lectura.Texto(dr, "perfiles");
                        u.estUsuario = Lectura.Logico(dr, "estUsuario");
                        lista.Add(u);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<entPerfil> ListarPerfilesDe(int idUsuario)
        {
            List<entPerfil> lista = new List<entPerfil>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarPerfilesDeUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entPerfil p = new entPerfil();
                        p.idPerfil = Lectura.Entero(dr, "idPerfil");
                        p.nombre = Lectura.Texto(dr, "nombre");
                        lista.Add(p);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        /// <summary>Devuelve el hash y la sal almacenados; la comparacion la hace la capa logica.</summary>
        public entUsuario ObtenerCredencial(string nomUsuario)
        {
            entUsuario u = null;
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spObtenerCredencial", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomUsuario", nomUsuario);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        u = new entUsuario();
                        u.idUsuario = Lectura.Entero(dr, "idUsuario");
                        u.idTrabajador = Lectura.Entero(dr, "idTrabajador");
                        u.nomUsuario = Lectura.Texto(dr, "nomUsuario");
                        u.claveHash = Lectura.Texto(dr, "claveHash");
                        u.claveSal = Lectura.Texto(dr, "claveSal");
                        u.estUsuario = Lectura.Logico(dr, "estUsuario");
                        u.trabajador = Lectura.Texto(dr, "trabajador");
                        u.estTrabajador = Lectura.Logico(dr, "estTrabajador");
                    }
                }
            }
            finally
            {
                cn.Close();
            }

            if (u != null)
            {
                u.perfiles = ListarPerfilesDe(u.idUsuario);
            }
            return u;
        }

        public int Insertar(entUsuario u)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spInsertarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTrabajador", u.idTrabajador);
            cmd.Parameters.AddWithValue("@nomUsuario", u.nomUsuario);
            cmd.Parameters.AddWithValue("@claveHash", u.claveHash);
            cmd.Parameters.AddWithValue("@claveSal", u.claveSal);
            AgregarPerfiles(cmd, u);

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

        public void Editar(entUsuario u)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spEditarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", u.idUsuario);
            cmd.Parameters.AddWithValue("@nomUsuario", u.nomUsuario);
            cmd.Parameters.AddWithValue("@claveHash", u.claveHash ?? string.Empty);
            cmd.Parameters.AddWithValue("@claveSal", u.claveSal ?? string.Empty);
            AgregarPerfiles(cmd, u);

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

        public void Deshabilitar(int idUsuario)
        {
            EjecutarEstado("spDeshabilitarUsuario", idUsuario);
        }

        public void Habilitar(int idUsuario)
        {
            EjecutarEstado("spHabilitarUsuario", idUsuario);
        }

        #endregion metodos

        #region privados

        private void AgregarPerfiles(SqlCommand cmd, entUsuario u)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id", typeof(int));

            foreach (entPerfil p in u.perfiles)
            {
                tabla.Rows.Add(p.idPerfil);
            }

            SqlParameter par = cmd.Parameters.AddWithValue("@perfiles", tabla);
            par.SqlDbType = SqlDbType.Structured;
            par.TypeName = "TipoListaId";
        }

        private void EjecutarEstado(string procedimiento, int idUsuario)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand(procedimiento, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

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

        #endregion privados
    }
}
