using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    /// <summary>Compra de insumos vinculada a un requerimiento revisado (CUS-09 / RF-05).</summary>
    public class entCompra
    {
        public entCompra()
        {
            detalles = new List<entDetalleCompra>();
        }

        public int idCompra { get; set; }
        public int idRequerimiento { get; set; }
        public string semana { get; set; }
        public int idProveedor { get; set; }
        public string proveedor { get; set; }
        public DateTime fecCompra { get; set; }
        public string documento { get; set; }
        public decimal total { get; set; }
        public string observacion { get; set; }
        public int idTrabajador { get; set; }

        public string descripcion
        {
            get
            {
                return "Compra " + idCompra + " - " + proveedor + " - " +
                       fecCompra.ToString("dd/MM/yyyy") + " - S/ " + total.ToString("N2");
            }
        }

        public List<entDetalleCompra> detalles { get; set; }
    }
}
