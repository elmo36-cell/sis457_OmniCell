using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class SucursalCln
    {
        public static int crear(Sucursal sucursal)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Sucursal.Where(x => x.nombre == sucursal.nombre).FirstOrDefault();
                if (existe != null) throw new Exception($"La sucursal {sucursal.nombre} ya existe");

                context.Sucursal.Add(sucursal);
                context.SaveChanges();
                return sucursal.id;
            }
        }

        public static int actualizar(Sucursal sucursal)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Sucursal.Find(sucursal.id);
                if (existe == null) throw new Exception($"La sucursal con id {sucursal.id} no existe");

                existe.nombre = sucursal.nombre;
                existe.ciudad = sucursal.ciudad;
                existe.direccion = sucursal.direccion;
                existe.telefono = sucursal.telefono;
                existe.usuarioRegistro = sucursal.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Sucursal.Find(id);
                if (existe == null) throw new Exception($"La sucursal con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Sucursal obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var sucursal = context.Sucursal.Find(id);
                if (sucursal == null) throw new Exception($"La sucursal con id {id} no existe");
                return sucursal;
            }
        }

        public static List<Sucursal> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Sucursal.Where(x => x.estado == 1).OrderBy(x => x.nombre).ToList();
            }
        }
    }
}
