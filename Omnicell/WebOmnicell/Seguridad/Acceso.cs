namespace WebOmnicell.Seguridad
{
    /// <summary>
    /// Reglas de acceso por rol, iguales a las del escritorio (FrmMenuVendedor):
    /// el Administrador ve todo y el Vendedor solo ventas de su sucursal y clientes.
    /// Los id coinciden con la tabla Rol del script.
    /// </summary>
    public static class Acceso
    {
        public const int Administrador = 1;
        public const int Vendedor = 2;

        // Lee el rol guardado en la sesión al iniciar sesión (0 si no hay sesión).
        public static int Rol(ISession sesion)
        {
            return int.TryParse(sesion.GetString("rol"), out int rol) ? rol : 0;
        }

        public static bool EsAdministrador(ISession sesion)
        {
            return Rol(sesion) == Administrador;
        }

        public static bool HaySesion(ISession sesion)
        {
            return !string.IsNullOrEmpty(sesion.GetString("usuario"));
        }

        // Solo el Administrador entra a compras, proveedores, personal e inventario.
        public static bool PuedeVerAdministracion(ISession sesion)
        {
            return EsAdministrador(sesion);
        }
    }
}
