using System;

namespace CapaLogicaNegocio
{
    /// <summary>
    /// Error de regla de negocio. La presentacion lo muestra tal cual,
    /// con mensajes comprensibles para el personal (RNF-05).
    /// </summary>
    public class ReglaNegocioException : Exception
    {
        public ReglaNegocioException(string mensaje) : base(mensaje)
        {
        }
    }

    /// <summary>Validaciones comunes a los mantenedores y a los casos CORE (RFD-33).</summary>
    internal static class Validacion
    {
        public static void Requerido(string valor, string campo)
        {
            if (string.IsNullOrEmpty(valor) || valor.Trim().Length == 0)
            {
                throw new ReglaNegocioException("El campo " + campo + " es obligatorio.");
            }
        }

        public static void LongitudMaxima(string valor, int maximo, string campo)
        {
            if (valor != null && valor.Trim().Length > maximo)
            {
                throw new ReglaNegocioException(
                    "El campo " + campo + " admite como maximo " + maximo + " caracteres.");
            }
        }

        public static void Seleccionado(int id, string campo)
        {
            if (id <= 0)
            {
                throw new ReglaNegocioException("Seleccione " + campo + ".");
            }
        }

        public static void Positivo(decimal valor, string campo)
        {
            if (valor <= 0)
            {
                throw new ReglaNegocioException("El campo " + campo + " debe ser mayor que cero.");
            }
        }

        public static void NoNegativo(decimal valor, string campo)
        {
            if (valor < 0)
            {
                throw new ReglaNegocioException("El campo " + campo + " no puede ser negativo.");
            }
        }

        public static void SoloDigitos(string valor, string campo)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return;
            }

            foreach (char c in valor.Trim())
            {
                if (!char.IsDigit(c))
                {
                    throw new ReglaNegocioException("El campo " + campo + " admite solo numeros.");
                }
            }
        }

        public static string Limpiar(string valor)
        {
            return valor == null ? string.Empty : valor.Trim();
        }
    }
}
