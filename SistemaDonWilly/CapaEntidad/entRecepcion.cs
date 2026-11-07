using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    /// <summary>
    /// Recepcion de los insumos de una compra. Admite recepciones parciales y
    /// registra sus diferencias en la misma operacion (CUS-10 con CUS-23).
    /// </summary>
    public class entRecepcion
    {
        public entRecepcion()
        {
            detalles = new List<entDetalleRecepcion>();
        }

        public int idRecepcion { get; set; }
        public int idCompra { get; set; }
        public DateTime fecRecepcion { get; set; }
        public int idTrabajador { get; set; }
        public string observacion { get; set; }

        public List<entDetalleRecepcion> detalles { get; set; }
    }
}
