namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos de la página del carrito: las líneas con su producto y los totales.
    /// </summary>
    public class CarritoViewModel
    {
        public List<CarritoLinea> Lineas { get; set; } = new List<CarritoLinea>();

        public int Unidades => Lineas.Sum(x => x.Cantidad);

        public decimal Total => Lineas.Sum(x => x.Subtotal);
    }

    /// <summary>
    /// Una línea del carrito ya cruzada con la base: producto, cantidad y subtotal.
    /// </summary>
    public class CarritoLinea
    {
        public Pantalla Pantalla { get; set; } = null!;
        public int Cantidad { get; set; }
        public string? Imagen { get; set; }

        public decimal Subtotal => Pantalla.precioVenta * Cantidad;
    }
}
