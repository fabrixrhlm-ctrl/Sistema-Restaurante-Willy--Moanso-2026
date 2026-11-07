using System;

namespace CapaEntidad
{
    /// <summary>Producto de la carta: plato, menu o bebida (CUS-12 / RF-07).</summary>
    public class entProducto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string tipoProducto { get; set; }
        public decimal precio { get; set; }
        public bool disponible { get; set; }
        public bool estProducto { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
