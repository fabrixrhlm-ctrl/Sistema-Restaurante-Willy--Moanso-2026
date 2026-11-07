using System;

namespace CapaEntidad
{
    /// <summary>Fila de la consulta de pedidos (CUS-19 / RF-10).</summary>
    public class entConsultaPedido
    {
        public int idPedido { get; set; }
        public DateTime fecRegistro { get; set; }
        public string modalidad { get; set; }
        public string mesa { get; set; }
        public string productos { get; set; }
        public decimal total { get; set; }
        public decimal saldo { get; set; }
        public string estSolicitud { get; set; }
        public string estAtencion { get; set; }
        public string estPago { get; set; }
        public string responsable { get; set; }
    }
}
