using System;
using System.Collections.Generic;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    /// <summary>
    /// Reglas del abastecimiento: requerimiento semanal (CUS-07, CUS-08),
    /// compra (CUS-09), recepcion y diferencias (CUS-10, CUS-23) y
    /// regularizacion (CUS-11). Corresponde al escenario academico del informe.
    /// </summary>
    public class logAbastecimiento
    {
        #region singleton

        private static readonly logAbastecimiento _instancia = new logAbastecimiento();

        private logAbastecimiento()
        {
        }

        public static logAbastecimiento Instancia
        {
            get { return logAbastecimiento._instancia; }
        }

        #endregion singleton

        #region CUS-07 / CUS-08  requerimiento

        public List<entRequerimiento> ListarRequerimientos(string estado)
        {
            return datAbastecimiento.Instancia.ListarRequerimientos(estado);
        }

        public List<entDetalleRequerimiento> ListarDetalle(int idRequerimiento)
        {
            return datAbastecimiento.Instancia.ListarDetalleRequerimiento(idRequerimiento);
        }

        /// <summary>CUS-07: guarda un borrador o envia el requerimiento a revision.</summary>
        public int RegistrarRequerimiento(entRequerimiento r, bool enviarARevision)
        {
            ExigirPerfil(entSesion.PERFIL_ALMACEN);
            ValidarRequerimiento(r);

            r.idTrabajadorAlm = entSesion.idTrabajador;
            r.estRequerimiento = enviarARevision ? "PENDIENTE" : "BORRADOR";

            int id = datAbastecimiento.Instancia.RegistrarRequerimiento(r);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Requerimiento", id,
                enviarARevision ? "ENVIO_REVISION" : "BORRADOR", r.semana);
            return id;
        }

        /// <summary>A3 de CUS-07: corrige un borrador o un requerimiento devuelto.</summary>
        public void ActualizarRequerimiento(entRequerimiento r, bool enviarARevision)
        {
            ExigirPerfil(entSesion.PERFIL_ALMACEN);
            Validacion.Seleccionado(r.idRequerimiento, "un requerimiento");
            ValidarRequerimiento(r);

            r.estRequerimiento = enviarARevision ? "PENDIENTE" : "BORRADOR";
            datAbastecimiento.Instancia.ActualizarRequerimiento(r);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Requerimiento",
                r.idRequerimiento, "CORRECCION", r.semana);
        }

        /// <summary>CUS-08: conformidad o devolucion con observaciones.</summary>
        public void RevisarRequerimiento(int idRequerimiento, bool conforme, string observacion)
        {
            ExigirPerfil(entSesion.PERFIL_ADMINISTRADOR);
            Validacion.Seleccionado(idRequerimiento, "un requerimiento pendiente");

            if (!conforme)
            {
                Validacion.Requerido(observacion, "observaciones de la devolucion");
            }

            datAbastecimiento.Instancia.RevisarRequerimiento(idRequerimiento,
                entSesion.idTrabajador, conforme, Validacion.Limpiar(observacion));
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Requerimiento",
                idRequerimiento, conforme ? "CONFORMIDAD" : "DEVOLUCION", observacion);
        }

        #endregion CUS-07 / CUS-08  requerimiento

        #region CUS-09  compra

        public List<entRequerimiento> ListarRequerimientosRevisados()
        {
            return datAbastecimiento.Instancia.ListarRequerimientosRevisados();
        }

        public List<entAvanceRequerimiento> ListarAvance(int idRequerimiento)
        {
            Validacion.Seleccionado(idRequerimiento, "un requerimiento revisado");
            return datAbastecimiento.Instancia.ListarAvance(idRequerimiento);
        }

        /// <summary>
        /// CUS-09: registra la compra. Una diferencia respecto de lo solicitado
        /// exige observacion antes de confirmar (A2).
        /// </summary>
        public int RegistrarCompra(entCompra c, bool hayDiferencias)
        {
            ExigirPerfil(entSesion.PERFIL_ADMINISTRADOR);
            Validacion.Seleccionado(c.idRequerimiento, "un requerimiento revisado");
            Validacion.Seleccionado(c.idProveedor, "un proveedor activo");

            if (c.detalles == null || c.detalles.Count == 0)
            {
                throw new ReglaNegocioException("Registre al menos un insumo comprado.");
            }

            foreach (entDetalleCompra d in c.detalles)
            {
                Validacion.Positivo(d.cantidad, "cantidad comprada");
                Validacion.NoNegativo(d.precioUnitario, "precio unitario");
            }

            if (hayDiferencias && string.IsNullOrEmpty(Validacion.Limpiar(c.observacion)))
            {
                throw new ReglaNegocioException(
                    "Indique la observacion que justifica la diferencia con lo solicitado.");
            }

            c.idTrabajador = entSesion.idTrabajador;
            int id = datAbastecimiento.Instancia.RegistrarCompra(c);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Compra", id,
                "REGISTRO_COMPRA", "Total S/ " + c.total.ToString("0.00"));
            return id;
        }

        public List<entCompra> ListarCompras(int idRequerimiento)
        {
            return datAbastecimiento.Instancia.ListarCompras(idRequerimiento);
        }

        public List<entDetalleCompra> ListarDetalleCompra(int idCompra)
        {
            return datAbastecimiento.Instancia.ListarDetalleCompra(idCompra);
        }

        #endregion CUS-09  compra

        #region CUS-10 / CUS-23 / CUS-11  recepcion

        public List<entCompra> ListarComprasPendientesRecepcion()
        {
            return datAbastecimiento.Instancia.ListarComprasPendientesRecepcion();
        }

        public List<entDetalleRecepcion> ListarDetalleCompraPendiente(int idCompra)
        {
            Validacion.Seleccionado(idCompra, "una compra");
            return datAbastecimiento.Instancia.ListarDetalleCompraPendiente(idCompra);
        }

        /// <summary>
        /// CUS-10: registra la recepcion con sus diferencias en una sola operacion.
        /// Aceptado mas observado equivale a recibido y no se acepta mas de lo pendiente.
        /// </summary>
        public int RegistrarRecepcion(entRecepcion r)
        {
            ExigirPerfil(entSesion.PERFIL_ALMACEN);
            Validacion.Seleccionado(r.idCompra, "una compra");

            if (r.detalles == null || r.detalles.Count == 0)
            {
                throw new ReglaNegocioException("Registre al menos una cantidad recibida.");
            }

            bool hayCantidades = false;

            foreach (entDetalleRecepcion d in r.detalles)
            {
                Validacion.NoNegativo(d.cantRecibida, "cantidad recibida");
                Validacion.NoNegativo(d.cantAceptada, "cantidad aceptada");
                Validacion.NoNegativo(d.cantObservada, "cantidad observada");

                if (d.cantAceptada + d.cantObservada != d.cantRecibida)
                {
                    throw new ReglaNegocioException(
                        "Revise las cantidades recibidas, aceptadas y observadas.");
                }

                if (d.cantAceptada > d.pendiente)
                {
                    throw new ReglaNegocioException(
                        "No se puede aceptar mas de la cantidad comprada pendiente: " + d.insumo + ".");
                }

                // CUS-23: toda diferencia detectada exige su motivo
                if (d.cantObservada > 0 && string.IsNullOrEmpty(Validacion.Limpiar(d.motivo)))
                {
                    throw new ReglaNegocioException("Indique el motivo de la diferencia: " + d.insumo + ".");
                }

                if (d.cantRecibida > 0)
                {
                    hayCantidades = true;
                }
            }

            if (!hayCantidades)
            {
                throw new ReglaNegocioException("Registre al menos una cantidad recibida.");
            }

            r.idTrabajador = entSesion.idTrabajador;
            int id = datAbastecimiento.Instancia.RegistrarRecepcion(r);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Recepcion", id,
                "REGISTRO_RECEPCION", "Compra " + r.idCompra);
            return id;
        }

        public List<entDiferenciaRecepcion> ListarDiferenciasPendientes()
        {
            return datAbastecimiento.Instancia.ListarDiferenciasPendientes();
        }

        /// <summary>CUS-11: documenta la solucion sin modificar cantidades historicas.</summary>
        public void RegularizarDiferencia(entDiferenciaRecepcion f)
        {
            ExigirPerfil(entSesion.PERFIL_ADMINISTRADOR);
            Validacion.Seleccionado(f.idDiferencia, "una diferencia pendiente");

            if (string.IsNullOrEmpty(Validacion.Limpiar(f.solucion)) ||
                string.IsNullOrEmpty(Validacion.Limpiar(f.sustento)))
            {
                throw new ReglaNegocioException("Indique como se resolvio la diferencia.");
            }

            f.idTrabajadorReg = entSesion.idTrabajador;
            datAbastecimiento.Instancia.RegularizarDiferencia(f);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Diferencia",
                f.idDiferencia, "REGULARIZACION", f.solucion);
        }

        #endregion CUS-10 / CUS-23 / CUS-11  recepcion

        #region privados

        private void ValidarRequerimiento(entRequerimiento r)
        {
            r.semana = Validacion.Limpiar(r.semana);
            Validacion.Requerido(r.semana, "semana");

            if (r.fecConteo > DateTime.Today)
            {
                throw new ReglaNegocioException("La fecha de conteo no puede ser futura.");
            }

            if (r.detalles == null || r.detalles.Count == 0)
            {
                throw new ReglaNegocioException("Registre al menos un insumo con su cantidad solicitada.");
            }

            List<int> insumos = new List<int>();

            foreach (entDetalleRequerimiento d in r.detalles)
            {
                Validacion.Seleccionado(d.idInsumo, "un insumo");
                Validacion.Positivo(d.cantSolicitada, "cantidad solicitada");
                Validacion.NoNegativo(d.cantUtilizable, "cantidad utilizable");
                Validacion.NoNegativo(d.cantNecesidad, "necesidad prevista");

                if (insumos.Contains(d.idInsumo))
                {
                    throw new ReglaNegocioException("El insumo " + d.insumo + " esta repetido.");
                }
                insumos.Add(d.idInsumo);
            }
        }

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
