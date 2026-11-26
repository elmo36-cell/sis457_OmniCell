using CadOmnicell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnOmnicell
{
    public class UsuarioCln
    {
        public static int crear(Usuario usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Usuario.Where(x => x.nombreUsuario == usuario.nombreUsuario).FirstOrDefault();
                if (existe != null) throw new Exception($"El usuario {usuario.nombreUsuario} ya existe");

                context.Usuario.Add(usuario);
                context.SaveChanges();
                return usuario.id;
            }
        }

        public static int actualizar(Usuario usuario)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Usuario.Find(usuario.id);

                if (existe == null)
                    throw new Exception($"El usuario con id {usuario.id} no existe");

                var duplicado = context.Usuario.FirstOrDefault(x =>
                    x.nombreUsuario == usuario.nombreUsuario &&
                    x.id != usuario.id);

                if (duplicado != null)
                    throw new Exception($"El usuario {usuario.nombreUsuario} ya existe");

                existe.idEmpleado = usuario.idEmpleado;
                existe.idRol = usuario.idRol;
                existe.nombreUsuario = usuario.nombreUsuario;

                // Actualizar contraseña solamente si se introdujo una nueva.
                if (!string.IsNullOrWhiteSpace(usuario.clave))
                {
                    existe.clave = usuario.clave;
                }

                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioLog)
        {
            using (var context = new LabOmnicellEntities())
            {
                var existe = context.Usuario.Find(id);
                if (existe == null) throw new Exception($"El usuario con id {id} no existe");

                existe.estado = -1;
                existe.usuarioRegistro = usuarioLog;
                return context.SaveChanges();
            }
        }

        public static Usuario obtenerUno(int id)
        {
            using (var context = new LabOmnicellEntities())
            {
                var usuario = context.Usuario.Find(id);
                if (usuario == null) throw new Exception($"El usuario con id {id} no existe");
                return usuario;
            }
        }

        public static Usuario autenticar(string nombreUsuario, string clave)
        {
            using (var context = new LabOmnicellEntities())
            {
                // Buscamos el usuario 
                var usuario = context.Usuario
                    .Include("Rol")      // Relacion del rol
                    .Include("Empleado") // Relación del empleado (para saber su nombre real)
                    .FirstOrDefault(x => x.nombreUsuario == nombreUsuario && x.clave == clave && x.estado == 1);

                if (usuario == null)
                {
                    throw new Exception("Usuario o contraseña incorrectos.");
                }

                return usuario;
            }
        }

        public static List<Usuario> listar()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Usuario.Where(x => x.estado == 1).OrderBy(x => x.nombreUsuario).ToList();
            }
        }

        public static List<paUsuarioListar_Result> listarUsuarios(string parametro)
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.paUsuarioListar(parametro.Trim()).ToList();
            }
        }
        public static List<Empleado> listarEmpleadosCombo()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Empleado
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombres)
                    .ToList();
            }
        }
        public static List<Rol> listarRolesCombo()
        {
            using (var context = new LabOmnicellEntities())
            {
                return context.Rol
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }




    }
}
