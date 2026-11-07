using System;

namespace CapaEntidad
{
    /// <summary>Insumo utilizado en la elaboracion de alimentos (CUS-13 / RF-08).</summary>
    public class entInsumo
    {
        public int idInsumo { get; set; }
        public string nombre { get; set; }
        public int idUnidad { get; set; }
        public string unidad { get; set; }
        public bool estInsumo { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
