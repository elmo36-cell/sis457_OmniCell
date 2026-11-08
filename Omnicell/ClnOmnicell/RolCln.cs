using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class RolCln
    {
        public static int crear(Rol rol)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Rol.Where(x => x.nombre == rol.nombre).FirstOrDefault();
                if (existe != null) throw new Exception($"El rol {rol.nombre} ya existe");

                context.Rol.Add(rol);
                context.SaveChanges();
                return rol.id;
            }
        }

        public static int actualizar(Rol rol)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Rol.Find(rol.id);
                if (existe == null) throw new Exception($"El rol con id {rol.id} no existe");

                existe.nombre = rol.nombre;
                existe.descripcion = rol.descripcion;
                existe.usuarioRegistro = rol.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Rol.Find(id);
                if (existe == null) throw new Exception($"El rol con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Rol obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var rol = context.Rol.Find(id);
                if (rol == null) throw new Exception($"El rol con id {id} no existe");
                return rol;
            }
        }

        public static List<Rol> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Rol.Where(x => x.estado == 1).OrderBy(x => x.nombre).ToList();
            }
        }
    }
}
