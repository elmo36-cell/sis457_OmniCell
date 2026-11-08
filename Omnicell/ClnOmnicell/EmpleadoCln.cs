using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class EmpleadoCln
    {
        public static int crear(Empleado empleado)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Empleado.Where(x => x.ci == empleado.ci).FirstOrDefault();
                if (existe != null) throw new Exception($"El empleado con CI {empleado.ci} ya existe");

                context.Empleado.Add(empleado);
                context.SaveChanges();
                return empleado.id;
            }
        }

        public static int actualizar(Empleado empleado)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Empleado.Find(empleado.id);
                if (existe == null) throw new Exception($"El empleado con id {empleado.id} no existe");

                existe.nombres = empleado.nombres;
                existe.primerApellido = empleado.primerApellido;
                existe.segundoApellido = empleado.segundoApellido;
                existe.ci = empleado.ci;
                existe.celular = empleado.celular;
                existe.direccion = empleado.direccion;
                existe.cargo = empleado.cargo;
                existe.usuarioRegistro = empleado.usuarioRegistro;

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Empleado.Find(id);
                if (existe == null) throw new Exception($"El empleado con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Empleado obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var empleado = context.Empleado.Find(id);
                if (empleado == null) throw new Exception($"El empleado con id {id} no existe");
                return empleado;
            }
        }

        public static List<Empleado> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Empleado.Where(x => x.estado == 1).OrderBy(x => x.nombres).ToList();
            }
        }
    }
}
