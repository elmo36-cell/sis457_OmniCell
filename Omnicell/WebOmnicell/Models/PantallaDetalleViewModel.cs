namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos de la ficha de un producto: la pantalla, su foto, los modelos
    /// compatibles y el stock que hay en cada sucursal.
    /// </summary>
    public class PantallaDetalleViewModel
    {
        public Pantalla Pantalla { get; set; } = null!;
        public string? Imagen { get; set; }
        public List<string> ModelosCompatibles { get; set; } = new List<string>();
        public List<StockPorSucursal> Stocks { get; set; } = new List<StockPorSucursal>();
    }

    /// <summary>
    /// Una fila de inventario de la ficha: cuánto hay en una sucursal y su mínimo.
    /// </summary>
    public class StockPorSucursal
    {
        public string Sucursal { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public decimal Stock { get; set; }
        public decimal Minimo { get; set; }
    }
}
