using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    /// <summary>Cuadro de dialogo sencillo para pedir un texto obligatorio al usuario.</summary>
    internal static class Interaccion
    {
        /// <summary>Devuelve el texto ingresado o null si se cancela.</summary>
        public static string Pedir(string pregunta, string titulo)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = titulo;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;
                dlg.ClientSize = new Size(420, 150);
                dlg.Font = new Font("Segoe UI", 9F);

                Label lbl = new Label();
                lbl.Text = pregunta;
                lbl.Location = new Point(14, 14);
                lbl.Size = new Size(392, 20);

                TextBox txt = new TextBox();
                txt.Location = new Point(14, 40);
                txt.Size = new Size(392, 23);
                txt.MaxLength = 150;

                Button ok = new Button();
                ok.Text = "Aceptar";
                ok.DialogResult = DialogResult.OK;
                ok.Location = new Point(222, 100);
                ok.Size = new Size(90, 28);

                Button cancelar = new Button();
                cancelar.Text = "Cancelar";
                cancelar.DialogResult = DialogResult.Cancel;
                cancelar.Location = new Point(316, 100);
                cancelar.Size = new Size(90, 28);

                dlg.Controls.AddRange(new Control[] { lbl, txt, ok, cancelar });
                dlg.AcceptButton = ok;
                dlg.CancelButton = cancelar;

                while (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (txt.Text.Trim().Length > 0)
                    {
                        return txt.Text.Trim();
                    }
                    MessageBox.Show("Este dato es obligatorio.", Util.TITULO,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }
    }
}
