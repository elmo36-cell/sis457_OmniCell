using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class CompraDatalleCln
    {
        public static int crear(CompraDetalle compraDetalle)
        {
            using (var context = new LabOmnicellEntities())
            {
                context.CompraDetalle.Add(compraDetalle);
                context.SaveChanges();
                return compraDetalle.id;
            }
        }

        public static int actualizar(CompraDetalle compraDetalle)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.CompraDetalle.Find(compraDetalle.id);
                if (existe == null) throw new Exception($"El detalle de compra con id {compraDetalle.id} no existe");

                existe.idCompra = compraDetalle.idCompra;
                existe.idPantalla = compraDetalle.idPantalla;
                existe.cantidad = compraDetalle.cantidad;
                existe.costoUnitario = compraDetalle.costoUnitario;
                existe.subtotal = compraDetalle.subtotal;
                existe.usuarioRegistro = compraDetalle.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.CompraDetalle.Find(id);
                if (existe == null) throw new Exception($"El detalle de compra con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static CompraDetalle obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var detalle = context.CompraDetalle.Find(id);
                if (detalle == null) throw new Exception($"El detalle de compra con id {id} no existe");
                return detalle;
            }
        }

        public static List<CompraDetalle> listarPorCompra(int idCompra)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.CompraDetalle.Where(x => x.idCompra == idCompra && x.estado == 1).ToList();
            }
        }
    }
}
