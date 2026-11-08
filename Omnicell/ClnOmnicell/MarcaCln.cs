using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class MarcaCln
    {
        public static int crear(Marca marca)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Marca.Where(x => x.nombre == marca.nombre).FirstOrDefault();
                if (existe != null) throw new Exception($"La marca {marca.nombre} ya existe");

                context.Marca.Add(marca);
                context.SaveChanges();
                return marca.id;
            }
        }

        public static int actualizar(Marca marca)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Marca.Find(marca.id);
                if (existe == null) throw new Exception($"La marca con id {marca.id} no existe");

                existe.nombre = marca.nombre;
                existe.usuarioRegistro = marca.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Marca.Find(id);
                if (existe == null) throw new Exception($"La marca con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Marca obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var marca = context.Marca.Find(id);
                if (marca == null) throw new Exception($"La marca con id {id} no existe");
                return marca;
            }
        }

        public static List<Marca> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Marca.Where(x => x.estado == 1).OrderBy(x => x.nombre).ToList();
            }
        }
    }
}
