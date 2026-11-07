using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    /// <summary>
    /// Requerimiento semanal de insumos del escenario de abastecimiento
    /// (CUS-07 elabora, CUS-08 revisa).
    /// </summary>
    public class entRequerimiento
    {
        public entRequerimiento()
        {
            detalles = new List<entDetalleRequerimiento>();
            estRequerimiento = "BORRADOR";
        }

        public int idRequerimiento { get; set; }
        public string semana { get; set; }
        public DateTime fecConteo { get; set; }
        public DateTime fecRegistro { get; set; }
        public int idTrabajadorAlm { get; set; }
        public string almacenero { get; set; }
        public string estRequerimiento { get; set; }   // BORRADOR|PENDIENTE|REVISADO|DEVUELTO
        public string observacion { get; set; }
        public int idTrabajadorRev { get; set; }
        public DateTime fecRevision { get; set; }
        public int insumos { get; set; }

        public string descripcion
        {
            get { return idRequerimiento == 0 ? semana : "Nro. " + idRequerimiento + " - " + semana; }
        }

        public List<entDetalleRequerimiento> detalles { get; set; }
    }
}
