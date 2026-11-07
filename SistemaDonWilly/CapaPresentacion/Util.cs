using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    /// <summary>
    /// Apoyo comun a los formularios: mensajes comprensibles, formato de las
    /// grillas y comprobacion de permisos antes de abrir una pantalla (RNF-01, RNF-05).
    /// </summary>
    internal static class Util
    {
        public const string TITULO = "Sistema Don Willy";

        public static readonly Color ColorPrimario = Color.FromArgb(122, 46, 22);
        public static readonly Color ColorFondo = Color.FromArgb(247, 244, 240);

        #region mensajes

        public static void Informar(string mensaje)
        {
            MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Advertir(string mensaje)
        {
            MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Muestra el mensaje de la regla de negocio tal cual y resume los
        /// errores tecnicos sin exponer detalles de la base de datos.
        /// </summary>
        public static void Error(Exception ex)
        {
            string mensaje = ex is ReglaNegocioException
                ? ex.Message
                : "No se pudo completar la operacion." + Environment.NewLine + ex.Message;

            MessageBox.Show(mensaje, TITULO, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string pregunta)
        {
            return MessageBox.Show(pregunta, TITULO, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #endregion mensajes

        #region grillas

        /// <summary>Oculta columnas tecnicas y aplica titulos legibles.</summary>
        public static void FormatearGrilla(DataGridView grilla, params string[] columnasVisibles)
        {
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            grilla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grilla.ColumnHeadersHeight = 30;
            grilla.AlternatingRowsDefaultCellStyle.BackColor = ColorFondo;
            grilla.RowTemplate.Height = 24;

            if (columnasVisibles.Length == 0)
            {
                return;
            }

            List<string> visibles = new List<string>(columnasVisibles);

            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                columna.Visible = visibles.Contains(columna.Name);
            }

            for (int i = 0; i < visibles.Count; i++)
            {
                if (grilla.Columns.Contains(visibles[i]))
                {
                    grilla.Columns[visibles[i]].DisplayIndex = i;
                    grilla.Columns[visibles[i]].HeaderText = Titulo(visibles[i]);
                }
            }
        }

        public static void FormatoMoneda(DataGridView grilla, params string[] columnas)
        {
            foreach (string columna in columnas)
            {
                if (grilla.Columns.Contains(columna))
                {
                    grilla.Columns[columna].DefaultCellStyle.Format = "N2";
                    grilla.Columns[columna].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        public static void Encabezado(DataGridView grilla, string columna, string texto)
        {
            if (grilla.Columns.Contains(columna))
            {
                grilla.Columns[columna].HeaderText = texto;
            }
        }

        /// <summary>Convierte idProducto en "Id producto" para los encabezados.</summary>
        private static string Titulo(string nombreColumna)
        {
            string texto = string.Empty;

            foreach (char c in nombreColumna)
            {
                if (char.IsUpper(c) && texto.Length > 0)
                {
                    texto += " " + char.ToLower(c);
                }
                else
                {
                    texto += c;
                }
            }
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }

        #endregion grillas

        #region permisos

        /// <summary>Comprueba el perfil antes de abrir una pantalla (RNF-01).</summary>
        public static bool TienePermiso(params string[] perfiles)
        {
            foreach (string perfil in perfiles)
            {
                if (entSesion.TienePerfil(perfil))
                {
                    return true;
                }
            }

            Advertir("Su perfil no tiene permiso para esta funcion.");
            return false;
        }

        #endregion permisos

        #region conversiones

        public static decimal ADecimal(string texto)
        {
            decimal valor;
            return decimal.TryParse(texto, out valor) ? valor : 0m;
        }

        public static int AEntero(object valor)
        {
            int numero;
            return int.TryParse(Convert.ToString(valor), out numero) ? numero : 0;
        }

        #endregion conversiones
    }
}
