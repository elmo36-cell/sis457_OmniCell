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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // En el script las dos columnas son DECIMAL(10,2); sin esto EF usa su
            // precisión por defecto y avisa que podría truncar los valores.
            modelBuilder.Entity<Pantalla>().Property(x => x.precioVenta).HasPrecision(10, 2);
            modelBuilder.Entity<Pantalla>().Property(x => x.stockTotal).HasPrecision(10, 2);
        }
    }
}
