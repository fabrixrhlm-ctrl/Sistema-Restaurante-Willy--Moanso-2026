using System;
using System.Security.Cryptography;
using System.Text;

namespace CapaLogicaNegocio
{
    /// <summary>
    /// Proteccion de credenciales exigida por RNF-02: la clave se almacena
    /// como hash SHA-256 con sal y nunca en texto legible.
    /// </summary>
    public static class Seguridad
    {
        /// <summary>Genera una sal aleatoria en Base64.</summary>
        public static string GenerarSal()
        {
            byte[] bytes = new byte[12];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        /// <summary>Calcula el hash SHA-256 de la sal concatenada con la clave.</summary>
        public static string CalcularHash(string clave, string sal)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] datos = Encoding.UTF8.GetBytes(sal + clave);
                return Convert.ToBase64String(sha.ComputeHash(datos));
            }
        }

        /// <summary>Compara la clave ingresada con el hash almacenado.</summary>
        public static bool Verificar(string clave, string sal, string hashAlmacenado)
        {
            string hash = CalcularHash(clave, sal);
            return string.Equals(hash, hashAlmacenado, StringComparison.Ordinal);
        }
    }
}
