using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    /// <summary>
    /// Cuenta de acceso vinculada a un trabajador activo (CUS-18 / RF-11).
    /// La clave nunca se transporta en texto legible (RNF-02).
    /// </summary>
    public class entUsuario
    {
        public entUsuario()
        {
            perfiles = new List<entPerfil>();
        }

        public int idUsuario { get; set; }
        public int idTrabajador { get; set; }
        public string trabajador { get; set; }
        public string nomUsuario { get; set; }
        public string claveHash { get; set; }
        public string claveSal { get; set; }
        public bool estUsuario { get; set; }
        public bool estTrabajador { get; set; }
        public string perfilesTexto { get; set; }

        public List<entPerfil> perfiles { get; set; }

        /// <summary>Indica si el usuario tiene asignado el perfil recibido.</summary>
        public bool TienePerfil(string nombrePerfil)
        {
            foreach (entPerfil p in perfiles)
            {
                if (string.Equals(p.nombre, nombrePerfil, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
