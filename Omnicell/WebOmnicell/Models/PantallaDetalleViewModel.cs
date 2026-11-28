namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos de la ficha de un producto: la pantalla, su foto, si hay disponibilidad
    /// y los modelos compatibles. No incluye stock por sucursal ni mínimos: la ficha
    /// es pública y esos son datos internos.
    /// </summary>
    public class PantallaDetalleViewModel
    {
        public Pantalla Pantalla { get; set; } = null!;
        public string? Imagen { get; set; }
        public bool Disponible { get; set; }
        public List<string> ModelosCompatibles { get; set; } = new List<string>();
    }
}
