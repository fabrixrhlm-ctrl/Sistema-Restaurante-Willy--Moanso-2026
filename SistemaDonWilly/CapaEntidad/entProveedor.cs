using System;

namespace CapaEntidad
{
    /// <summary>Proveedor de insumos del escenario de abastecimiento (CUS-14 / RF-09).</summary>
    public class entProveedor
    {
        public int idProveedor { get; set; }
        public string razonSocial { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public bool estProveedor { get; set; }

        public override string ToString()
        {
            return razonSocial;
        }
    }
}
