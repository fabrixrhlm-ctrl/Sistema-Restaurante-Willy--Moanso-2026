using System;

namespace CapaEntidad
{
    /// <summary>Insumo adquirido en una compra, con su precio historico (RF-05).</summary>
    public class entDetalleCompra
    {
        public int idDetalleCompra { get; set; }
        public int idCompra { get; set; }
        public int idInsumo { get; set; }
        public string insumo { get; set; }
        public int idUnidad { get; set; }
        public string unidad { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subtotal { get; set; }
    }
}
