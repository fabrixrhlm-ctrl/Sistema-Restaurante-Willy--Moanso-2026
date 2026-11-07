using System;

namespace CapaEntidad
{
    /// <summary>
    /// Sesion autenticada en curso. RNF-01 exige comprobar los permisos del
    /// perfil en cada operacion, y RNF-07 identificar al responsable del registro.
    /// </summary>
    public static class entSesion
    {
        public const string PERFIL_ADMINISTRADOR = "ADMINISTRADOR";
        public const string PERFIL_MESERA        = "MESERA";
        public const string PERFIL_COCINA        = "COCINA";
        public const string PERFIL_CAJERA        = "CAJERA";
        public const string PERFIL_ALMACEN       = "ALMACEN";

        public static entUsuario Usuario { get; private set; }
        public static DateTime Inicio { get; private set; }

        public static bool Activa
        {
            get { return Usuario != null; }
        }

        public static int idTrabajador
        {
            get { return Usuario == null ? 0 : Usuario.idTrabajador; }
        }

        public static string nomUsuario
        {
            get { return Usuario == null ? string.Empty : Usuario.nomUsuario; }
        }

        public static string trabajador
        {
            get { return Usuario == null ? string.Empty : Usuario.trabajador; }
        }

        public static void Iniciar(entUsuario usuario)
        {
            Usuario = usuario;
            Inicio = DateTime.Now;
        }

        public static void Cerrar()
        {
            Usuario = null;
        }

        /// <summary>Un administrador conserva acceso a todas las funciones.</summary>
        public static bool TienePerfil(string nombrePerfil)
        {
            if (Usuario == null)
            {
                return false;
            }
            return Usuario.TienePerfil(PERFIL_ADMINISTRADOR) || Usuario.TienePerfil(nombrePerfil);
        }
    }
}
