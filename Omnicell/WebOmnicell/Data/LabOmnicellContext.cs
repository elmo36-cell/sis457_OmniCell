using Microsoft.EntityFrameworkCore;
using WebOmnicell.Models;

namespace WebOmnicell.Data
{
    /// <summary>
    /// Acceso a la base LabOmnicell que ya existe (el script no se recrea desde aquí).
    /// Equivale al LabOmnicellEntities del CAD, pero con EF Core.
    /// </summary>
    public class LabOmnicellContext : DbContext
    {
        public LabOmnicellContext(DbContextOptions<LabOmnicellContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario => Set<Usuario>();
        public DbSet<Pantalla> Pantalla => Set<Pantalla>();
        public DbSet<Cliente> Cliente => Set<Cliente>();
        public DbSet<Empleado> Empleado => Set<Empleado>();
        public DbSet<Proveedor> Proveedor => Set<Proveedor>();
        public DbSet<Marca> Marca => Set<Marca>();
        public DbSet<Modelo> Modelo => Set<Modelo>();
        public DbSet<Sucursal> Sucursal => Set<Sucursal>();
        public DbSet<Inventario> Inventario => Set<Inventario>();
        public DbSet<Venta> Venta => Set<Venta>();
        public DbSet<Compra> Compra => Set<Compra>();
        public DbSet<Rol> Rol => Set<Rol>();
        public DbSet<Compatibilidad> Compatibilidad => Set<Compatibilidad>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // En el script las columnas son DECIMAL(10,2); sin esto EF usa su
            // precisión por defecto y avisa que podría truncar los valores.
            modelBuilder.Entity<Pantalla>().Property(x => x.precioVenta).HasPrecision(10, 2);
            modelBuilder.Entity<Pantalla>().Property(x => x.stockTotal).HasPrecision(10, 2);
            modelBuilder.Entity<Inventario>().Property(x => x.stockActual).HasPrecision(10, 2);
            modelBuilder.Entity<Inventario>().Property(x => x.stockMinimo).HasPrecision(10, 2);
            modelBuilder.Entity<Venta>().Property(x => x.montoTotal).HasPrecision(10, 2);
            modelBuilder.Entity<Compra>().Property(x => x.costoTotal).HasPrecision(10, 2);
        }
    }
}
