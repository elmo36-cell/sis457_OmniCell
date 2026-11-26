using Microsoft.AspNetCore.Hosting;

namespace WebOmnicell.Servicios
{
    /// <summary>
    /// Busca la foto de una pantalla en una carpeta de wwwroot/images/pantallas, usando
    /// el SKU como nombre de archivo. Si no existe, la vista muestra el ícono de siempre.
    /// </summary>
    public static class Imagenes
    {
        // Devuelve la ruta web (ej. /images/pantallas/IP13PRO-OL.webp) o null si no hay foto.
        public static string? RutaPantalla(IWebHostEnvironment entorno, string sku)
        {
            string relativa = $"images/pantallas/{sku}.webp";

            return entorno.WebRootFileProvider.GetFileInfo(relativa).Exists
                ? "/" + relativa
                : null;
        }
    }
}
