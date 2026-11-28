using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOmnicell.Data;
using WebOmnicell.Models;
using WebOmnicell.Servicios;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Catálogo de pantallas, público: no pide sesión para que lo vea un cliente.
    /// Hace lo mismo que paPantallaListar: solo las activas y búsqueda por sku,
    /// descripción y calidad. La ficha (Detalle) muestra además los modelos
    /// compatibles. El stock por sucursal y los mínimos no se publican: la página
    /// solo dice si el producto está disponible.
    /// </summary>
    public class CatalogoController : Controller
    {
        private const int TamanoPagina = 10;

        private readonly LabOmnicellContext _context;
        private readonly IWebHostEnvironment _entorno;

        public CatalogoController(LabOmnicellContext context, IWebHostEnvironment entorno)
        {
            _context = context;
            _entorno = entorno;
        }

        // Lista las pantallas activas y aplica el filtro del buscador y de calidad.
        [HttpGet]
        public IActionResult Index(string parametro, string calidad, int pagina = 1)
        {
            parametro = (parametro ?? string.Empty).Trim();
            calidad = (calidad ?? string.Empty).Trim();

            var consulta = _context.Pantalla.Where(x => x.estado == 1);

            if (parametro.Length > 0)
            {
                // paPantallaListar cambia los espacios por % para buscar varias palabras.
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x => EF.Functions.Like(
                    x.sku + " " + x.descripcion + " " + x.calidad, patron));
            }

            if (calidad.Length > 0)
            {
                consulta = consulta.Where(x => x.calidad == calidad);
            }

            // Las calidades que existen hoy en la base alimentan el panel de filtros.
            ViewBag.Calidades = _context.Pantalla
                .Where(x => x.estado == 1)
                .Select(x => x.calidad)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            ViewBag.Parametro = parametro;
            ViewBag.Calidad = calidad;

            // 10 productos por página: la rejilla entra completa sin scroll.
            int total = consulta.Count();
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(total / (double)TamanoPagina));
            int paginaActual = Math.Clamp(pagina, 1, totalPaginas);

            var pantallas = consulta
                .OrderBy(x => x.descripcion)
                .Skip((paginaActual - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();

            ViewBag.Total = total;
            ViewBag.Pagina = paginaActual;
            ViewBag.TotalPaginas = totalPaginas;

            // Disponibilidad de la página. Se calcula con Inventario porque
            // Pantalla.stockTotal no se sincroniza (BUG heredado) y ya no se muestra.
            var idsPagina = pantallas.Select(x => x.id).ToList();

            ViewBag.Disponibles = _context.Inventario
                .Where(x => idsPagina.Contains(x.idPantalla) && x.estado == 1 && x.stockActual > 0)
                .Select(x => x.idPantalla)
                .Distinct()
                .ToList();

            // Productos del filtro que tienen stock en alguna sucursal.
            ViewBag.ConStock = consulta.Count(x => _context.Inventario.Any(i =>
                i.idPantalla == x.id && i.estado == 1 && i.stockActual > 0));

            return View(pantallas);
        }

        // Ficha del producto: precio, modelos compatibles y disponibilidad.
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var pantalla = _context.Pantalla.FirstOrDefault(x => x.id == id && x.estado == 1);

            if (pantalla == null) return NotFound();

            // Disponibilidad pública: alcanza con que una sucursal tenga stock.
            bool disponible = _context.Inventario.Any(i =>
                i.idPantalla == id && i.estado == 1 && i.stockActual > 0);

            var modelo = new PantallaDetalleViewModel
            {
                Pantalla = pantalla,
                Imagen = Imagenes.RutaPantalla(_entorno, pantalla.sku, pantalla.calidad),
                Disponible = disponible,

                // Modelos de celular en los que encaja esta pantalla.
                ModelosCompatibles =
                    (from c in _context.Compatibilidad
                     join m in _context.Modelo on c.idModelo equals m.id
                     join ma in _context.Marca on m.idMarca equals ma.id
                     where c.idPantalla == id && c.estado == 1 && m.estado == 1
                     orderby ma.nombre, m.nombre
                     select ma.nombre + " · " + m.nombre).ToList()
            };

            return View(modelo);
        }
    }
}
