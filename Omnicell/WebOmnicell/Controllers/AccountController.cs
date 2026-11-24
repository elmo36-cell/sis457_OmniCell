using Microsoft.AspNetCore.Mvc;
using WebOmnicell.Data;
using WebOmnicell.Models;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Login contra la tabla Usuario. La clave se compara tal cual está guardada en
    /// Usuario.clave, sin cifrar, y solo se acepta el usuario activo (estado = 1).
    /// </summary>
    public class AccountController : Controller
    {
        private readonly LabOmnicellContext _context;

        public AccountController(LabOmnicellContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid) return View(modelo);

            string nombre = modelo.NombreUsuario.Trim();

            // BUG: la contraseña se guarda y se compara en texto plano, así que cualquiera
            // que lea la tabla la ve.
            var usuario = _context.Usuario.FirstOrDefault(x =>
                x.nombreUsuario == nombre &&
                x.clave == modelo.Clave &&
                x.estado == 1);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                return View(modelo);
            }

            // SesionCln guarda el usuario en un static y en web eso mezcla sesiones;
            // aquí se usa la sesión del servidor por petición.
            HttpContext.Session.SetString("usuario", usuario.nombreUsuario);

            return RedirectToAction("Index", "Catalogo");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}
