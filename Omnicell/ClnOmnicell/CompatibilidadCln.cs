using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class CompatibilidadCln
    {
        public static int crear(Compatibilidad compatibilidad)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Compatibilidad.Where(x => x.idPantalla == compatibilidad.idPantalla && x.idModelo == compatibilidad.idModelo).FirstOrDefault();
                if (existe != null) throw new Exception("La compatibilidad entre esta pantalla y modelo ya existe");

                context.Compatibilidad.Add(compatibilidad);
                context.SaveChanges();
                return compatibilidad.id;
            }
        }

        public static int actualizar(Compatibilidad compatibilidad)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Compatibilidad.Find(compatibilidad.id);
                if (existe == null) throw new Exception($"La compatibilidad con id {compatibilidad.id} no existe");

                existe.idPantalla = compatibilidad.idPantalla;
                existe.idModelo = compatibilidad.idModelo;
                existe.usuarioRegistro = compatibilidad.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Compatibilidad.Find(id);
                if (existe == null) throw new Exception($"La compatibilidad con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Compatibilidad obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var compatibilidad = context.Compatibilidad.Find(id);
                if (compatibilidad == null) throw new Exception($"La compatibilidad con id {id} no existe");
                return compatibilidad;
            }
        }

        public static List<Compatibilidad> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Compatibilidad.Where(x => x.estado == 1).ToList();
            }
        }
    }
}
