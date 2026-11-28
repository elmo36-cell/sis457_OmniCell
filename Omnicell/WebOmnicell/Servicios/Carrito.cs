using System.Text.Json;

namespace WebOmnicell.Servicios
{
    /// <summary>
    /// Carrito de compras guardado en la sesión del visitante. No usa la base: solo
    /// recuerda qué pantalla eligió y cuántas unidades, para mostrarlo en la página
    /// del carrito y en el contador del encabezado.
    /// </summary>
    public static class Carrito
    {
        // Clave de la sesión donde viaja el carrito en formato JSON.
        public const string Clave = "carrito";

        // Tope por línea: el stock real se valida recién al confirmar el pedido.
        public const int MaximoPorLinea = 99;

        // Lee el carrito de la sesión (lista vacía si todavía no hay nada).
        public static List<LineaCarrito> Leer(ISession sesion)
        {
            string? json = sesion.GetString(Clave);

            if (string.IsNullOrWhiteSpace(json))
                return new List<LineaCarrito>();

            try
            {
                return JsonSerializer.Deserialize<List<LineaCarrito>>(json)
                       ?? new List<LineaCarrito>();
            }
            catch (JsonException)
            {
                // Si el contenido quedó ilegible, se empieza de cero.
                return new List<LineaCarrito>();
            }
        }

        // Suma unidades a la línea del producto (o la crea si todavía no está).
        public static void Agregar(ISession sesion, int idPantalla, int cantidad)
        {
            List<LineaCarrito> lineas = Leer(sesion);
            LineaCarrito? linea = lineas.FirstOrDefault(x => x.IdPantalla == idPantalla);

            if (linea == null)
            {
                linea = new LineaCarrito { IdPantalla = idPantalla };
                lineas.Add(linea);
            }

            linea.Cantidad = Math.Clamp(linea.Cantidad + Math.Max(cantidad, 1), 1, MaximoPorLinea);

            Guardar(sesion, lineas);
        }

        // Fija la cantidad de una línea; con 0 o menos, la saca del carrito.
        public static void Cambiar(ISession sesion, int idPantalla, int cantidad)
        {
            List<LineaCarrito> lineas = Leer(sesion);
            LineaCarrito? linea = lineas.FirstOrDefault(x => x.IdPantalla == idPantalla);

            if (linea == null) return;

            if (cantidad <= 0)
                lineas.Remove(linea);
            else
                linea.Cantidad = Math.Clamp(cantidad, 1, MaximoPorLinea);

            Guardar(sesion, lineas);
        }

        public static void Quitar(ISession sesion, int idPantalla)
        {
            List<LineaCarrito> lineas = Leer(sesion);
            lineas.RemoveAll(x => x.IdPantalla == idPantalla);
            Guardar(sesion, lineas);
        }

        public static void Vaciar(ISession sesion)
        {
            sesion.Remove(Clave);
        }

        // Unidades totales: es el número que muestra el contador del encabezado.
        public static int Unidades(ISession sesion)
        {
            return Leer(sesion).Sum(x => x.Cantidad);
        }

        private static void Guardar(ISession sesion, List<LineaCarrito> lineas)
        {
            if (lineas.Count == 0)
            {
                sesion.Remove(Clave);
                return;
            }

            sesion.SetString(Clave, JsonSerializer.Serialize(lineas));
        }
    }

    /// <summary>
    /// Una línea del carrito: la pantalla elegida y cuántas unidades.
    /// </summary>
    public class LineaCarrito
    {
        public int IdPantalla { get; set; }
        public int Cantidad { get; set; }
    }
}
