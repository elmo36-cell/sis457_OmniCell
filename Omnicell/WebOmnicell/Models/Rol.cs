using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Rol del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Rol")]
    public class Rol
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string? descripcion { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
