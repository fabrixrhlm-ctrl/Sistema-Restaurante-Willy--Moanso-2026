using System;

namespace CapaEntidad
{
    /// <summary>Comparacion por insumo entre lo solicitado y lo comprado (B2 de CUS-09).</summary>
    public class entAvanceRequerimiento
    {
        public int idInsumo { get; set; }
        public string insumo { get; set; }
        public int idUnidad { get; set; }
        public string unidad { get; set; }
        public decimal cantSolicitada { get; set; }
        public decimal comprado { get; set; }
        public decimal pendiente { get; set; }
    }
}
