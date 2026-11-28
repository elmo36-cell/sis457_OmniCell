using CadOmnicell;
using System.Linq;

namespace ClnOmnicell
{
    // Nombres para mostrar de las personas del sistema.
    public static class NombresCln
    {
        public static string NombreCompleto(this Empleado empleado)
        {
            if (empleado == null)
                return string.Empty;

            return unir(empleado.nombres, empleado.primerApellido, empleado.segundoApellido);
        }

        public static string NombreCompleto(this Cliente cliente)
        {
            if (cliente == null)
                return string.Empty;

            return unir(cliente.nombres, cliente.primerApellido, cliente.segundoApellido);
        }

        // Razón social cuando existe; si no, el nombre completo de la persona.
        public static string NombreMostrar(this Cliente cliente)
        {
            if (cliente == null)
                return string.Empty;

            return string.IsNullOrWhiteSpace(cliente.razonSocial)
                ? cliente.NombreCompleto()
                : cliente.razonSocial.Trim();
        }

        private static string unir(params string[] partes)
        {
            return string.Join(" ", partes
                .Where(parte => !string.IsNullOrWhiteSpace(parte))
                .Select(parte => parte.Trim()));
        }
    }
}
