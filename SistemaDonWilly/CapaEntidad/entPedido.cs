using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    /// <summary>
    /// Pedido del restaurante. Conserva por separado el estado de la solicitud,
    /// el estado de atencion y el estado de pago (RFD-05).
    /// </summary>
    public class entPedido
    {
        public entPedido()
        {
            detalles = new List<entDetallePedido>();
            estSolicitud = "PENDIENTE";
            estAtencion = "SIN_INICIAR";
            estPago = "PENDIENTE";
        }

        public int idPedido { get; set; }
        public string modalidad { get; set; }          // MESA | LLEVAR
        public int idMesa { get; set; }
        public string mesa { get; set; }
        public int idTrabajadorReg { get; set; }
        public string registradoPor { get; set; }
        public DateTime fecRegistro { get; set; }
        public string estSolicitud { get; set; }       // PENDIENTE|RESPONDIDA|CONFIRMADA|DESISTIDA
        public string estAtencion { get; set; }        // SIN_INICIAR|PREPARACION|LISTO|POR_CORREGIR|ENTREGADO
        public string estPago { get; set; }            // PENDIENTE|PARCIAL|PAGADO
        public decimal total { get; set; }
        public decimal saldo { get; set; }
        public string motivoDesiste { get; set; }
        public string resultado { get; set; }          // resultado de la respuesta de cocina vigente
        public string observacion { get; set; }

        public List<entDetallePedido> detalles { get; set; }
    }
}
