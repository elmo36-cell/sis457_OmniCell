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
        public static int registrarVenta(Venta venta, List<VentaDetalle> detalles)
        {
            if (venta == null)
                throw new Exception("Los datos de la venta son incorrectos.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("Debe agregar al menos un producto.");

            using (var context = new LabOmnicellEntities())
            // BEGIN TRANSACTION: o se guarda todo o no se guarda nada.
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
                        // SELECT del stock de la sucursal para cada pantalla.
                        var inventario = context.Inventario.FirstOrDefault(i =>
                            i.idSucursal == venta.idSucursal &&
                            i.idPantalla == producto.idPantalla &&
                            i.estado == (int)Estado.Activo);

                        if (inventario == null)
                            throw new Exception(
                                "No existe inventario para uno de los productos.");

                        if (inventario.stockActual < producto.cantidad)
                            throw new Exception(
                                "Stock insuficiente para uno de los productos.");

                        // UPDATE: descuenta el stock vendido.
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
                        detalle.estado = (int)Estado.Activo;

                        context.VentaDetalle.Add(detalle);
                    }

                    context.SaveChanges();

                    // COMMIT: confirma venta, detalles y descuento de stock.
                    transaction.Commit();

                    return venta.id;
                }
                catch
                {
                    // ROLLBACK: deshace todo si alguna parte falla.
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Venta.Find(id);
                if (existe == null) throw new Exception($"La venta con id {id} no existe");

                // Baja lógica: UPDATE estado = -1 (la fila no se borra).
                existe.estado = (int)Estado.Eliminado;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Venta obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                // SELECT con JOIN: Include trae Cliente, Empleado y Sucursal.
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

        public static List<paVentaListar_Result> listarVentas(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                // Procedimiento almacenado: busca ventas por cliente, vendedor o sucursal.
                return context.paVentaListar((parametro ?? string.Empty).Trim()).ToList();
            }
        }

        // Un vendedor solo ve las ventas de su sucursal; el administrador ve todas.
        public static List<paVentaListar_Result> listarVentas(string parametro, string sucursal)
        {
            List<paVentaListar_Result> ventas = listarVentas(parametro);

            if (string.IsNullOrWhiteSpace(sucursal))
                return ventas;

            return ventas
                .Where(venta => venta.sucursal != null &&
                                venta.sucursal.Equals(sucursal, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
