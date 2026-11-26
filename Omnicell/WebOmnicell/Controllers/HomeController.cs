using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebOmnicell.Models;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Páginas generales del sitio: inicio, aviso de privacidad y pantalla de error.
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacidad()
        {
            return View();
        }

        // Muestra la pantalla de error con el identificador de la petición.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                IdSolicitud = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
