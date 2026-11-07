using System;

namespace CapaEntidad
{
    /// <summary>Producto, cantidad y precio aplicado de un pedido (RF-01).</summary>
    public class entDetallePedido
    {
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public string producto { get; set; }
        public string tipoProducto { get; set; }
        public int cantidad { get; set; }
        public decimal precioAplicado { get; set; }

        public decimal subtotal
        {
            get { return cantidad * precioAplicado; }
        }
    }
}
