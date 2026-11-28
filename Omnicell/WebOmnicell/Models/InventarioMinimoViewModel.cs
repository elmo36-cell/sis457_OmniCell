using System.ComponentModel.DataAnnotations;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Formulario para fijar el stock mínimo de una fila de inventario
    /// (una sucursal y una pantalla). El mínimo vive en Inventario, no en Pantalla,
    /// así que se captura fila por fila desde Tablas/Inventario.
    /// </summary>
    public class InventarioMinimoViewModel
    {
        public int Id { get; set; }

        // Datos de contexto: solo se muestran, no se editan.
        public string Sucursal { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal StockActual { get; set; }

        // Unidades enteras: el stock se maneja así en toda la aplicación y evita
        // depender de la cultura del servidor al interpretar el separador decimal.
        [Display(Name = "Stock mínimo")]
        [Range(0, 1000000, ErrorMessage = "El stock mínimo debe estar entre 0 y 1.000.000.")]
        public int StockMinimo { get; set; }
    }
}
