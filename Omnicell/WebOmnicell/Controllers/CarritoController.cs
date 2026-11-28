using Microsoft.AspNetCore.Mvc;
using WebOmnicell.Data;
using WebOmnicell.Models;
using WebOmnicell.Servicios;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Carrito de compras. El contenido vive en la sesión del visitante; a la base
    /// solo se le consultan los datos del producto para mostrarlo. La confirmación
    /// del pedido todavía no está implementada.
    /// </summary>
    public class CarritoController : Controller
    {
        private readonly LabOmnicellContext _context;
        private readonly IWebHostEnvironment _entorno;

        public CarritoController(LabOmnicellContext context, IWebHostEnvironment entorno)
        {
            _context = context;
            _entorno = entorno;
        }

        // Página del carrito: cruza las líneas de la sesión con los productos activos.
        [HttpGet]
        public IActionResult Index()
        {
            var lineas = Carrito.Leer(HttpContext.Session);
            var ids = lineas.Select(x => x.IdPantalla).ToList();

            // Solo se listan productos activos: los dados de baja se descartan.
            var pantallas = _context.Pantalla
                .Where(x => ids.Contains(x.id) && x.estado == 1)
                .ToDictionary(x => x.id);

            var modelo = new CarritoViewModel();

            foreach (var linea in lineas)
            {
                if (!pantallas.TryGetValue(linea.IdPantalla, out var pantalla))
                    continue;

                modelo.Lineas.Add(new CarritoLinea
                {
                    Pantalla = pantalla,
                    Cantidad = linea.Cantidad,
                    Imagen = Imagenes.RutaPantalla(_entorno, pantalla.sku, pantalla.calidad)
                });
            }

            return View(modelo);
        }

        // Agrega unidades y vuelve a la página desde donde se hizo clic.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(int id, int cantidad, string? volver)
        {
            // Se comprueba en la base que el producto exista y siga activo.
            bool existe = _context.Pantalla.Any(x => x.id == id && x.estado == 1);

            if (existe)
                Carrito.Agregar(HttpContext.Session, id, cantidad);

            return Volver(volver);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cambiar(int id, int cantidad)
        {
            Carrito.Cambiar(HttpContext.Session, id, cantidad);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Quitar(int id)
        {
            Carrito.Quitar(HttpContext.Session, id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vaciar()
        {
            Carrito.Vaciar(HttpContext.Session);
            return RedirectToAction(nameof(Index));
        }

        // Solo se aceptan direcciones internas: evita que "volver" lleve a otro sitio.
        private IActionResult Volver(string? destino)
        {
            return Url.IsLocalUrl(destino)
                ? Redirect(destino!)
                : RedirectToAction("Index", "Catalogo");
        }
    }
}
