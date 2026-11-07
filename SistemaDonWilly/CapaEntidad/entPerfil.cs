using System;

namespace CapaEntidad
{
    /// <summary>Perfil de acceso asignable a un usuario (CUS-18 / RF-11).</summary>
    public class entPerfil
    {
        public int idPerfil { get; set; }
        public string nombre { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
