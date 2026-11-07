using System;
using System.Collections.Generic;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    /// <summary>
    /// Autenticacion y administracion de accesos (CUS-18 / RF-11).
    /// Exige sesion autenticada (RNF-01) y protege las credenciales (RNF-02).
    /// </summary>
    public class logUsuario
    {
        #region singleton

        private static readonly logUsuario _instancia = new logUsuario();

        private logUsuario()
        {
        }

        public static logUsuario Instancia
        {
            get { return logUsuario._instancia; }
        }

        #endregion singleton

        #region autenticacion

        /// <summary>
        /// Valida las credenciales y abre la sesion. Devuelve un mensaje
        /// generico para no revelar si el usuario existe.
        /// </summary>
        public entUsuario Autenticar(string nomUsuario, string clave)
        {
            Validacion.Requerido(nomUsuario, "usuario");
            Validacion.Requerido(clave, "contrasena");

            entUsuario u = datUsuario.Instancia.ObtenerCredencial(nomUsuario.Trim());

            if (u == null || !Seguridad.Verificar(clave, u.claveSal, u.claveHash))
            {
                throw new ReglaNegocioException("Usuario o contrasena incorrectos.");
            }

            if (!u.estUsuario || !u.estTrabajador)
            {
                throw new ReglaNegocioException("El acceso de este usuario esta desactivado.");
            }

            if (u.perfiles.Count == 0)
            {
                throw new ReglaNegocioException("El usuario no tiene perfiles asignados.");
            }

            u.claveHash = string.Empty;
            u.claveSal = string.Empty;

            entSesion.Iniciar(u);
            datConsulta.Instancia.RegistrarAuditoria(u.nomUsuario, "Usuario", u.idUsuario,
                "INICIO_SESION", "Acceso concedido");
            return u;
        }

        public void CerrarSesion()
        {
            if (entSesion.Activa)
            {
                datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Usuario",
                    entSesion.Usuario.idUsuario, "CIERRE_SESION", "Sesion finalizada");
            }
            entSesion.Cerrar();
        }

        #endregion autenticacion

        #region administracion

        public List<entPerfil> ListarPerfiles()
        {
            return datUsuario.Instancia.ListarPerfiles();
        }

        public List<entUsuario> Listar()
        {
            ExigirAdministrador();
            return datUsuario.Instancia.Listar();
        }

        public List<entPerfil> ListarPerfilesDe(int idUsuario)
        {
            return datUsuario.Instancia.ListarPerfilesDe(idUsuario);
        }

        public int Insertar(entUsuario u, string clave)
        {
            ExigirAdministrador();
            Validar(u);
            Validacion.Requerido(clave, "contrasena");

            if (clave.Trim().Length < 6)
            {
                throw new ReglaNegocioException("La contrasena debe tener al menos 6 caracteres.");
            }

            u.claveSal = Seguridad.GenerarSal();
            u.claveHash = Seguridad.CalcularHash(clave, u.claveSal);

            int id = datUsuario.Instancia.Insertar(u);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Usuario", id,
                "ALTA_USUARIO", u.nomUsuario);
            return id;
        }

        /// <summary>Una clave vacia conserva la contrasena actual.</summary>
        public void Editar(entUsuario u, string claveNueva)
        {
            ExigirAdministrador();
            Validacion.Seleccionado(u.idUsuario, "un usuario");
            Validar(u);

            if (string.IsNullOrEmpty(claveNueva) || claveNueva.Trim().Length == 0)
            {
                u.claveHash = string.Empty;
                u.claveSal = string.Empty;
            }
            else
            {
                if (claveNueva.Trim().Length < 6)
                {
                    throw new ReglaNegocioException("La contrasena debe tener al menos 6 caracteres.");
                }
                u.claveSal = Seguridad.GenerarSal();
                u.claveHash = Seguridad.CalcularHash(claveNueva, u.claveSal);
            }

            datUsuario.Instancia.Editar(u);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Usuario", u.idUsuario,
                "CAMBIO_USUARIO", u.nomUsuario);
        }

        public void Deshabilitar(int idUsuario)
        {
            ExigirAdministrador();
            Validacion.Seleccionado(idUsuario, "un usuario");
            datUsuario.Instancia.Deshabilitar(idUsuario);
            datConsulta.Instancia.RegistrarAuditoria(entSesion.nomUsuario, "Usuario", idUsuario,
                "BAJA_USUARIO", "Acceso bloqueado");
        }

        public void Habilitar(int idUsuario)
        {
            ExigirAdministrador();
            Validacion.Seleccionado(idUsuario, "un usuario");
            datUsuario.Instancia.Habilitar(idUsuario);
        }

        #endregion administracion

        #region privados

        private void Validar(entUsuario u)
        {
            u.nomUsuario = Validacion.Limpiar(u.nomUsuario);
            Validacion.Requerido(u.nomUsuario, "nombre de usuario");
            Validacion.LongitudMaxima(u.nomUsuario, 30, "nombre de usuario");
            Validacion.Seleccionado(u.idTrabajador, "un trabajador activo");

            if (u.perfiles == null || u.perfiles.Count == 0)
            {
                throw new ReglaNegocioException("Asigne al menos un perfil al usuario.");
            }
        }

        /// <summary>RFD-27: la administracion de usuarios es exclusiva del administrador.</summary>
        private void ExigirAdministrador()
        {
            if (!entSesion.Activa || !entSesion.Usuario.TienePerfil(entSesion.PERFIL_ADMINISTRADOR))
            {
                throw new ReglaNegocioException(
                    "Solo el perfil administrador puede administrar usuarios y perfiles.");
            }
        }

        #endregion privados
    }
}
