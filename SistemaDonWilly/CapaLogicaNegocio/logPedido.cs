using System;
using System.Collections.Generic;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    /// <summary>
    /// Reglas de los casos CORE de atencion: solicitudes (CUS-01 a CUS-03),
    /// preparacion y despacho (CUS-04, CUS-05) y cobranza (CUS-06 con CUS-22).
    /// </summary>
    public class logPedido
    {
        #region singleton

        private static readonly logPedido _instancia = new logPedido();

        private logPedido()
        {
        }

        public static logPedido Instancia
        {
            get { return logPedido._instancia; }
        }

        #endregion singleton

        #region CUS-01 / CUS-03  solicitudes

        /// <summary>CUS-01: registra la solicitud pendiente de disponibilidad.</summary>
        public int RegistrarSolicitud(entPedido p)
        {
            ExigirPerfil(entSesion.PERFIL_MESERA, entSesion.PERFIL_CAJERA);
            ValidarSolicitud(p);

            p.idTrabajadorReg = entSesion.idTrabajador;
            int idPedido = datPedido.Instancia.RegistrarSolicitud(p);

            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", idPedido,
                "REGISTRO_SOLICITUD", "Modalidad " + p.modalidad);
            return idPedido;
        }

        /// <summary>A1 de CUS-03: el cambio invalida la respuesta de cocina.</summary>
        public void ModificarSolicitud(entPedido p)
        {
            ExigirPerfil(entSesion.PERFIL_MESERA, entSesion.PERFIL_CAJERA);
            Validacion.Seleccionado(p.idPedido, "una solicitud");
            ValidarSolicitud(p);

            datPedido.Instancia.ModificarSolicitud(p);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", p.idPedido,
                "CAMBIO_SOLICITUD", "Requiere nueva respuesta de cocina");
        }

        public List<entPedido> ListarSolicitudesPendientes()
        {
            return datPedido.Instancia.ListarSolicitudesPendientes();
        }

        public List<entPedido> ListarSolicitudesRespondidas()
        {
            return datPedido.Instancia.ListarSolicitudesRespondidas();
        }

        /// <summary>CUS-02: cocina responde si puede atender la solicitud.</summary>
        public void ResponderDisponibilidad(int idPedido, bool favorable, string observacion)
        {
            ExigirPerfil(entSesion.PERFIL_COCINA);
            Validacion.Seleccionado(idPedido, "una solicitud pendiente");

            if (!favorable)
            {
                Validacion.Requerido(observacion, "faltantes y alternativas");
            }

            entRespuestaDisponibilidad r = new entRespuestaDisponibilidad();
            r.idPedido = idPedido;
            r.idTrabajador = entSesion.idTrabajador;
            r.resultado = favorable ? "FAVORABLE" : "FALTANTES";
            r.observacion = Validacion.Limpiar(observacion);

            datPedido.Instancia.ResponderDisponibilidad(r);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", idPedido,
                "RESPUESTA_COCINA", r.resultado);
        }

        /// <summary>CUS-03: confirma el pedido con sus precios aplicados.</summary>
        public void ConfirmarSolicitud(int idPedido)
        {
            ExigirPerfil(entSesion.PERFIL_MESERA, entSesion.PERFIL_CAJERA);
            Validacion.Seleccionado(idPedido, "una solicitud respondida");

            datPedido.Instancia.ConfirmarSolicitud(idPedido);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", idPedido,
                "CONFIRMACION", "Pedido confirmado");
        }

        /// <summary>A2 de CUS-03: cierra la solicitud sin preparacion ni cobro.</summary>
        public void DesistirSolicitud(int idPedido, string motivo)
        {
            ExigirPerfil(entSesion.PERFIL_MESERA, entSesion.PERFIL_CAJERA);
            Validacion.Seleccionado(idPedido, "una solicitud");
            Validacion.Requerido(motivo, "motivo del desistimiento");

            datPedido.Instancia.DesistirSolicitud(idPedido, Validacion.Limpiar(motivo));
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", idPedido,
                "DESISTIMIENTO", motivo);
        }

        #endregion CUS-01 / CUS-03  solicitudes

        #region CUS-04 / CUS-05  atencion

        public List<entPedido> ListarPedidosParaPreparar()
        {
            return datPedido.Instancia.ListarPedidosParaPreparar();
        }

        public List<entPedido> ListarPedidosParaDespacho()
        {
            return datPedido.Instancia.ListarPedidosParaDespacho();
        }

        public void IniciarPreparacion(int idPedido)
        {
            ExigirPerfil(entSesion.PERFIL_COCINA);
            Validacion.Seleccionado(idPedido, "un pedido habilitado");
            datPedido.Instancia.IniciarPreparacion(idPedido);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", idPedido,
                "PREPARACION", "Inicio de preparacion");
        }

        public void MarcarListo(int idPedido)
        {
            ExigirPerfil(entSesion.PERFIL_COCINA);
            Validacion.Seleccionado(idPedido, "un pedido en preparacion");
            datPedido.Instancia.MarcarListo(idPedido);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pedido", idPedido,
                "LISTO", "Pedido listo para revision");
        }

        /// <summary>CUS-05: conformidad y entrega del pedido.</summary>
        public void RegistrarDespacho(int idPedido)
        {
            ExigirPerfil(entSesion.PERFIL_MESERA);
            Validacion.Seleccionado(idPedido, "un pedido listo");
            datPedido.Instancia.RegistrarDespacho(idPedido, entSesion.idTrabajador);
        }

        /// <summary>A1 de CUS-05: devuelve el pedido a cocina para su correccion.</summary>
        public void SolicitarCorreccion(int idPedido, string observacion)
        {
            ExigirPerfil(entSesion.PERFIL_MESERA);
            Validacion.Seleccionado(idPedido, "un pedido listo");
            Validacion.Requerido(observacion, "diferencia encontrada");
            datPedido.Instancia.SolicitarCorreccion(idPedido, Validacion.Limpiar(observacion),
                entSesion.idTrabajador);
        }

        #endregion CUS-04 / CUS-05  atencion

        #region CUS-06 / CUS-22  cobranza

        public List<entPedido> ListarPedidosPorCobrar()
        {
            return datPedido.Instancia.ListarPedidosPorCobrar();
        }

        /// <summary>CUS-22: saldo = total del pedido menos los pagos aplicados.</summary>
        public entSaldoPedido CalcularSaldo(int idPedido)
        {
            Validacion.Seleccionado(idPedido, "un pedido");
            return datPedido.Instancia.CalcularSaldo(idPedido);
        }

        /// <summary>CUS-06: registra un pago verificado. El vuelto no es ingreso.</summary>
        public entSaldoPedido RegistrarCobro(entPago pago)
        {
            ExigirPerfil(entSesion.PERFIL_CAJERA);
            Validacion.Seleccionado(pago.idPedido, "un pedido");
            Validacion.Positivo(pago.importe, "importe");
            Validacion.Requerido(pago.medioPago, "medio de pago");

            entSaldoPedido saldo = datPedido.Instancia.CalcularSaldo(pago.idPedido);

            if (saldo.saldo <= 0)
            {
                throw new ReglaNegocioException("El pedido ya esta pagado.");
            }

            if (pago.importe > saldo.saldo)
            {
                throw new ReglaNegocioException("Revise el importe y el saldo pendiente.");
            }

            if (pago.medioPago == "EFECTIVO")
            {
                if (pago.montoRecibido < pago.importe)
                {
                    throw new ReglaNegocioException("El monto recibido no cubre el importe indicado.");
                }
            }
            else
            {
                pago.montoRecibido = pago.importe;
            }

            pago.idTrabajador = entSesion.idTrabajador;
            entSaldoPedido resultado = datPedido.Instancia.RegistrarCobro(pago);

            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Pago", pago.idPedido,
                "COBRO", pago.medioPago + " S/ " + pago.importe.ToString("0.00"));
            return resultado;
        }

        public List<entPago> ListarPagos(int idPedido)
        {
            return datPedido.Instancia.ListarPagos(idPedido);
        }

        #endregion CUS-06 / CUS-22  cobranza

        #region comunes

        public entPedido Obtener(int idPedido)
        {
            Validacion.Seleccionado(idPedido, "un pedido");
            return datPedido.Instancia.Obtener(idPedido);
        }

        public List<entDetallePedido> ListarDetalle(int idPedido)
        {
            return datPedido.Instancia.ListarDetalle(idPedido);
        }

        #endregion comunes

        #region privados

        private void ValidarSolicitud(entPedido p)
        {
            Validacion.Requerido(p.modalidad, "modalidad");

            if (p.modalidad == "MESA")
            {
                Validacion.Seleccionado(p.idMesa, "una mesa");
            }

            if (p.detalles == null || p.detalles.Count == 0)
            {
                throw new ReglaNegocioException("Revise los productos, las cantidades y la mesa.");
            }

            foreach (entDetallePedido d in p.detalles)
            {
                if (d.cantidad <= 0)
                {
                    throw new ReglaNegocioException("Revise los productos, las cantidades y la mesa.");
                }
                Validacion.NoNegativo(d.precioAplicado, "precio");
            }
        }

        /// <summary>RNF-01: cada operacion comprueba el perfil del usuario en sesion.</summary>
        private void ExigirPerfil(params string[] perfiles)
        {
            if (!entSesion.Activa)
            {
                throw new ReglaNegocioException("Debe iniciar sesion para realizar esta operacion.");
            }

            foreach (string perfil in perfiles)
            {
                if (entSesion.TienePerfil(perfil))
                {
                    return;
                }
            }

            throw new ReglaNegocioException("Su perfil no tiene permiso para esta operacion.");
        }

        #endregion privados
    }
}
