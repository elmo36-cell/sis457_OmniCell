using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class VentaDetalleCln
    {
        public static int crear(VentaDetalle ventaDetalle)
        {
            using (var context = new LabOmnicellEntities())
            {
                context.VentaDetalle.Add(ventaDetalle);
                context.SaveChanges();
                return ventaDetalle.id;
            }
        }

        public static int actualizar(VentaDetalle ventaDetalle)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.VentaDetalle.Find(ventaDetalle.id);
                if (existe == null) throw new Exception($"El detalle de venta con id {ventaDetalle.id} no existe");

                existe.idVenta = ventaDetalle.idVenta;
                existe.idPantalla = ventaDetalle.idPantalla;
                existe.cantidad = ventaDetalle.cantidad;
                existe.precioUnitario = ventaDetalle.precioUnitario;
                existe.subtotal = ventaDetalle.subtotal;
                existe.observacionGarantia = ventaDetalle.observacionGarantia;
                existe.usuarioRegistro = ventaDetalle.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.VentaDetalle.Find(id);
                if (existe == null) throw new Exception($"El detalle de venta con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static VentaDetalle obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var detalle = context.VentaDetalle.Find(id);
                if (detalle == null) throw new Exception($"El detalle de venta con id {id} no existe");
                return detalle;
            }
        }

        public static List<VentaDetalle> listarPorVenta(int idVenta)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.VentaDetalle.Where(x => x.idVenta == idVenta && x.estado == 1).ToList();
            }
        }
    }
}
