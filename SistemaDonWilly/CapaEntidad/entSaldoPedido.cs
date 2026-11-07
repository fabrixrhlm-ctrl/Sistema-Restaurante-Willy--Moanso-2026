using System;

namespace CapaEntidad
{
    /// <summary>Resultado de CUS-22: total, pagos aplicados y saldo del pedido.</summary>
    public class entSaldoPedido
    {
        public int idPedido { get; set; }
        public decimal total { get; set; }
        public decimal pagado { get; set; }
        public decimal saldo { get; set; }
        public decimal vuelto { get; set; }
    }
}
