using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpMinerva
{
    public enum Estado { Activo = 1, Inactivo = 0, Eliminado = -1 };

    public class Util
    {
        public static Usuario usuario;
        public static bool notPaste = true;
        // Cifra la contraseña antes de guardarla en la base.
        public static string Cifrar(string textoPlano)
        {
            string claveCifrado = "SIS457-1nf0!";
            byte[] bytesTexto = Encoding.Unicode.GetBytes(textoPlano);
            using (Aes cifrador = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(claveCifrado, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                cifrador.Key = pdb.GetBytes(32);
                cifrador.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, cifrador.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesTexto, 0, bytesTexto.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Validar sólo números en el evento KeyPress
        /// </summary>
        public static void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22 && notPaste) e.Handled = true; //Deshabilitar Ctrl + V (Pegar)
            else
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = false;
                else if (Char.IsControl(e.KeyChar)) e.Handled = false;
                else e.Handled = true;
            }
        }

        /// <summary>
        /// Validar sólo números enteros o decimales en el evento KeyPress
        /// </summary>
        public static void soloDecimales(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22 && notPaste) e.Handled = true; //Deshabilitar Ctrl + V (Pegar)
            else
            {
                char separtor = Char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                char group = Char.Parse(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator);
                int points = ((Control)sender).Text.Split(separtor).Count();

                if (group.Equals(e.KeyChar)) e.KeyChar = separtor;

                if (Char.IsDigit(e.KeyChar)) e.Handled = false;
                else if (Char.IsControl(e.KeyChar)) e.Handled = false;
                else if (separtor.Equals(e.KeyChar) && points <= 1) e.Handled = false;
                else e.Handled = true;
                ((Control)sender).Text = ((Control)sender).Text.Replace(group, separtor);
            }
        }

        /// <summary>
        /// Validar sólo letras en el evento KeyPress
        /// </summary>
        public static void soloLetras(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)) e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
        }

        /// <summary>
        /// Validar ni números ni letras en el evento KeyPress
        /// </summary>
        public static void soloSimbolos(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || Char.IsPunctuation(e.KeyChar))) e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar)) e.Handled = false;
            else if (Char.IsSymbol(e.KeyChar)) e.Handled = false;
            else if ((int)e.KeyChar <= 47) e.Handled = false;
            else e.Handled = true;
        }


        public static void sinBotonDerecho(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //if (isMsgTxtMouseDown) MessageBox.Show(msgTxtMouseDown);
            }
        }
    }
}
