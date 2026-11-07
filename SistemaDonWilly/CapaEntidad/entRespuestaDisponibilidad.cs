using System;

namespace CapaEntidad
{
    /// <summary>Respuesta de cocina sobre una solicitud (CUS-02 / RF-01).</summary>
    public class entRespuestaDisponibilidad
    {
        public int idRespuesta { get; set; }
        public int idPedido { get; set; }
        public int idTrabajador { get; set; }
        public DateTime fecRespuesta { get; set; }
        public string resultado { get; set; }
        public string observacion { get; set; }
        public bool vigente { get; set; }
    }
}
