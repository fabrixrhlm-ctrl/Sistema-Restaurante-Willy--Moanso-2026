using System;

namespace CapaEntidad
{
    /// <summary>Fila de la consulta de cobros (CUS-20 / RF-15).</summary>
    public class entConsultaCobro
    {
        public int idPago { get; set; }
        public int idPedido { get; set; }
        public DateTime fecPago { get; set; }
        public decimal importe { get; set; }
        public string medioPago { get; set; }
        public decimal vuelto { get; set; }
        public string referencia { get; set; }
        public string cajera { get; set; }
        public string modalidad { get; set; }
    }
}
