using CadOmnicell;
using System;

namespace ClnOmnicell
{
    // Usuario autenticado y datos que dependen de su sesión.
    public static class SesionCln
    {
        public static Usuario UsuarioActual { get; private set; }

        public static string NombreUsuario
        {
            get { return actual().nombreUsuario; }
        }

        public static int IdEmpleado
        {
            get { return actual().idEmpleado; }
        }

        public static bool EsAdministrador
        {
            get { return UsuarioActual != null && UsuarioActual.idRol == RolCln.Administrador; }
        }

        public static bool EsVendedor
        {
            get { return UsuarioActual != null && UsuarioActual.idRol == RolCln.Vendedor; }
        }

        // Nombre del rol tal como está registrado en la base de datos.
        public static string NombreRol
        {
            get
            {
                Rol rol = actual().Rol;

                return rol == null ? string.Empty : rol.nombre;
            }
        }

        public static void abrir(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            UsuarioActual = usuario;
        }

        public static void cerrar()
        {
            UsuarioActual = null;
        }

        // Empleado del usuario actual con su sucursal; falla si la sucursal no está asignada.
        public static Empleado empleadoConSucursal()
        {
            Empleado empleado = EmpleadoCln.obtenerConSucursal(actual().idEmpleado);

            if (!empleado.idSucursal.HasValue || empleado.Sucursal == null)
                throw new Exception("El empleado no tiene una sucursal asignada.");

            return empleado;
        }

        // Nombre de la sucursal del usuario; vacío cuando todavía no tiene una asignada.
        public static string NombreSucursal
        {
            get
            {
                if (UsuarioActual == null)
                    return string.Empty;

                Empleado empleado = EmpleadoCln.obtenerConSucursal(UsuarioActual.idEmpleado);

                return empleado.Sucursal == null ? string.Empty : empleado.Sucursal.nombre;
            }
        }

        private static Usuario actual()
        {
            if (UsuarioActual == null)
                throw new Exception("No existe un usuario autenticado. Inicie sesión nuevamente.");

            return UsuarioActual;
        }
    }
}
