using System;

namespace CapaEntidad
{
    /// <summary>Pago verificado aplicado a un pedido (CUS-06 / RF-03).</summary>
    public class entPago
    {
        public int idPago { get; set; }
        public int idPedido { get; set; }
        public DateTime fecPago { get; set; }
        public decimal importe { get; set; }
        public string medioPago { get; set; }
        public decimal montoRecibido { get; set; }
        public decimal vuelto { get; set; }
        public string referencia { get; set; }
        public int idTrabajador { get; set; }
        public string cajera { get; set; }
    }
}
