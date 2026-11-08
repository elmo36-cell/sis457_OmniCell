using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class ModeloCln
    {
        public static int crear(Modelo modelo)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Modelo.Where(x => x.nombre == modelo.nombre && x.idMarca == modelo.idMarca).FirstOrDefault();
                if (existe != null) throw new Exception($"El modelo {modelo.nombre} ya existe para esta marca");

                context.Modelo.Add(modelo);
                context.SaveChanges();
                return modelo.id;
            }
        }

        public static int actualizar(Modelo modelo)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Modelo.Find(modelo.id);
                if (existe == null) throw new Exception($"El modelo con id {modelo.id} no existe");

                existe.idMarca = modelo.idMarca;
                existe.nombre = modelo.nombre;
                existe.usuarioRegistro = modelo.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Modelo.Find(id);
                if (existe == null) throw new Exception($"El modelo con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Modelo obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var modelo = context.Modelo.Find(id);
                if (modelo == null) throw new Exception($"El modelo con id {id} no existe");
                return modelo;
            }
        }

        public static List<Modelo> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Modelo.Where(x => x.estado == 1).OrderBy(x => x.nombre).ToList();
            }
        }
    }
}
