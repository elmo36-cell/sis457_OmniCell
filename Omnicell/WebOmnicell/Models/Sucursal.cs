using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Sucursal del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Sucursal")]
    public class Sucursal
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string? ciudad { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
