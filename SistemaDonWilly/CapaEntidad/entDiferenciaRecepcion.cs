using System;

namespace CapaEntidad
{
    /// <summary>Diferencia detectada en una recepcion (CUS-23) y su regularizacion (CUS-11).</summary>
    public class entDiferenciaRecepcion
    {
        public int idDiferencia { get; set; }
        public int idDetalleRecepcion { get; set; }
        public int idCompra { get; set; }
        public int idRecepcion { get; set; }
        public DateTime fecRecepcion { get; set; }
        public string insumo { get; set; }
        public string unidad { get; set; }
        public decimal cantObservada { get; set; }
        public string proveedor { get; set; }
        public string motivo { get; set; }
        public string estDiferencia { get; set; }
        public string solucion { get; set; }
        public string sustento { get; set; }
        public DateTime fecRegularizacion { get; set; }
        public int idTrabajadorReg { get; set; }
    }
}
