using System;

namespace CapaEntidad
{
    /// <summary>Unidad de medida de los insumos (CUS-17 / RF-14).</summary>
    public class entUnidadMedida
    {
        public int idUnidad { get; set; }
        public string nombre { get; set; }
        public string abreviatura { get; set; }
        public bool estUnidad { get; set; }

        public override string ToString()
        {
            return nombre + " (" + abreviatura + ")";
        }
    }
}
