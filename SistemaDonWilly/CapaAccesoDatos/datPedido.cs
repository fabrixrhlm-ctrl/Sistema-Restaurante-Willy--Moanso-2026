using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>
    /// Acceso a datos de los casos CORE de atencion: solicitudes (CUS-01 a CUS-03),
    /// preparacion y despacho (CUS-04, CUS-05) y cobranza (CUS-06, CUS-22).
    /// Cabecera y detalle viajan como una sola unidad de trabajo (RNF-03).
    /// </summary>
    public class datPedido
    {
        #region singleton

        private static readonly datPedido _instancia = new datPedido();

        private datPedido()
        {
        }

        public static datPedido Instancia
        {
            get { return datPedido._instancia; }
        }

        #endregion singleton

        #region solicitudes

        public int RegistrarSolicitud(entPedido p)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarSolicitud", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@modalidad", p.modalidad);
            cmd.Parameters.AddWithValue("@idMesa", p.idMesa > 0 ? (object)p.idMesa : DBNull.Value);
            cmd.Parameters.AddWithValue("@idTrabajador", p.idTrabajadorReg);
            AgregarDetalle(cmd, p.detalles);

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

        public void ModificarSolicitud(entPedido p)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spModificarSolicitud", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", p.idPedido);
            AgregarDetalle(cmd, p.detalles);

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

        public List<entPedido> ListarSolicitudesPendientes()
        {
            return ListarPedidos("spListarSolicitudPendiente", null);
        }

        public List<entPedido> ListarSolicitudesRespondidas()
        {
            return ListarPedidos("spListarSolicitudRespondida", null);
        }

        public void ResponderDisponibilidad(entRespuestaDisponibilidad r)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spResponderDisponibilidad", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", r.idPedido);
            cmd.Parameters.AddWithValue("@idTrabajador", r.idTrabajador);
            cmd.Parameters.AddWithValue("@resultado", r.resultado);
            cmd.Parameters.AddWithValue("@observacion", r.observacion ?? string.Empty);

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

        public void ConfirmarSolicitud(int idPedido)
        {
            EjecutarPorPedido("spConfirmarSolicitud", idPedido);
        }

        public void DesistirSolicitud(int idPedido, string motivo)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spDesistirSolicitud", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);
            cmd.Parameters.AddWithValue("@motivo", motivo);

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

        #endregion solicitudes

        #region atencion

        public List<entPedido> ListarPedidosParaPreparar()
        {
            return ListarPedidos("spListarPedidoParaPreparar", null);
        }

        public List<entPedido> ListarPedidosParaDespacho()
        {
            return ListarPedidos("spListarPedidoParaDespacho", null);
        }

        public void IniciarPreparacion(int idPedido)
        {
            EjecutarPorPedido("spIniciarPreparacion", idPedido);
        }

        public void MarcarListo(int idPedido)
        {
            EjecutarPorPedido("spMarcarPedidoListo", idPedido);
        }

        public void RegistrarDespacho(int idPedido, int idTrabajador)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarDespacho", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);
            cmd.Parameters.AddWithValue("@idTrabajador", idTrabajador);

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

        public void SolicitarCorreccion(int idPedido, string observacion, int idTrabajador)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spSolicitarCorreccion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);
            cmd.Parameters.AddWithValue("@observacion", observacion ?? string.Empty);
            cmd.Parameters.AddWithValue("@idTrabajador", idTrabajador);

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

        #endregion atencion

        #region cobranza

        public List<entPedido> ListarPedidosPorCobrar()
        {
            return ListarPedidos("spListarPedidoPorCobrar", null);
        }

        /// <summary>CUS-22: total, pagos aplicados y saldo pendiente.</summary>
        public entSaldoPedido CalcularSaldo(int idPedido)
        {
            entSaldoPedido saldo = new entSaldoPedido();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spCalcularSaldoPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        saldo.idPedido = Lectura.Entero(dr, "idPedido");
                        saldo.total = Lectura.Decimal(dr, "total");
                        saldo.pagado = Lectura.Decimal(dr, "pagado");
                        saldo.saldo = Lectura.Decimal(dr, "saldo");
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return saldo;
        }

        public entSaldoPedido RegistrarCobro(entPago pago)
        {
            entSaldoPedido resultado = new entSaldoPedido();
            resultado.idPedido = pago.idPedido;

            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarCobro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", pago.idPedido);
            cmd.Parameters.AddWithValue("@importe", pago.importe);
            cmd.Parameters.AddWithValue("@medioPago", pago.medioPago);
            cmd.Parameters.AddWithValue("@montoRecibido", pago.montoRecibido);
            cmd.Parameters.AddWithValue("@referencia", pago.referencia ?? string.Empty);
            cmd.Parameters.AddWithValue("@idTrabajador", pago.idTrabajador);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        resultado.total = Lectura.Decimal(dr, "total");
                        resultado.pagado = Lectura.Decimal(dr, "pagado");
                        resultado.saldo = Lectura.Decimal(dr, "saldo");
                        resultado.vuelto = Lectura.Decimal(dr, "vuelto");
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public List<entPago> ListarPagos(int idPedido)
        {
            List<entPago> lista = new List<entPago>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarPagoPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entPago g = new entPago();
                        g.idPago = Lectura.Entero(dr, "idPago");
                        g.idPedido = idPedido;
                        g.fecPago = Lectura.Fecha(dr, "fecPago");
                        g.importe = Lectura.Decimal(dr, "importe");
                        g.medioPago = Lectura.Texto(dr, "medioPago");
                        g.vuelto = Lectura.Decimal(dr, "vuelto");
                        g.referencia = Lectura.Texto(dr, "referencia");
                        g.cajera = Lectura.Texto(dr, "cajera");
                        lista.Add(g);
                    }
                }
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

        #endregion cobranza

        #region comunes

        public entPedido Obtener(int idPedido)
        {
            entPedido p = null;
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spObtenerPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        p = new entPedido();
                        p.idPedido = Lectura.Entero(dr, "idPedido");
                        p.modalidad = Lectura.Texto(dr, "modalidad");
                        p.idMesa = Lectura.Entero(dr, "idMesa");
                        p.mesa = Lectura.Texto(dr, "mesa");
                        p.idTrabajadorReg = Lectura.Entero(dr, "idTrabajadorReg");
                        p.fecRegistro = Lectura.Fecha(dr, "fecRegistro");
                        p.estSolicitud = Lectura.Texto(dr, "estSolicitud");
                        p.estAtencion = Lectura.Texto(dr, "estAtencion");
                        p.estPago = Lectura.Texto(dr, "estPago");
                        p.total = Lectura.Decimal(dr, "total");
                        p.motivoDesiste = Lectura.Texto(dr, "motivoDesiste");
                    }
                }
            }
            finally
            {
                cn.Close();
            }

            if (p != null)
            {
                p.detalles = ListarDetalle(idPedido);
            }
            return p;
        }

        public List<entDetallePedido> ListarDetalle(int idPedido)
        {
            List<entDetallePedido> lista = new List<entDetallePedido>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spListarDetallePedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entDetallePedido d = new entDetallePedido();
                        d.idDetallePedido = Lectura.Entero(dr, "idDetallePedido");
                        d.idPedido = idPedido;
                        d.idProducto = Lectura.Entero(dr, "idProducto");
                        d.producto = Lectura.Texto(dr, "producto");
                        d.tipoProducto = Lectura.Texto(dr, "tipoProducto");
                        d.cantidad = Lectura.Entero(dr, "cantidad");
                        d.precioAplicado = Lectura.Decimal(dr, "precioAplicado");
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

        #endregion comunes

        #region privados

        private List<entPedido> ListarPedidos(string procedimiento, SqlParameter parametro)
        {
            List<entPedido> lista = new List<entPedido>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand(procedimiento, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parametro != null)
            {
                cmd.Parameters.Add(parametro);
            }

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entPedido p = new entPedido();
                        p.idPedido = Lectura.Entero(dr, "idPedido");
                        p.modalidad = Lectura.Texto(dr, "modalidad");
                        p.mesa = Lectura.Texto(dr, "mesa");
                        p.total = Lectura.Decimal(dr, "total");

                        if (TieneColumna(dr, "fecRegistro"))
                        {
                            p.fecRegistro = Lectura.Fecha(dr, "fecRegistro");
                        }
                        if (TieneColumna(dr, "estAtencion"))
                        {
                            p.estAtencion = Lectura.Texto(dr, "estAtencion");
                        }
                        if (TieneColumna(dr, "estPago"))
                        {
                            p.estPago = Lectura.Texto(dr, "estPago");
                        }
                        if (TieneColumna(dr, "saldo"))
                        {
                            p.saldo = Lectura.Decimal(dr, "saldo");
                        }
                        if (TieneColumna(dr, "resultado"))
                        {
                            p.resultado = Lectura.Texto(dr, "resultado");
                        }
                        if (TieneColumna(dr, "observacion"))
                        {
                            p.observacion = Lectura.Texto(dr, "observacion");
                        }
                        if (TieneColumna(dr, "registradoPor"))
                        {
                            p.registradoPor = Lectura.Texto(dr, "registradoPor");
                        }
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

        private bool TieneColumna(IDataRecord dr, string columna)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (string.Equals(dr.GetName(i), columna, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void AgregarDetalle(SqlCommand cmd, List<entDetallePedido> detalles)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("idProducto", typeof(int));
            tabla.Columns.Add("cantidad", typeof(int));
            tabla.Columns.Add("precioAplicado", typeof(decimal));

            foreach (entDetallePedido d in detalles)
            {
                tabla.Rows.Add(d.idProducto, d.cantidad, d.precioAplicado);
            }

            SqlParameter par = cmd.Parameters.AddWithValue("@detalle", tabla);
            par.SqlDbType = SqlDbType.Structured;
            par.TypeName = "TipoDetallePedido";
        }

        private void EjecutarPorPedido(string procedimiento, int idPedido)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand(procedimiento, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idPedido", idPedido);

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
