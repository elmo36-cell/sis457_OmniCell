using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class CompraCln
    {
        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                // SELECT por id antes de dar de baja.
                var existe = context.Compra.Find(id);
                if (existe == null) throw new Exception($"La compra con id {id} no existe");

                // Baja lógica: UPDATE estado = -1 (la fila no se borra).
                existe.estado = (int)Estado.Eliminado;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Compra obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                // SELECT con JOIN: Include trae Proveedor y Empleado en la misma consulta.
                return context.Compra
                    .Include("Proveedor")
                    .Include("Empleado")
                    .FirstOrDefault(x => x.id == id);
            }
        }

        public static List<paCompraListar_Result> listarCompras(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                // Procedimiento almacenado: busca compras por proveedor o factura.
                return context.paCompraListar((parametro ?? string.Empty).Trim()).ToList();
            }
        }

        public static int registrarCompra(Compra compra,List<CompraDetalle> detalles,int idSucursal)
        {
            if (compra == null)
                throw new Exception("La compra no es válida.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("La compra debe tener al menos un detalle.");

            using (var context = new LabOmnicellEntities())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // Registrar cabecera de compra
                    compra.fechaRegistro = DateTime.Now;
                    compra.estado = (int)Estado.Activo;

                    // INSERT de la cabecera de la compra.
                    context.Compra.Add(compra);
                    context.SaveChanges();

                    // Registrar detalles y actualizar inventario
                    foreach (var detalle in detalles)
                    {
                        detalle.idCompra = compra.id;
                        detalle.fechaRegistro = DateTime.Now;
                        detalle.usuarioRegistro = compra.usuarioRegistro;
                        detalle.estado = (int)Estado.Activo;

                        context.CompraDetalle.Add(detalle);

                        // SELECT del stock de esa sucursal y pantalla.
                        var inventario = context.Inventario
                            .FirstOrDefault(i =>
                                i.idSucursal == idSucursal &&
                                i.idPantalla == detalle.idPantalla &&
                                i.estado == (int)Estado.Activo);

                        if (inventario == null)
                        {
                            inventario = new Inventario
                            {
                                idSucursal = idSucursal,
                                idPantalla = detalle.idPantalla,
                                stockActual = detalle.cantidad,
                                stockMinimo = 0,
                                usuarioRegistro = compra.usuarioRegistro,
                                fechaRegistro = DateTime.Now,
                                estado = (int)Estado.Activo
                            };

                            context.Inventario.Add(inventario);
                        }
                        else
                        {
                            // UPDATE: suma el stock. Solo se toca Inventario, no Pantalla.
                            inventario.stockActual += detalle.cantidad;
                            inventario.estado = (int)Estado.Activo;
                        }
                    }

                    context.SaveChanges();
                    // COMMIT: confirma compra, detalles e inventario juntos.
                    transaction.Commit();

                    return compra.id;
                }
                catch
                {
                    // ROLLBACK: deshace todo si alguna parte falla.
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
