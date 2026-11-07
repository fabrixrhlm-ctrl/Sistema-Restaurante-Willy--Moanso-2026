using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>
    /// Acceso a datos del abastecimiento: requerimiento semanal (CUS-07, CUS-08),
    /// compra (CUS-09), recepcion con sus diferencias (CUS-10, CUS-23) y
    /// regularizacion (CUS-11).
    /// </summary>
    public class datAbastecimiento
    {
        #region singleton

        private static readonly datAbastecimiento _instancia = new datAbastecimiento();

        private datAbastecimiento()
        {
        }

        public static datAbastecimiento Instancia
        {
            get { return datAbastecimiento._instancia; }
        }

        #endregion singleton

        #region requerimiento

        public int RegistrarRequerimiento(entRequerimiento r)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarRequerimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@semana", r.semana);
            cmd.Parameters.AddWithValue("@fecConteo", r.fecConteo);
            cmd.Parameters.AddWithValue("@idTrabajador", r.idTrabajadorAlm);
            cmd.Parameters.AddWithValue("@estado", r.estRequerimiento);
            AgregarDetalleRequerimiento(cmd, r.detalles);

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

        public void ActualizarRequerimiento(entRequerimiento r)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spActualizarRequerimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento", r.idRequerimiento);
            cmd.Parameters.AddWithValue("@semana", r.semana);
            cmd.Parameters.AddWithValue("@fecConteo", r.fecConteo);
            cmd.Parameters.AddWithValue("@estado", r.estRequerimiento);
            AgregarDetalleRequerimiento(cmd, r.detalles);

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

        public List<entRequerimiento> ListarRequerimientos(string estado)
        {
            List<entRequerimiento> lista = new List<entRequerimiento>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarRequerimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estado",
                string.IsNullOrEmpty(estado) ? (object)DBNull.Value : estado);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entRequerimiento r = new entRequerimiento();
                        r.idRequerimiento = Lectura.Entero(dr, "idRequerimiento");
                        r.semana = Lectura.Texto(dr, "semana");
                        r.fecConteo = Lectura.Fecha(dr, "fecConteo");
                        r.fecRegistro = Lectura.Fecha(dr, "fecRegistro");
                        r.estRequerimiento = Lectura.Texto(dr, "estRequerimiento");
                        r.observacion = Lectura.Texto(dr, "observacion");
                        r.almacenero = Lectura.Texto(dr, "almacenero");
                        r.insumos = Lectura.Entero(dr, "insumos");
                        lista.Add(r);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<entRequerimiento> ListarRequerimientosRevisados()
        {
            List<entRequerimiento> lista = new List<entRequerimiento>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarRequerimientoRevisado", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entRequerimiento r = new entRequerimiento();
                        r.idRequerimiento = Lectura.Entero(dr, "idRequerimiento");
                        r.semana = Lectura.Texto(dr, "semana");
                        r.fecConteo = Lectura.Fecha(dr, "fecConteo");
                        r.fecRevision = Lectura.Fecha(dr, "fecRevision");
                        r.almacenero = Lectura.Texto(dr, "almacenero");
                        r.estRequerimiento = "REVISADO";
                        lista.Add(r);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<entDetalleRequerimiento> ListarDetalleRequerimiento(int idRequerimiento)
        {
            List<entDetalleRequerimiento> lista = new List<entDetalleRequerimiento>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarDetalleRequerimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento", idRequerimiento);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entDetalleRequerimiento d = new entDetalleRequerimiento();
                        d.idDetalleReq = Lectura.Entero(dr, "idDetalleReq");
                        d.idRequerimiento = idRequerimiento;
                        d.idInsumo = Lectura.Entero(dr, "idInsumo");
                        d.insumo = Lectura.Texto(dr, "insumo");
                        d.idUnidad = Lectura.Entero(dr, "idUnidad");
                        d.unidad = Lectura.Texto(dr, "unidad");
                        d.cantUtilizable = Lectura.Decimal(dr, "cantUtilizable");
                        d.cantNecesidad = Lectura.Decimal(dr, "cantNecesidad");
                        d.cantSolicitada = Lectura.Decimal(dr, "cantSolicitada");
                        lista.Add(d);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public void RevisarRequerimiento(int idRequerimiento, int idTrabajador, bool conforme, string observacion)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRevisarRequerimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento", idRequerimiento);
            cmd.Parameters.AddWithValue("@idTrabajador", idTrabajador);
            cmd.Parameters.AddWithValue("@conforme", conforme);
            cmd.Parameters.AddWithValue("@observacion", observacion ?? string.Empty);

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

        #endregion requerimiento

        #region compra

        public List<entAvanceRequerimiento> ListarAvance(int idRequerimiento)
        {
            List<entAvanceRequerimiento> lista = new List<entAvanceRequerimiento>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarAvanceRequerimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento", idRequerimiento);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entAvanceRequerimiento a = new entAvanceRequerimiento();
                        a.idInsumo = Lectura.Entero(dr, "idInsumo");
                        a.insumo = Lectura.Texto(dr, "insumo");
                        a.idUnidad = Lectura.Entero(dr, "idUnidad");
                        a.unidad = Lectura.Texto(dr, "unidad");
                        a.cantSolicitada = Lectura.Decimal(dr, "cantSolicitada");
                        a.comprado = Lectura.Decimal(dr, "comprado");
                        a.pendiente = Lectura.Decimal(dr, "pendiente");
                        lista.Add(a);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public int RegistrarCompra(entCompra c)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarCompra", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento", c.idRequerimiento);
            cmd.Parameters.AddWithValue("@idProveedor", c.idProveedor);
            cmd.Parameters.AddWithValue("@fecCompra", c.fecCompra);
            cmd.Parameters.AddWithValue("@documento", c.documento ?? string.Empty);
            cmd.Parameters.AddWithValue("@observacion", c.observacion ?? string.Empty);
            cmd.Parameters.AddWithValue("@idTrabajador", c.idTrabajador);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("idInsumo", typeof(int));
            tabla.Columns.Add("idUnidad", typeof(int));
            tabla.Columns.Add("cantidad", typeof(decimal));
            tabla.Columns.Add("precioUnitario", typeof(decimal));

            foreach (entDetalleCompra d in c.detalles)
            {
                tabla.Rows.Add(d.idInsumo, d.idUnidad, d.cantidad, d.precioUnitario);
            }

            SqlParameter par = cmd.Parameters.AddWithValue("@detalle", tabla);
            par.SqlDbType = SqlDbType.Structured;
            par.TypeName = "TipoDetalleCompra";

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

        public List<entCompra> ListarCompras(int idRequerimiento)
        {
            List<entCompra> lista = new List<entCompra>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarCompra", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento",
                idRequerimiento > 0 ? (object)idRequerimiento : DBNull.Value);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entCompra c = new entCompra();
                        c.idCompra = Lectura.Entero(dr, "idCompra");
                        c.idRequerimiento = Lectura.Entero(dr, "idRequerimiento");
                        c.semana = Lectura.Texto(dr, "semana");
                        c.fecCompra = Lectura.Fecha(dr, "fecCompra");
                        c.proveedor = Lectura.Texto(dr, "proveedor");
                        c.documento = Lectura.Texto(dr, "documento");
                        c.total = Lectura.Decimal(dr, "total");
                        c.observacion = Lectura.Texto(dr, "observacion");
                        lista.Add(c);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<entDetalleCompra> ListarDetalleCompra(int idCompra)
        {
            List<entDetalleCompra> lista = new List<entDetalleCompra>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarDetalleCompra", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entDetalleCompra d = new entDetalleCompra();
                        d.idDetalleCompra = Lectura.Entero(dr, "idDetalleCompra");
                        d.idCompra = idCompra;
                        d.idInsumo = Lectura.Entero(dr, "idInsumo");
                        d.insumo = Lectura.Texto(dr, "insumo");
                        d.unidad = Lectura.Texto(dr, "unidad");
                        d.cantidad = Lectura.Decimal(dr, "cantidad");
                        d.precioUnitario = Lectura.Decimal(dr, "precioUnitario");
                        d.subtotal = Lectura.Decimal(dr, "subtotal");
                        lista.Add(d);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        #endregion compra

        #region recepcion

        public List<entCompra> ListarComprasPendientesRecepcion()
        {
            List<entCompra> lista = new List<entCompra>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarCompraPendienteRecepcion", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entCompra c = new entCompra();
                        c.idCompra = Lectura.Entero(dr, "idCompra");
                        c.fecCompra = Lectura.Fecha(dr, "fecCompra");
                        c.proveedor = Lectura.Texto(dr, "proveedor");
                        c.semana = Lectura.Texto(dr, "semana");
                        c.total = Lectura.Decimal(dr, "total");
                        lista.Add(c);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public List<entDetalleRecepcion> ListarDetalleCompraPendiente(int idCompra)
        {
            List<entDetalleRecepcion> lista = new List<entDetalleRecepcion>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarDetalleCompraPendiente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", idCompra);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entDetalleRecepcion d = new entDetalleRecepcion();
                        d.idDetalleCompra = Lectura.Entero(dr, "idDetalleCompra");
                        d.insumo = Lectura.Texto(dr, "insumo");
                        d.unidad = Lectura.Texto(dr, "unidad");
                        d.cantComprada = Lectura.Decimal(dr, "cantComprada");
                        d.cantAceptadaAcum = Lectura.Decimal(dr, "cantAceptadaAcum");
                        d.pendiente = Lectura.Decimal(dr, "pendiente");
                        d.motivo = string.Empty;
                        lista.Add(d);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public int RegistrarRecepcion(entRecepcion r)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarRecepcion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idCompra", r.idCompra);
            cmd.Parameters.AddWithValue("@fecRecepcion", r.fecRecepcion);
            cmd.Parameters.AddWithValue("@idTrabajador", r.idTrabajador);
            cmd.Parameters.AddWithValue("@observacion", r.observacion ?? string.Empty);

            DataTable tabla = new DataTable();
            tabla.Columns.Add("idDetalleCompra", typeof(int));
            tabla.Columns.Add("cantRecibida", typeof(decimal));
            tabla.Columns.Add("cantAceptada", typeof(decimal));
            tabla.Columns.Add("cantObservada", typeof(decimal));
            tabla.Columns.Add("motivo", typeof(string));

            foreach (entDetalleRecepcion d in r.detalles)
            {
                tabla.Rows.Add(d.idDetalleCompra, d.cantRecibida, d.cantAceptada,
                               d.cantObservada, d.motivo ?? string.Empty);
            }

            SqlParameter par = cmd.Parameters.AddWithValue("@detalle", tabla);
            par.SqlDbType = SqlDbType.Structured;
            par.TypeName = "TipoDetalleRecepcion";

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

        public List<entDiferenciaRecepcion> ListarDiferenciasPendientes()
        {
            List<entDiferenciaRecepcion> lista = new List<entDiferenciaRecepcion>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarDiferenciaPendiente", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entDiferenciaRecepcion f = new entDiferenciaRecepcion();
                        f.idDiferencia = Lectura.Entero(dr, "idDiferencia");
                        f.idCompra = Lectura.Entero(dr, "idCompra");
                        f.idRecepcion = Lectura.Entero(dr, "idRecepcion");
                        f.fecRecepcion = Lectura.Fecha(dr, "fecRecepcion");
                        f.insumo = Lectura.Texto(dr, "insumo");
                        f.unidad = Lectura.Texto(dr, "unidad");
                        f.cantObservada = Lectura.Decimal(dr, "cantObservada");
                        f.proveedor = Lectura.Texto(dr, "proveedor");
                        f.motivo = Lectura.Texto(dr, "motivo");
                        f.estDiferencia = Lectura.Texto(dr, "estDiferencia");
                        lista.Add(f);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        public void RegularizarDiferencia(entDiferenciaRecepcion f)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegularizarDiferencia", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idDiferencia", f.idDiferencia);
            cmd.Parameters.AddWithValue("@solucion", f.solucion ?? string.Empty);
            cmd.Parameters.AddWithValue("@sustento", f.sustento ?? string.Empty);
            cmd.Parameters.AddWithValue("@fecRegularizacion", f.fecRegularizacion);
            cmd.Parameters.AddWithValue("@idTrabajador", f.idTrabajadorReg);

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

        #endregion recepcion

        #region privados

        private void AgregarDetalleRequerimiento(SqlCommand cmd, List<entDetalleRequerimiento> detalles)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idInsumo", typeof(int));
            tabla.Columns.Add("idUnidad", typeof(int));
            tabla.Columns.Add("cantUtilizable", typeof(decimal));
            tabla.Columns.Add("cantNecesidad", typeof(decimal));
            tabla.Columns.Add("cantSolicitada", typeof(decimal));

            foreach (entDetalleRequerimiento d in detalles)
            {
                tabla.Rows.Add(d.idInsumo, d.idUnidad, d.cantUtilizable, d.cantNecesidad, d.cantSolicitada);
            }

            SqlParameter par = cmd.Parameters.AddWithValue("@detalle", tabla);
            par.SqlDbType = SqlDbType.Structured;
            par.TypeName = "TipoDetalleRequerimiento";
        }

        #endregion privados
    }
}
