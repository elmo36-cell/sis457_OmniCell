using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                existe.usuarioRegistro = venta.usuarioRegistro;

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
                var venta = context.Venta.Find(id);
                if (venta == null) throw new Exception($"La venta con id {id} no existe");
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
    }
}
