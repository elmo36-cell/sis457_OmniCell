using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebOmnicell.Seguridad
{
    /// <summary>
    /// Cifra la contraseña con el mismo algoritmo que el escritorio (CpOmnicell/Util.Cifrar),
    /// para poder compararla con lo que ya está guardado en la tabla Usuario.
    /// </summary>
    public static class Clave
    {
        // Frase y sal fijas, idénticas a las del escritorio.
        private const string Frase = "SIS457-1nf0!";

        private static readonly byte[] Sal =
        {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        };

        // Devuelve el texto cifrado en Base64, igual que Util.Cifrar del escritorio.
        public static string Cifrar(string textoPlano)
        {
            // El escritorio saca la clave (32 bytes) y luego el IV (16 bytes) del mismo flujo,
            // así que aquí se piden los 48 bytes juntos y se reparten igual.
            byte[] derivados = Rfc2898DeriveBytes.Pbkdf2(Frase, Sal, 1000, HashAlgorithmName.SHA1, 48);

            byte[] bytesTexto = Encoding.Unicode.GetBytes(textoPlano);

            using Aes cifrador = Aes.Create();
            cifrador.Key = derivados[..32];
            cifrador.IV = derivados[32..];

            using MemoryStream memoria = new MemoryStream();
            using (CryptoStream flujo = new CryptoStream(memoria, cifrador.CreateEncryptor(), CryptoStreamMode.Write))
            {
                flujo.Write(bytesTexto, 0, bytesTexto.Length);
            }

            return Convert.ToBase64String(memoria.ToArray());
        }
    }
}
