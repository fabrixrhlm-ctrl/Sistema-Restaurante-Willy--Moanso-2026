using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    /// <summary>
    /// Acceso a datos de las tres consultas operativas: pedidos (CUS-19),
    /// cobros (CUS-20) y abastecimiento (CUS-21). Ninguna altera informacion.
    /// </summary>
    public class datConsulta
    {
        #region singleton

        private static readonly datConsulta _instancia = new datConsulta();

        private datConsulta()
        {
        }

        public static datConsulta Instancia
        {
            get { return datConsulta._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entConsultaPedido> ConsultarPedidos(DateTime desde, DateTime hasta,
            string modalidad, string estAtencion, string estPago)
        {
            List<entConsultaPedido> lista = new List<entConsultaPedido>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spConsultarPedidos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);
            cmd.Parameters.AddWithValue("@modalidad", Opcional(modalidad));
            cmd.Parameters.AddWithValue("@estAtencion", Opcional(estAtencion));
            cmd.Parameters.AddWithValue("@estPago", Opcional(estPago));

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entConsultaPedido c = new entConsultaPedido();
                        c.idPedido = Lectura.Entero(dr, "idPedido");
                        c.fecRegistro = Lectura.Fecha(dr, "fecRegistro");
                        c.modalidad = Lectura.Texto(dr, "modalidad");
                        c.mesa = Lectura.Texto(dr, "mesa");
                        c.productos = Lectura.Texto(dr, "productos");
                        c.total = Lectura.Decimal(dr, "total");
                        c.saldo = Lectura.Decimal(dr, "saldo");
                        c.estSolicitud = Lectura.Texto(dr, "estSolicitud");
                        c.estAtencion = Lectura.Texto(dr, "estAtencion");
                        c.estPago = Lectura.Texto(dr, "estPago");
                        c.responsable = Lectura.Texto(dr, "responsable");
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

        public List<entConsultaCobro> ConsultarCobros(DateTime desde, DateTime hasta,
            string medioPago, int idTrabajador)
        {
            List<entConsultaCobro> lista = new List<entConsultaCobro>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spConsultarCobros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desde", desde.Date);
            cmd.Parameters.AddWithValue("@hasta", hasta.Date);
            cmd.Parameters.AddWithValue("@medioPago", Opcional(medioPago));
            cmd.Parameters.AddWithValue("@idTrabajador",
                idTrabajador > 0 ? (object)idTrabajador : DBNull.Value);

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entConsultaCobro c = new entConsultaCobro();
                        c.idPago = Lectura.Entero(dr, "idPago");
                        c.idPedido = Lectura.Entero(dr, "idPedido");
                        c.fecPago = Lectura.Fecha(dr, "fecPago");
                        c.importe = Lectura.Decimal(dr, "importe");
                        c.medioPago = Lectura.Texto(dr, "medioPago");
                        c.vuelto = Lectura.Decimal(dr, "vuelto");
                        c.referencia = Lectura.Texto(dr, "referencia");
                        c.cajera = Lectura.Texto(dr, "cajera");
                        c.modalidad = Lectura.Texto(dr, "modalidad");
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

        public List<entConsultaAbastecimiento> ConsultarAbastecimiento(int idRequerimiento,
            int idProveedor, string estDiferencia)
        {
            List<entConsultaAbastecimiento> lista = new List<entConsultaAbastecimiento>();
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spConsultarAbastecimiento", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRequerimiento",
                idRequerimiento > 0 ? (object)idRequerimiento : DBNull.Value);
            cmd.Parameters.AddWithValue("@idProveedor",
                idProveedor > 0 ? (object)idProveedor : DBNull.Value);
            cmd.Parameters.AddWithValue("@estDiferencia", Opcional(estDiferencia));

            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entConsultaAbastecimiento c = new entConsultaAbastecimiento();
                        c.idRequerimiento = Lectura.Entero(dr, "idRequerimiento");
                        c.semana = Lectura.Texto(dr, "semana");
                        c.insumo = Lectura.Texto(dr, "insumo");
                        c.unidad = Lectura.Texto(dr, "unidad");
                        c.requerido = Lectura.Decimal(dr, "requerido");
                        c.comprado = Lectura.Decimal(dr, "comprado");
                        c.aceptado = Lectura.Decimal(dr, "aceptado");
                        c.pendienteCompra = Lectura.Decimal(dr, "pendienteCompra");
                        c.pendienteRecepcion = Lectura.Decimal(dr, "pendienteRecepcion");
                        c.difPendientes = Lectura.Entero(dr, "difPendientes");
                        c.difRegularizadas = Lectura.Entero(dr, "difRegularizadas");
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

        public void RegistrarAuditoria(string nomUsuario, string entidad, int idRegistro,
            string operacion, string detalle)
        {
            SqlConnection cn = Conexion.Instancia.Conectar();
            SqlCommand cmd = new SqlCommand("spRegistrarAuditoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomUsuario", nomUsuario);
            cmd.Parameters.AddWithValue("@entidad", entidad);
            cmd.Parameters.AddWithValue("@idRegistro", idRegistro);
            cmd.Parameters.AddWithValue("@operacion", operacion);
            cmd.Parameters.AddWithValue("@detalle", detalle ?? string.Empty);

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

        #endregion metodos

        #region privados

        private object Opcional(string valor)
        {
            return string.IsNullOrEmpty(valor) ? (object)DBNull.Value : valor;
        }

        #endregion privados
    }
}
