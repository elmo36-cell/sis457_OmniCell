using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace WebOmnicell.Servicios
{
    /// <summary>
    /// Busca la foto de una pantalla en wwwroot: primero la del SKU
    /// (images/pantallas) y, si no hay, la de su calidad (images/categorias).
    /// Si tampoco existe, la vista muestra el ícono de siempre.
    /// </summary>
    public static class Imagenes
    {
        private const string CarpetaPantallas = "images/pantallas";
        private const string CarpetaCategorias = "images/categorias";

        // Extensiones aceptadas, en orden de preferencia: webp primero porque pesa menos.
        private static readonly string[] Extensiones = { ".webp", ".jpg", ".jpeg", ".png" };

        // Devuelve la ruta web (ej. /images/categorias/oled-original.jpg) o null si no hay foto.
        public static string? RutaPantalla(IWebHostEnvironment entorno, string sku, string categoria)
        {
            return Buscar(entorno, CarpetaPantallas, sku)
                ?? Buscar(entorno, CarpetaCategorias, categoria);
        }

        // Busca un archivo llamado como 'nombre' dentro de 'carpeta'.
        private static string? Buscar(IWebHostEnvironment entorno, string carpeta, string? nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return null;

            IDirectoryContents contenido = entorno.WebRootFileProvider.GetDirectoryContents(carpeta);

            if (!contenido.Exists)
                return null;

            // Se recorre la carpeta en vez de pedir la ruta exacta, por dos motivos:
            // el nombre puede diferir en mayúsculas o separadores ("OLED Original.PNG"),
            // y hay que devolver el nombre real del archivo, que es el único que se sirve.
            string buscado = Normalizar(nombre);
            string? encontrado = null;
            int mejorExtension = int.MaxValue;

            foreach (IFileInfo archivo in contenido)
            {
                if (archivo.IsDirectory)
                    continue;

                int posicion = Array.FindIndex(Extensiones, e =>
                    string.Equals(e, Path.GetExtension(archivo.Name), StringComparison.OrdinalIgnoreCase));

                if (posicion < 0 || posicion >= mejorExtension)
                    continue;

                if (!string.Equals(Normalizar(Path.GetFileNameWithoutExtension(archivo.Name)), buscado, StringComparison.OrdinalIgnoreCase))
                    continue;

                mejorExtension = posicion;
                encontrado = archivo.Name;
            }

            return encontrado == null
                ? null
                : "/" + carpeta + "/" + Uri.EscapeDataString(encontrado);
        }

        // Para comparar, "OLED Original", "oled_original" y "OLED-Original" son el mismo nombre.
        private static string Normalizar(string nombre)
        {
            return nombre.Trim().ToLowerInvariant()
                .Replace(' ', '-')
                .Replace('_', '-');
        }
    }
}
