using System;

namespace CapaEntidad
{
    /// <summary>Cantidades recibidas, aceptadas y observadas de un detalle de compra (RF-06).</summary>
    public class entDetalleRecepcion
    {
        public int idDetalleRecepcion { get; set; }
        public int idRecepcion { get; set; }
        public int idDetalleCompra { get; set; }
        public string insumo { get; set; }
        public string unidad { get; set; }
        public decimal cantComprada { get; set; }
        public decimal cantAceptadaAcum { get; set; }
        public decimal pendiente { get; set; }
        public decimal cantRecibida { get; set; }
        public decimal cantAceptada { get; set; }
        public decimal cantObservada { get; set; }
        public string motivo { get; set; }
    }
}
