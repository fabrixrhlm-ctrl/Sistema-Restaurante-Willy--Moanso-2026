using System;
using System.Data;

namespace CapaAccesoDatos
{
    /// <summary>
    /// Conversiones seguras de los valores devueltos por SQL Server.
    /// Evita repetir comprobaciones de DBNull en cada clase de la capa.
    /// </summary>
    internal static class Lectura
    {
        public static int Entero(IDataRecord dr, string columna)
        {
            object valor = dr[columna];
            return valor == DBNull.Value ? 0 : Convert.ToInt32(valor);
        }

        public static decimal Decimal(IDataRecord dr, string columna)
        {
            object valor = dr[columna];
            return valor == DBNull.Value ? 0m : Convert.ToDecimal(valor);
        }

        public static string Texto(IDataRecord dr, string columna)
        {
            object valor = dr[columna];
            return valor == DBNull.Value ? string.Empty : Convert.ToString(valor);
        }

        public static bool Logico(IDataRecord dr, string columna)
        {
            object valor = dr[columna];
            return valor != DBNull.Value && Convert.ToBoolean(valor);
        }

        public static DateTime Fecha(IDataRecord dr, string columna)
        {
            object valor = dr[columna];
            return valor == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(valor);
        }
    }
}
