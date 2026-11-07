using System;

namespace CapaEntidad
{
    /// <summary>Trabajador del restaurante (CUS-16 / RF-13).</summary>
    public class entTrabajador
    {
        public int idTrabajador { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cargo { get; set; }
        public string telefono { get; set; }
        public bool estTrabajador { get; set; }

        public string nombreCompleto
        {
            get { return nombres + " " + apellidos; }
        }

        public override string ToString()
        {
            return nombreCompleto;
        }
    }
}
