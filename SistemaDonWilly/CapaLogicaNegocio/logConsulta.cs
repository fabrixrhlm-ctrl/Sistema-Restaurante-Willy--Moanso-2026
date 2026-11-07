using System;
using System.Collections.Generic;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    /// <summary>
    /// Reglas de las tres consultas operativas (CUS-19, CUS-20, CUS-21).
    /// Validan los filtros y restringen los resultados segun el perfil.
    /// </summary>
    public class logConsulta
    {
        #region singleton

        private static readonly logConsulta _instancia = new logConsulta();

        private logConsulta()
        {
        }

        public static logConsulta Instancia
        {
            get { return logConsulta._instancia; }
        }

        #endregion singleton

        #region metodos

        public List<entConsultaPedido> ConsultarPedidos(DateTime desde, DateTime hasta,
            string modalidad, string estAtencion, string estPago)
        {
            ValidarRango(desde, hasta);
            return datConsulta.Instancia.ConsultarPedidos(desde, hasta, modalidad, estAtencion, estPago);
        }

        public List<entConsultaCobro> ConsultarCobros(DateTime desde, DateTime hasta,
            string medioPago, int idTrabajador)
        {
            ValidarRango(desde, hasta);
            ExigirPerfil(entSesion.PERFIL_CAJERA);
            return datConsulta.Instancia.ConsultarCobros(desde, hasta, medioPago, idTrabajador);
        }

        public List<entConsultaAbastecimiento> ConsultarAbastecimiento(int idRequerimiento,
            int idProveedor, string estDiferencia)
        {
            ExigirPerfil(entSesion.PERFIL_ALMACEN);
            return datConsulta.Instancia.ConsultarAbastecimiento(idRequerimiento, idProveedor, estDiferencia);
        }

        /// <summary>Total recaudado: suma los importes aplicados y excluye el vuelto (RFD-31).</summary>
        public decimal TotalRecaudado(List<entConsultaCobro> cobros)
        {
            decimal total = 0;

            foreach (entConsultaCobro c in cobros)
            {
                total += c.importe;
            }
            return total;
        }

        #endregion metodos

        #region privados

        private void ValidarRango(DateTime desde, DateTime hasta)
        {
            if (desde > hasta)
            {
                throw new ReglaNegocioException("Revise los criterios de consulta: la fecha inicial no puede ser mayor que la final.");
            }
        }

        private void ExigirPerfil(string perfil)
        {
            if (!entSesion.Activa)
            {
                throw new ReglaNegocioException("Debe iniciar sesion para realizar esta consulta.");
            }

            if (!entSesion.TienePerfil(perfil))
            {
                throw new ReglaNegocioException("Su perfil no tiene permiso para esta consulta.");
            }
        }

        #endregion privados
    }
}
