using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class ProveedorCln
    {
        public static int crear(Proveedor proveedor)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Proveedor.Where(x => x.razonSocial == proveedor.razonSocial).FirstOrDefault();
                if (existe != null) throw new Exception($"El proveedor {proveedor.razonSocial} ya existe");

                context.Proveedor.Add(proveedor);
                context.SaveChanges();
                return proveedor.id;
            }
        }

        public static int actualizar(Proveedor proveedor)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Proveedor.Find(proveedor.id);
                if (existe == null) throw new Exception($"El proveedor con id {proveedor.id} no existe");

                existe.razonSocial = proveedor.razonSocial;
                existe.pais = proveedor.pais;
                existe.contactoPersona = proveedor.contactoPersona;
                existe.telefono = proveedor.telefono;
                existe.usuarioRegistro = proveedor.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Proveedor.Find(id);
                if (existe == null) throw new Exception($"El proveedor con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Proveedor obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var proveedor = context.Proveedor.Find(id);
                if (proveedor == null) throw new Exception($"El proveedor con id {id} no existe");
                return proveedor;
            }
        }

        public static List<Proveedor> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Proveedor.Where(x => x.estado == 1).OrderBy(x => x.razonSocial).ToList();
            }
        }
    }
}
