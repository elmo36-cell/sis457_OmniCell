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
    /// descripción y calidad. Además busca y filtra por marca y modelo de celular
    /// con la tabla Compatibilidad, que es como busca un cliente («iPhone 13»).
    /// La ficha (Detalle) muestra los modelos compatibles. Se puede ordenar por
    /// precio y dejar solo lo que tiene stock. El stock por sucursal y los mínimos
    /// no se publican: la página solo dice si hay disponibilidad.
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

        // Lista las pantallas activas y aplica búsqueda, filtros y orden.
        [HttpGet]
        public IActionResult Index(string parametro, string calidad, int? marca, int? modelo,
                                   string orden, bool soloDisponibles, int pagina = 1)
        {
            parametro = (parametro ?? string.Empty).Trim();
            calidad = (calidad ?? string.Empty).Trim();

            // Solo se aceptan los órdenes de la barra; cualquier otro es el de siempre.
            if (orden != "precio-asc" && orden != "precio-desc")
                orden = string.Empty;

            int idMarca = marca ?? 0;
            int idModelo = modelo ?? 0;

            // Un modelo pertenece a una marca: si llega solo el modelo se completa la
            // marca, así el panel muestra sus modelos y el título dice cuál se filtró.
            if (idModelo > 0)
            {
                var duenio = _context.Modelo
                    .Where(m => m.id == idModelo)
                    .Select(m => new { m.idMarca })
                    .FirstOrDefault();

                if (duenio == null) idModelo = 0;
                else if (idMarca == 0) idMarca = duenio.idMarca;
            }

            var consulta = _context.Pantalla.Where(x => x.estado == 1);

            if (parametro.Length > 0)
            {
                // paPantallaListar cambia los espacios por % para buscar varias palabras.
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                // El buscador también mira la compatibilidad: "iPhone 13" encuentra
                // las pantallas que sirven para ese equipo aunque el texto no lo diga.
                var porModeloBuscado = from c in _context.Compatibilidad
                                       join m in _context.Modelo on c.idModelo equals m.id
                                       join ma in _context.Marca on m.idMarca equals ma.id
                                       where c.estado == 1 && m.estado == 1
                                             && EF.Functions.Like(ma.nombre + " " + m.nombre, patron)
                                       select c.idPantalla;

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.sku + " " + x.descripcion + " " + x.calidad, patron)
                    || porModeloBuscado.Contains(x.id));
            }

            if (calidad.Length > 0)
            {
                consulta = consulta.Where(x => x.calidad == calidad);
            }

            // Filtro por marca: pantallas que encajan en algún modelo de esa marca.
            if (idMarca > 0)
            {
                var porMarca = from c in _context.Compatibilidad
                               join m in _context.Modelo on c.idModelo equals m.id
                               where c.estado == 1 && m.estado == 1 && m.idMarca == idMarca
                               select c.idPantalla;

                consulta = consulta.Where(x => porMarca.Contains(x.id));
            }

            // Filtro por un modelo concreto de celular.
            if (idModelo > 0)
            {
                var porModeloElegido = _context.Compatibilidad
                    .Where(c => c.estado == 1 && c.idModelo == idModelo)
                    .Select(c => c.idPantalla);

                consulta = consulta.Where(x => porModeloElegido.Contains(x.id));
            }

            // "Solo disponibles": el mismo criterio de stock que usa todo el
            // catálogo (Inventario, porque Pantalla.stockTotal no se sincroniza).
            if (soloDisponibles)
            {
                consulta = consulta.Where(x => _context.Inventario.Any(i =>
                    i.idPantalla == x.id && i.estado == 1 && i.stockActual > 0));
            }

            // Las calidades que existen hoy en la base alimentan el panel de filtros.
            ViewBag.Calidades = _context.Pantalla
                .Where(x => x.estado == 1)
                .Select(x => x.calidad)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            // Solo se ofrecen marcas y modelos con alguna pantalla compatible:
            // así ningún filtro del panel deja la lista vacía.
            var marcas = _context.Marca
                .Where(ma => ma.estado == 1 && _context.Modelo.Any(m =>
                       m.idMarca == ma.id && m.estado == 1 &&
                       _context.Compatibilidad.Any(c => c.idModelo == m.id && c.estado == 1)))
                .OrderBy(ma => ma.nombre)
                .ToList();

            // Los modelos son muchos en total: se listan recién al elegir la marca.
            var modelos = idMarca > 0
                ? _context.Modelo
                    .Where(m => m.idMarca == idMarca && m.estado == 1 &&
                           _context.Compatibilidad.Any(c => c.idModelo == m.id && c.estado == 1))
                    .OrderBy(m => m.nombre)
                    .ToList()
                : new List<Modelo>();

            ViewBag.Marcas = marcas;
            ViewBag.Modelos = modelos;
            ViewBag.Marca = idMarca > 0 ? idMarca : (int?)null;
            ViewBag.Modelo = idModelo > 0 ? idModelo : (int?)null;
            ViewBag.MarcaNombre = marcas.FirstOrDefault(x => x.id == idMarca)?.nombre;
            ViewBag.ModeloNombre = modelos.FirstOrDefault(x => x.id == idModelo)?.nombre;

            ViewBag.Parametro = parametro;
            ViewBag.Calidad = calidad;
            ViewBag.Orden = orden;
            ViewBag.SoloDisponibles = soloDisponibles;

            // 10 productos por página: la rejilla entra completa sin scroll.
            int total = consulta.Count();
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(total / (double)TamanoPagina));
            int paginaActual = Math.Clamp(pagina, 1, totalPaginas);

            // Orden del listado: por nombre (lo de siempre) o por precio, con el
            // desempate por descripción para que el paginado sea estable.
            var ordenada = orden switch
            {
                "precio-asc" => consulta.OrderBy(x => x.precioVenta).ThenBy(x => x.descripcion),
                "precio-desc" => consulta.OrderByDescending(x => x.precioVenta).ThenBy(x => x.descripcion),
                _ => consulta.OrderBy(x => x.descripcion)
            };

            var pantallas = ordenada
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
