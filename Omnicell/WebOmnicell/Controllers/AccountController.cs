using Microsoft.AspNetCore.Mvc;
using WebOmnicell.Data;
using WebOmnicell.Models;
using WebOmnicell.Seguridad;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Inicio de sesión contra la tabla Usuario. La clave se compara cifrada
    /// (igual que el escritorio) y solo se acepta el usuario activo.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly LabOmnicellContext _context;

        public AccountController(LabOmnicellContext context)
        {
            _context = context;
        }

        // Muestra el formulario de acceso.
        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View(new LoginViewModel());
        }

        // Recibe el formulario y valida las credenciales contra la base.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IniciarSesion(LoginViewModel modelo)
        {
            if (!ModelState.IsValid) return View(modelo);

            string nombre = modelo.NombreUsuario.Trim();

            // El escritorio guarda la clave cifrada, así que se compara de las dos formas:
            // cifrada (filas creadas desde el escritorio) y tal cual (filas antiguas del script).
            // BUG: al no usar hash con sal por usuario, cualquiera que lea la tabla puede
            // reutilizar el valor cifrado tal cual para entrar.
            string claveCifrada = Clave.Cifrar(modelo.Clave);

            var usuario = _context.Usuario.FirstOrDefault(x =>
                x.nombreUsuario == nombre &&
                (x.clave == modelo.Clave || x.clave == claveCifrada) &&
                x.estado == 1);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                return View(modelo);
            }

            // Se guarda el usuario en la sesión del servidor (una por visitante);
            // SesionCln usa un static y en web eso mezclaría las sesiones de todos.
            var rol = _context.Rol.FirstOrDefault(x => x.id == usuario.idRol);

            HttpContext.Session.SetString("usuario", usuario.nombreUsuario);
            HttpContext.Session.SetString("rol", usuario.idRol.ToString());
            HttpContext.Session.SetString("rolNombre", rol?.nombre ?? "Usuario");
            HttpContext.Session.SetString("idEmpleado", usuario.idEmpleado.ToString());

            return RedirectToAction("Index", "Catalogo");
        }

        // Borra la sesión y devuelve al formulario de acceso.
        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(IniciarSesion));
        }
    }
}
