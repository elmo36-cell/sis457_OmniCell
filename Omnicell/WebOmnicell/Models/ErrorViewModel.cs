namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos que muestra la pantalla de error.
    /// </summary>
    public class ErrorViewModel
    {
        public string? IdSolicitud { get; set; }

        public bool MostrarIdSolicitud => !string.IsNullOrEmpty(IdSolicitud);
    }
}
