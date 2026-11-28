using System;
using System.Windows.Forms;

namespace CpMinerva
{
    // Formatos de presentación que comparten los formularios.
    public static class Formatos
    {
        public const string Monto = "N2";
        public const string Cantidad = "N0";
        public const string Fecha = "dd/MM/yyyy";
        public const string FechaHora = "dd/MM/yyyy HH:mm";
        public const string NumeroDocumento = "D5";
    }

    // Apoyo para las validaciones y los avisos repetidos de los formularios.
    public class Util
    {
        public const string TituloAplicacion = "OmniCell";
        public const string TituloConfirmacion = "::: Confirmación - OmniCell :::";

        private const char CtrlV = (char)22;

        // Devuelve true cuando el campo tiene texto; si está vacío avisa y lo enfoca.
        public static bool Requerido(Control campo, string mensaje)
        {
            if (!string.IsNullOrWhiteSpace(campo.Text))
                return true;

            Avisar(mensaje);
            campo.Focus();
            return false;
        }

        // true cuando el texto trae solo dígitos (CI/NIT).
        public static bool SoloDigitos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            foreach (char caracter in texto)
            {
                if (!char.IsDigit(caracter))
                    return false;
            }

            return true;
        }

        // Solo dígitos en el evento KeyPress; Ctrl + V queda bloqueado para no pegar letras.
        public static void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) && e.KeyChar != CtrlV)
                return;

            e.Handled = !char.IsDigit(e.KeyChar);
        }

        public static void Avisar(string mensaje, string titulo = null)
        {
            MessageBox.Show(mensaje, titulo ?? TituloAplicacion,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Informar(string mensaje, string titulo = null)
        {
            MessageBox.Show(mensaje, titulo ?? TituloAplicacion,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MostrarError(string mensaje, string titulo = null)
        {
            MessageBox.Show(mensaje, titulo ?? TituloAplicacion,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirmar(string pregunta)
        {
            return MessageBox.Show(pregunta, TituloConfirmacion,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
