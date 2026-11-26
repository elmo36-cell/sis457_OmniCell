using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Marca del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Marca")]
    public class Marca
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
