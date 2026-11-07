using System;

namespace CapaEntidad
{
    /// <summary>Fila de la consulta de abastecimiento (CUS-21 / RF-16).</summary>
    public class entConsultaAbastecimiento
    {
        public int idRequerimiento { get; set; }
        public string semana { get; set; }
        public string insumo { get; set; }
        public string unidad { get; set; }
        public decimal requerido { get; set; }
        public decimal comprado { get; set; }
        public decimal aceptado { get; set; }
        public decimal pendienteCompra { get; set; }
        public decimal pendienteRecepcion { get; set; }
        public int difPendientes { get; set; }
        public int difRegularizadas { get; set; }
    }
}
