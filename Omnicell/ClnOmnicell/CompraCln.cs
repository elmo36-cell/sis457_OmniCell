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
        public static int crear(Compra compra)
        {
            using (var context = new LabOmnicellEntities())
            {
                context.Compra.Add(compra);
                context.SaveChanges();
                return compra.id;
            }
        }

        public static int actualizar(Compra compra)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Compra.Find(compra.id);
                if (existe == null) throw new Exception($"La compra con id {compra.id} no existe");

                existe.idProveedor = compra.idProveedor;
                existe.idEmpleado = compra.idEmpleado;
                existe.fechaCompra = compra.fechaCompra;
                existe.factura = compra.factura;
                existe.costoTotal = compra.costoTotal;
                existe.usuarioRegistro = compra.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Compra.Find(id);
                if (existe == null) throw new Exception($"La compra con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Compra obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var compra = context.Compra.Find(id);
                if (compra == null) throw new Exception($"La compra con id {id} no existe");
                return compra;
            }
        }

        public static List<Compra> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Compra.Where(x => x.estado == 1).OrderByDescending(x => x.fechaCompra).ToList();
            }
        }
    }
}
