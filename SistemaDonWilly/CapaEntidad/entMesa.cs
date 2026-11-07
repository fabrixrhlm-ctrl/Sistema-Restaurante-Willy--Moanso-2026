using System;

namespace CapaEntidad
{
    /// <summary>Mesa del local donde se ubican los pedidos de consumo (CUS-15 / RF-12).</summary>
    public class entMesa
    {
        public int idMesa { get; set; }
        public string codigo { get; set; }
        public string ubicacion { get; set; }
        public int capacidad { get; set; }
        public bool estMesa { get; set; }

        public override string ToString()
        {
            return codigo + " - " + ubicacion;
        }
    }
}
