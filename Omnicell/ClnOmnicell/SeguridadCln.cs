using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ClnOmnicell
{
    // Cifrado de contraseñas: en la base solo se guarda el texto cifrado.
    public static class SeguridadCln
    {
        private const string ClaveCifrado = "SIS457-1nf0!";

        // Sal fija del proyecto; debe conservarse igual para poder leer las claves ya guardadas.
        private static readonly byte[] Sal =
        {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d,
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        };

        private const int LargoClave = 32;
        private const int LargoVectorInicial = 16;

        public static string cifrar(string textoPlano)
        {
            if (textoPlano == null)
                throw new ArgumentNullException(nameof(textoPlano));

            byte[] bytesTexto = Encoding.Unicode.GetBytes(textoPlano);

            using (Aes cifrador = Aes.Create())
            using (Rfc2898DeriveBytes derivador = new Rfc2898DeriveBytes(ClaveCifrado, Sal))
            {
                cifrador.Key = derivador.GetBytes(LargoClave);
                cifrador.IV = derivador.GetBytes(LargoVectorInicial);

                using (MemoryStream memoria = new MemoryStream())
                {
                    using (CryptoStream flujo = new CryptoStream(memoria, cifrador.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        flujo.Write(bytesTexto, 0, bytesTexto.Length);
                        flujo.Close();
                    }

                    return Convert.ToBase64String(memoria.ToArray());
                }
            }
        }
    }
}
