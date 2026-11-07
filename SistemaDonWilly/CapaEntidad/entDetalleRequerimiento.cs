using System;

namespace CapaEntidad
{
    /// <summary>Insumo, unidad y cantidades de un requerimiento semanal (RF-04).</summary>
    public class entDetalleRequerimiento
    {
        public int idDetalleReq { get; set; }
        public int idRequerimiento { get; set; }
        public int idInsumo { get; set; }
        public string insumo { get; set; }
        public int idUnidad { get; set; }
        public string unidad { get; set; }
        public decimal cantUtilizable { get; set; }
        public decimal cantNecesidad { get; set; }
        public decimal cantSolicitada { get; set; }
    }
}
