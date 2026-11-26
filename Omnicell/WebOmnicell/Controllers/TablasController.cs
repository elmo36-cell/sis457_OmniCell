using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOmnicell.Data;
using WebOmnicell.Models;
using WebOmnicell.Seguridad;

namespace WebOmnicell.Controllers
{
    /// <summary>
    /// Módulos de administración de las demás tablas. Replica los permisos del
    /// escritorio: el Administrador ve todo y el Vendedor solo Ventas (de su
    /// sucursal) y Clientes. Cada listado trae 10 filas por página.
    /// </summary>
    public class TablasController : Controller
    {
        private const int TamanoPagina = 10;

        private readonly LabOmnicellContext _context;

        public TablasController(LabOmnicellContext context)
        {
            _context = context;
        }

        // Panel con los módulos que puede usar el rol de la sesión.
        [HttpGet]
        public IActionResult Index()
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            ViewBag.EsAdmin = Acceso.EsAdministrador(HttpContext.Session);
            return View();
        }


        // ------------------------------- VENTAS -------------------------------

        [HttpGet]
        public IActionResult Ventas(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta =
                from v in _context.Venta
                join c in _context.Cliente on v.idCliente equals c.id
                join e in _context.Empleado on v.idEmpleado equals e.id
                join s in _context.Sucursal on v.idSucursal equals s.id
                where v.estado == 1
                select new
                {
                    v.id,
                    v.fechaVenta,
                    Cliente = c.razonSocial ?? (c.nombres + " " + c.primerApellido),
                    v.tipoPago,
                    Vendedor = e.nombres + " " + e.primerApellido,
                    Sucursal = s.nombre,
                    v.montoTotal,
                    v.idSucursal
                };

            // El Vendedor solo ve las ventas de su propia sucursal.
            if (!Acceso.EsAdministrador(HttpContext.Session))
            {
                int? sucursal = SucursalDelUsuario();
                consulta = sucursal.HasValue
                    ? consulta.Where(x => x.idSucursal == sucursal.Value)
                    : consulta.Where(x => false);
            }

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.Cliente, patron) ||
                    EF.Functions.Like(x.Vendedor, patron) ||
                    EF.Functions.Like(x.Sucursal, patron));
            }

            var pag = Paginar(consulta.OrderByDescending(x => x.fechaVenta), pagina);

            return Lista("Ventas", "Ventas", parametro,
                new[] { "N.º", "Fecha", "Cliente", "Vendedor", "Sucursal", "Pago", "Total (Bs)" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.fechaVenta.ToString("dd/MM/yyyy"),
                    x.Cliente ?? "—",
                    x.Vendedor ?? "—",
                    x.Sucursal ?? "—",
                    x.tipoPago ?? "—",
                    x.montoTotal.ToString("N2")
                }).ToList(),
                pag);
        }


        // ------------------------------ CLIENTES ------------------------------

        [HttpGet]
        public IActionResult Clientes(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = _context.Cliente
                .Where(x => x.estado == 1)
                .Select(x => new
                {
                    x.id,
                    x.nitCi,
                    Nombre = x.razonSocial ?? (x.nombres + " " + x.primerApellido),
                    x.telefono,
                    x.tipoCliente
                });

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.Nombre, patron) ||
                    EF.Functions.Like(x.nitCi, patron) ||
                    EF.Functions.Like(x.telefono, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.Nombre), pagina);

            return Lista("Clientes", "Clientes", parametro,
                new[] { "N.º", "Cliente", "CI / NIT", "Teléfono", "Tipo" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.Nombre ?? "—",
                    x.nitCi ?? "—",
                    x.telefono ?? "—",
                    x.tipoCliente ?? "—"
                }).ToList(),
                pag);
        }


        // ------------------------------ COMPRAS -------------------------------

        [HttpGet]
        public IActionResult Compras(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta =
                from c in _context.Compra
                join p in _context.Proveedor on c.idProveedor equals p.id
                join e in _context.Empleado on c.idEmpleado equals e.id
                where c.estado == 1
                select new
                {
                    c.id,
                    c.fechaCompra,
                    Proveedor = p.razonSocial,
                    Empleado = e.nombres + " " + e.primerApellido,
                    c.factura,
                    c.costoTotal
                };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.Proveedor, patron) ||
                    EF.Functions.Like(x.factura, patron));
            }

            var pag = Paginar(consulta.OrderByDescending(x => x.fechaCompra), pagina);

            return Lista("Compras", "Compras", parametro,
                new[] { "N.º", "Fecha", "Proveedor", "Empleado", "Factura", "Costo (Bs)" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.fechaCompra.ToString("dd/MM/yyyy"),
                    x.Proveedor ?? "—",
                    x.Empleado ?? "—",
                    x.factura ?? "—",
                    x.costoTotal.ToString("N2")
                }).ToList(),
                pag);
        }


        // ---------------------------- PROVEEDORES -----------------------------

        [HttpGet]
        public IActionResult Proveedores(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = _context.Proveedor
                .Where(x => x.estado == 1)
                .Select(x => new { x.id, x.razonSocial, x.pais, x.contactoPersona, x.telefono });

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.razonSocial, patron) ||
                    EF.Functions.Like(x.pais, patron) ||
                    EF.Functions.Like(x.contactoPersona, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.razonSocial), pagina);

            return Lista("Proveedores", "Proveedores", parametro,
                new[] { "N.º", "Razón social", "País", "Contacto", "Teléfono" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.razonSocial,
                    x.pais ?? "—",
                    x.contactoPersona ?? "—",
                    x.telefono ?? "—"
                }).ToList(),
                pag);
        }


        // ----------------------------- EMPLEADOS ------------------------------

        [HttpGet]
        public IActionResult Empleados(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta =
                from e in _context.Empleado
                join s in _context.Sucursal on e.idSucursal equals s.id
                where e.estado == 1
                select new
                {
                    e.id,
                    Nombre = e.nombres + " " + e.primerApellido,
                    e.ci,
                    e.celular,
                    e.cargo,
                    Sucursal = s.nombre
                };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.Nombre, patron) ||
                    EF.Functions.Like(x.ci, patron) ||
                    EF.Functions.Like(x.cargo, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.Nombre), pagina);

            return Lista("Empleados", "Empleados", parametro,
                new[] { "N.º", "Empleado", "CI", "Celular", "Cargo", "Sucursal" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.Nombre,
                    x.ci ?? "—",
                    x.celular.HasValue ? x.celular.Value.ToString() : "—",
                    x.cargo ?? "—",
                    x.Sucursal
                }).ToList(),
                pag);
        }


        // ------------------------------ USUARIOS ------------------------------

        [HttpGet]
        public IActionResult Usuarios(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta =
                from u in _context.Usuario
                join r in _context.Rol on u.idRol equals r.id
                join e in _context.Empleado on u.idEmpleado equals e.id into empleados
                from e in empleados.DefaultIfEmpty()
                where u.estado == 1
                select new
                {
                    u.id,
                    u.nombreUsuario,
                    Rol = r.nombre,
                    Empleado = e == null ? "—" : e.nombres + " " + e.primerApellido,
                    Estado = u.estado == 1 ? "Activo" : "Inactivo"
                };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.nombreUsuario, patron) ||
                    EF.Functions.Like(x.Rol, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.nombreUsuario), pagina);

            return Lista("Usuarios", "Usuarios", parametro,
                new[] { "N.º", "Usuario", "Rol", "Empleado", "Estado" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.nombreUsuario,
                    x.Rol,
                    x.Empleado,
                    x.Estado
                }).ToList(),
                pag);
        }


        // ------------------------------ PANTALLAS -----------------------------

        [HttpGet]
        public IActionResult Pantallas(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = _context.Pantalla
                .Where(x => x.estado == 1)
                .Select(x => new
                {
                    x.id,
                    x.sku,
                    x.descripcion,
                    x.calidad,
                    x.tecnologia,
                    x.precioVenta,
                    x.stockTotal
                });

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.sku, patron) ||
                    EF.Functions.Like(x.descripcion, patron) ||
                    EF.Functions.Like(x.calidad, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.descripcion), pagina);

            return Lista("Pantallas", "Pantallas", parametro,
                new[] { "N.º", "SKU", "Descripción", "Calidad", "Tecnología", "Precio (Bs)", "Stock" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.sku,
                    x.descripcion,
                    x.calidad,
                    x.tecnologia,
                    x.precioVenta.ToString("N2"),
                    x.stockTotal.ToString("N0")
                }).ToList(),
                pag);
        }


        // ----------------------------- INVENTARIO -----------------------------

        [HttpGet]
        public IActionResult Inventario(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta =
                from i in _context.Inventario
                join s in _context.Sucursal on i.idSucursal equals s.id
                join p in _context.Pantalla on i.idPantalla equals p.id
                where i.estado == 1
                select new
                {
                    i.id,
                    Sucursal = s.nombre,
                    p.sku,
                    Descripcion = p.descripcion,
                    i.stockActual,
                    i.stockMinimo
                };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.Sucursal, patron) ||
                    EF.Functions.Like(x.sku, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.Sucursal).ThenBy(x => x.sku), pagina);

            return Lista("Inventario", "Inventario", parametro,
                new[] { "N.º", "Sucursal", "SKU", "Pantalla", "Stock", "Mínimo" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.Sucursal,
                    x.sku,
                    x.Descripcion,
                    x.stockActual.ToString("N0"),
                    x.stockMinimo.ToString("N0")
                }).ToList(),
                pag);
        }


        // ------------------------------- MARCAS -------------------------------

        [HttpGet]
        public IActionResult Marcas(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = from m in _context.Marca
                           where m.estado == 1
                           select new
                           {
                               m.id,
                               m.nombre,
                               Modelos = _context.Modelo.Count(x => x.idMarca == m.id && x.estado == 1)
                           };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";
                consulta = consulta.Where(x => EF.Functions.Like(x.nombre, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.nombre), pagina);

            return Lista("Marcas", "Marcas", parametro,
                new[] { "N.º", "Marca", "Modelos registrados" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.nombre,
                    x.Modelos.ToString()
                }).ToList(),
                pag);
        }


        // ------------------------------- MODELOS ------------------------------

        [HttpGet]
        public IActionResult Modelos(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta =
                from m in _context.Modelo
                join ma in _context.Marca on m.idMarca equals ma.id
                where m.estado == 1
                select new { m.id, Marca = ma.nombre, m.nombre };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.nombre, patron) ||
                    EF.Functions.Like(x.Marca, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.Marca).ThenBy(x => x.nombre), pagina);

            return Lista("Modelos", "Modelos", parametro,
                new[] { "N.º", "Marca", "Modelo" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.Marca,
                    x.nombre
                }).ToList(),
                pag);
        }


        // ----------------------------- SUCURSALES -----------------------------

        [HttpGet]
        public IActionResult Sucursales(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = _context.Sucursal
                .Where(x => x.estado == 1)
                .Select(x => new { x.id, x.nombre, x.ciudad, x.direccion, x.telefono });

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";

                consulta = consulta.Where(x =>
                    EF.Functions.Like(x.nombre, patron) ||
                    EF.Functions.Like(x.ciudad, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.nombre), pagina);

            return Lista("Sucursales", "Sucursales", parametro,
                new[] { "N.º", "Sucursal", "Ciudad", "Dirección", "Teléfono" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.nombre,
                    x.ciudad ?? "—",
                    x.direccion ?? "—",
                    x.telefono ?? "—"
                }).ToList(),
                pag);
        }


        // -------------------------------- ROLES -------------------------------

        [HttpGet]
        public IActionResult Roles(string parametro, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            var consulta = from r in _context.Rol
                           where r.estado == 1
                           select new
                           {
                               r.id,
                               r.nombre,
                               r.descripcion,
                               Usuarios = _context.Usuario.Count(x => x.idRol == r.id && x.estado == 1)
                           };

            if (parametro.Length > 0)
            {
                string patron = "%" + parametro.Replace(" ", "%") + "%";
                consulta = consulta.Where(x => EF.Functions.Like(x.nombre, patron));
            }

            var pag = Paginar(consulta.OrderBy(x => x.nombre), pagina);

            return Lista("Roles", "Roles", parametro,
                new[] { "N.º", "Rol", "Descripción", "Usuarios" },
                pag.datos.Select(x => new[]
                {
                    x.id.ToString(),
                    x.nombre,
                    x.descripcion ?? "—",
                    x.Usuarios.ToString()
                }).ToList(),
                pag);
        }


        // ----------------------------- AUXILIARES -----------------------------

        // Devuelve la sucursal del empleado logueado (para filtrar ventas).
        private int? SucursalDelUsuario()
        {
            if (!int.TryParse(HttpContext.Session.GetString("idEmpleado"), out int idEmpleado))
                return null;

            return _context.Empleado
                .Where(x => x.id == idEmpleado)
                .Select(x => (int?)x.idSucursal)
                .FirstOrDefault();
        }

        // Calcula el total, la página válida y las 10 filas que se muestran.
        private static (List<T> datos, int pagina, int total, int totalPaginas) Paginar<T>(
            IQueryable<T> consulta, int pagina)
        {
            int total = consulta.Count();
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(total / (double)TamanoPagina));
            int actual = Math.Clamp(pagina, 1, totalPaginas);

            List<T> datos = consulta
                .Skip((actual - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();

            return (datos, actual, total, totalPaginas);
        }

        // Arma el modelo de la vista genérica de listados.
        private ViewResult Lista<T>(
            string titulo,
            string accion,
            string parametro,
            string[] columnas,
            List<string[]> filas,
            (List<T> datos, int pagina, int total, int totalPaginas) pag)
        {
            return View("Lista", new TablaViewModel
            {
                Titulo = titulo,
                Accion = accion,
                Parametro = parametro,
                Columnas = columnas,
                Filas = filas,
                Pagina = pag.pagina,
                Total = pag.total,
                TotalPaginas = pag.totalPaginas
            });
        }
    }
}
