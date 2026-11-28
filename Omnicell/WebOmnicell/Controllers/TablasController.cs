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

            // SELECT con JOIN: venta + cliente + empleado + sucursal (solo activas).
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
                    x.fechaVenta.ToString("dd/MM/yyyy HH:mm"),
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
                pag,
                accionEditar: "Cliente",
                textoNuevo: "Nuevo cliente",
                ids: pag.datos.Select(x => x.id).ToList());
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

            // SELECT con JOIN: compra + proveedor + empleado (solo activas).
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
        public IActionResult Inventario(string parametro, bool soloBajo = false, int pagina = 1)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            parametro = (parametro ?? string.Empty).Trim();

            // Regla de stock bajo: stock en o por debajo del mínimo.
            int enAlerta = _context.Inventario
                .Count(i => i.estado == 1 && i.stockActual <= i.stockMinimo);

            var filasInventario = _context.Inventario.Where(i => i.estado == 1);

            if (soloBajo)
                filasInventario = filasInventario.Where(i => i.stockActual <= i.stockMinimo);

            var consulta =
                from i in filasInventario
                join s in _context.Sucursal on i.idSucursal equals s.id
                join p in _context.Pantalla on i.idPantalla equals p.id
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
                pag,
                accionEditar: "InventarioMinimo",
                ids: pag.datos.Select(x => x.id).ToList(),
                alertas: pag.datos.Select(x => x.stockActual <= x.stockMinimo).ToList(),
                columnaAlerta: 4,
                filtroTexto: "Solo stock bajo",
                filtroActivo: soloBajo,
                filtroTotal: enAlerta);
        }


        // --------------------------- STOCK MÍNIMO -----------------------------

        [HttpGet]
        public IActionResult InventarioMinimo(int id)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            var modelo = datosInventario(id);

            if (modelo == null) return NotFound();

            return View(modelo);
        }

        // Guarda solo el mínimo de esa fila: no toca el stock ni el resto del inventario.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InventarioMinimo(InventarioMinimoViewModel modelo)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            if (!Acceso.PuedeVerAdministracion(HttpContext.Session))
                return View("SinPermiso");

            // Sucursal, SKU y stock actual no vienen del formulario: se releen de la base.
            var datos = datosInventario(modelo.Id);

            if (datos == null) return NotFound();

            if (!ModelState.IsValid)
            {
                datos.StockMinimo = modelo.StockMinimo;
                return View(datos);
            }

            var fila = _context.Inventario.FirstOrDefault(i => i.id == modelo.Id && i.estado == 1);

            if (fila == null) return NotFound();

            fila.stockMinimo = modelo.StockMinimo;
            _context.SaveChanges();

            TempData["ok"] = "Mínimo actualizado: " + modelo.StockMinimo.ToString("N0") +
                             " unidad(es) para " + datos.Sku + " en " + datos.Sucursal + ".";

            return RedirectToAction("Inventario");
        }

        // Fila de inventario con los datos que muestra el formulario del mínimo.
        private InventarioMinimoViewModel? datosInventario(int id)
        {
            return (from i in _context.Inventario
                    join s in _context.Sucursal on i.idSucursal equals s.id
                    join p in _context.Pantalla on i.idPantalla equals p.id
                    where i.id == id && i.estado == 1
                    select new InventarioMinimoViewModel
                    {
                        Id = i.id,
                        Sucursal = s.nombre,
                        Sku = p.sku,
                        Descripcion = p.descripcion,
                        StockActual = i.stockActual,

                        // El mínimo se maneja en unidades enteras (ver el view model).
                        StockMinimo = (int)i.stockMinimo
                    }).FirstOrDefault();
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


        // ------------------ CLIENTES: ALTA, EDICIÓN Y BAJA ------------------

        // Formulario del cliente. Con "id" carga un cliente existente (rellena todos
        // los campos) y con "buscar" trae coincidencias por nombre o CI/NIT.
        [HttpGet]
        public IActionResult Cliente(int? id, string? buscar)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            var modelo = new ClienteFormViewModel { Buscar = (buscar ?? string.Empty).Trim() };

            if (id.HasValue)
            {
                var cliente = _context.Cliente.FirstOrDefault(x => x.id == id.Value && x.estado == 1);

                if (cliente == null) return NotFound();

                modelo.Id = cliente.id;
                modelo.NitCi = cliente.nitCi ?? string.Empty;
                modelo.Nombres = cliente.nombres;
                modelo.PrimerApellido = cliente.primerApellido;
                modelo.SegundoApellido = cliente.segundoApellido;
                modelo.RazonSocial = cliente.razonSocial;
                modelo.Telefono = cliente.telefono;
                modelo.Direccion = cliente.direccion;
                modelo.TipoCliente = cliente.tipoCliente;
            }

            PrepararCliente(modelo);
            return View(modelo);
        }

        // Guarda el cliente con las reglas de ClienteCln.crear / ClienteCln.actualizar:
        // CI/NIT único, estado activo y usuario que lo registra.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarCliente(ClienteFormViewModel modelo)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            modelo.NitCi = (modelo.NitCi ?? string.Empty).Trim();
            modelo.Buscar = (modelo.Buscar ?? string.Empty).Trim();

            if (modelo.NitCi.Length == 0)
                ModelState.AddModelError(nameof(modelo.NitCi), "Ingrese el CI/NIT del cliente.");
            else if (!modelo.NitCi.All(char.IsDigit))
                ModelState.AddModelError(nameof(modelo.NitCi), "El CI/NIT solo admite números.");

            bool tieneNombre = !string.IsNullOrWhiteSpace(modelo.Nombres) ||
                               !string.IsNullOrWhiteSpace(modelo.RazonSocial);

            if (!tieneNombre)
                ModelState.AddModelError(nameof(modelo.Nombres), "Ingrese el nombre o la razón social del cliente.");

            if (string.IsNullOrWhiteSpace(modelo.TipoCliente))
                ModelState.AddModelError(nameof(modelo.TipoCliente), "Seleccione el tipo de cliente.");

            // Mismo control de duplicados que hace el escritorio antes de insertar.
            if (modelo.NitCi.Length > 0)
            {
                var repetidos = _context.Cliente.Where(x => x.estado == 1 && x.nitCi == modelo.NitCi);

                if (modelo.Id.HasValue)
                    repetidos = repetidos.Where(x => x.id != modelo.Id.Value);

                if (repetidos.Any())
                    ModelState.AddModelError(nameof(modelo.NitCi), "Ya existe un cliente con ese CI/NIT.");
            }

            if (!ModelState.IsValid)
            {
                PrepararCliente(modelo);
                return View("Cliente", modelo);
            }

            string usuario = HttpContext.Session.GetString("usuario") ?? string.Empty;

            if (modelo.Id.HasValue)
            {
                var cliente = _context.Cliente.FirstOrDefault(x => x.id == modelo.Id.Value && x.estado == 1);

                if (cliente == null) return NotFound();

                cliente.nitCi = modelo.NitCi;
                cliente.nombres = modelo.Nombres?.Trim();
                cliente.primerApellido = modelo.PrimerApellido?.Trim();
                cliente.segundoApellido = modelo.SegundoApellido?.Trim();
                cliente.razonSocial = modelo.RazonSocial?.Trim();
                cliente.telefono = modelo.Telefono?.Trim();
                cliente.direccion = modelo.Direccion?.Trim();
                cliente.tipoCliente = modelo.TipoCliente;

                _context.SaveChanges();

                TempData["ok"] = "Cliente actualizado correctamente.";
            }
            else
            {
                _context.Cliente.Add(new Cliente
                {
                    nitCi = modelo.NitCi,
                    nombres = modelo.Nombres?.Trim(),
                    primerApellido = modelo.PrimerApellido?.Trim(),
                    segundoApellido = modelo.SegundoApellido?.Trim(),
                    razonSocial = modelo.RazonSocial?.Trim(),
                    telefono = modelo.Telefono?.Trim(),
                    direccion = modelo.Direccion?.Trim(),
                    tipoCliente = modelo.TipoCliente,
                    usuarioRegistro = usuario,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                });

                _context.SaveChanges();

                TempData["ok"] = "Cliente registrado correctamente.";
            }

            return RedirectToAction(nameof(Clientes));
        }

        // Baja lógica, igual que ClienteCln.eliminar: no se borra la fila.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarCliente(int id)
        {
            if (!Acceso.HaySesion(HttpContext.Session))
                return RedirectToAction("IniciarSesion", "Account");

            var cliente = _context.Cliente.FirstOrDefault(x => x.id == id && x.estado == 1);

            if (cliente == null) return NotFound();

            cliente.estado = -1;
            cliente.usuarioRegistro = HttpContext.Session.GetString("usuario") ?? string.Empty;

            _context.SaveChanges();

            TempData["ok"] = "Cliente dado de baja correctamente.";
            return RedirectToAction(nameof(Clientes));
        }

        // Tipos de cliente del desplegable y coincidencias del buscador por nombre o CI/NIT.
        private void PrepararCliente(ClienteFormViewModel modelo)
        {
            modelo.Buscar = (modelo.Buscar ?? string.Empty).Trim();

            // Igual que ClienteCln.listarTiposClienteCombo: los tipos que ya existen.
            modelo.Tipos = _context.Cliente
                .Where(x => x.estado == 1 && x.tipoCliente != null && x.tipoCliente != "")
                .Select(x => x.tipoCliente!)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            if (!string.IsNullOrWhiteSpace(modelo.TipoCliente) && !modelo.Tipos.Contains(modelo.TipoCliente))
                modelo.Tipos.Add(modelo.TipoCliente);

            if (modelo.Buscar.Length < 2)
                return;

            string patron = "%" + modelo.Buscar.Replace(" ", "%") + "%";

            modelo.Sugerencias = _context.Cliente
                .Where(x => x.estado == 1)
                .Where(x =>
                    EF.Functions.Like(x.nitCi, patron) ||
                    EF.Functions.Like(x.nombres, patron) ||
                    EF.Functions.Like(x.primerApellido, patron) ||
                    EF.Functions.Like(x.razonSocial, patron))
                .OrderBy(x => x.nombres)
                .ThenBy(x => x.razonSocial)
                .Take(8)
                .ToList()
                .Select(x => new SugerenciaCliente
                {
                    Id = x.id,
                    Texto = NombreParaMostrar(x) + " · CI/NIT " + x.nitCi
                })
                .ToList();
        }

        // Nombre con el que se reconoce a un cliente (razón social o nombre y apellido).
        private static string NombreParaMostrar(Cliente cliente)
        {
            if (!string.IsNullOrWhiteSpace(cliente.razonSocial))
                return cliente.razonSocial;

            return (cliente.nombres + " " + cliente.primerApellido).Trim();
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
            (List<T> datos, int pagina, int total, int totalPaginas) pag,
            string? accionEditar = null,
            string? textoNuevo = null,
            List<int>? ids = null,
            List<bool>? alertas = null,
            int columnaAlerta = -1,
            string? filtroTexto = null,
            bool filtroActivo = false,
            int filtroTotal = 0)
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
                TotalPaginas = pag.totalPaginas,
                AccionEditar = accionEditar,
                TextoNuevo = textoNuevo,
                Ids = ids ?? new List<int>(),
                Alertas = alertas ?? new List<bool>(),
                ColumnaAlerta = columnaAlerta,
                FiltroTexto = filtroTexto,
                FiltroActivo = filtroActivo,
                FiltroTotal = filtroTotal
            });
        }
    }
}
