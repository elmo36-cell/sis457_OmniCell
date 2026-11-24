using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOmnicell.Data;
using WebOmnicell.Models;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Catálogo de pantallas. Hace lo mismo que paPantallaListar: solo activas y
    /// búsqueda por sku, descripción y calidad.
    /// </summary>
    public class CatalogoController : Controller
    {
        private readonly LabOmnicellContext _context;

        public CatalogoController(LabOmnicellContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string parametro)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
                return RedirectToAction("Login", "Account");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = _context.Pantalla.Where(x => x.estado == 1);

            if (parametro.Length > 0)
            {
                // paPantallaListar cambia los espacios por % para buscar varias palabras.
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x => EF.Functions.Like(
                    x.sku + " " + x.descripcion + " " + x.calidad, patron));
            }

            // BUG (heredado): Pantalla.stockTotal no se sincroniza con Inventario.stockActual,
            // así que el stock que se muestra puede no ser el real por sucursal.
            return View(consulta.OrderBy(x => x.descripcion).ToList());
        }
    }
}
