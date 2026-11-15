using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ClnOmnicell
{
    public class VentaCln
    {
        public static int crear(Venta venta)
        {
            using (var context = new LabOmnicellEntities())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
                return venta.id;
            }
        }


        public static int registrarVenta(Venta venta, List<VentaDetalle> detalles)
        {
            if (venta == null)
                throw new Exception("Los datos de la venta son incorrectos.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("Debe agregar al menos un producto.");

            using (var context = new LabOmnicellEntities())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Agrupar productos para validar el stock total por pantalla.
                    var productosAgrupados = detalles
                        .GroupBy(d => d.idPantalla)
                        .Select(g => new
                        {
                            idPantalla = g.Key,
                            cantidad = g.Sum(d => d.cantidad)
                        })
                        .ToList();

                    // Validar y recalcular los subtotales.
                    foreach (var detalle in detalles)
                    {
                        if (detalle.cantidad <= 0)
                            throw new Exception("La cantidad debe ser mayor a cero.");

                        if (detalle.precioUnitario < 0)
                            throw new Exception("El precio no puede ser negativo.");

                        detalle.subtotal = detalle.cantidad * detalle.precioUnitario;
                    }

                    // Verificar y descontar el inventario.
                    foreach (var producto in productosAgrupados)
                    {
                        var inventario = context.Inventario.FirstOrDefault(i =>
                            i.idSucursal == venta.idSucursal &&
                            i.idPantalla == producto.idPantalla &&
                            i.estado == 1);

                        if (inventario == null)
                            throw new Exception(
                                "No existe inventario para uno de los productos.");

                        if (inventario.stockActual < producto.cantidad)
                            throw new Exception(
                                "Stock insuficiente para uno de los productos.");

                        inventario.stockActual -= producto.cantidad;
                    }

                    // Calcular el total de la venta.
                    venta.montoTotal = detalles.Sum(d => d.subtotal);

                    // Registrar la cabecera.
                    context.Venta.Add(venta);
                    context.SaveChanges();

                    // Registrar los detalles.
                    foreach (var detalle in detalles)
                    {
                        detalle.idVenta = venta.id;
                        detalle.usuarioRegistro = venta.usuarioRegistro;
                        detalle.fechaRegistro = venta.fechaRegistro;
                        detalle.estado = 1;

                        context.VentaDetalle.Add(detalle);
                    }

                    context.SaveChanges();

                    // Confirmar todas las operaciones.
                    transaction.Commit();

                    return venta.id;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public static int actualizar(Venta venta)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Venta.Find(venta.id);
                if (existe == null) throw new Exception($"La venta con id {venta.id} no existe");

                existe.idCliente = venta.idCliente;
                existe.idEmpleado = venta.idEmpleado;
                existe.idSucursal = venta.idSucursal;
                existe.fechaVenta = venta.fechaVenta;
                existe.tipoPago = venta.tipoPago;
                existe.montoTotal = venta.montoTotal;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Venta.Find(id);
                if (existe == null) throw new Exception($"La venta con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Venta obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var venta = context.Venta
                    .Include("Cliente")
                    .Include("Empleado")
                    .Include("Sucursal")
                    .FirstOrDefault(x => x.id == id);

                if (venta == null)
                    throw new Exception("No existe la venta.");

                return venta;
            }
        }

        public static List<Venta> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Venta.Where(x => x.estado == 1).OrderByDescending(x => x.fechaVenta).ToList();
            }
        }

        public static List<paVentaListar_Result> listarVentas(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.paVentaListar(parametro.Trim()).ToList();
            }
        }

        // Buscar ID del cliente mediante CI/NIT
        public static int obtenerIdCliente(string nitCi)
        {
            using (var context = new LabOmnicellEntities())
            {
                var cliente = context.Cliente
                    .SingleOrDefault(x => x.nitCi == nitCi);

                if (cliente == null)
                    throw new Exception("No existe un cliente con ese CI/NIT.");

                return cliente.id;
            }
        }

        // Buscar ID del empleado mediante su nombre completo
        public static int obtenerIdEmpleado(string nombreCompleto)
        {
            using (var context = new LabOmnicellEntities())
            {
                var empleados = context.Empleado.ToList()
                    .Where(x => (x.nombres + " " + x.primerApellido).Trim()
                        .Equals(nombreCompleto.Trim(),
                            StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (empleados.Count == 0)
                    throw new Exception("No existe ese empleado.");

                if (empleados.Count > 1)
                    throw new Exception("Hay varios empleados con ese nombre. Debes identificarlos de otra manera.");

                return empleados[0].id;
            }
        }

        // Buscar ID de la sucursal mediante su nombre
        public static int obtenerIdSucursal(string nombre)
        {
            using (var context = new LabOmnicellEntities())
            {
                var sucursales = context.Sucursal
                    .Where(x => x.nombre == nombre)
                    .ToList();

                if (sucursales.Count == 0)
                    throw new Exception("No existe esa sucursal.");

                if (sucursales.Count > 1)
                    throw new Exception("Hay varias sucursales con ese nombre.");

                return sucursales[0].id;
            }
        }

        public static List<Cliente> listarClientesCombo()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Cliente.OrderBy(x => x.nombres).ToList();
            }
        }

        public static List<Empleado> listarEmpleadosCombo()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Empleado.OrderBy(x => x.nombres).ToList();
            }
        }

        public static List<Sucursal> listarSucursalesCombo()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Sucursal.OrderBy(x => x.nombre).ToList();
            }
        }
    }
}
