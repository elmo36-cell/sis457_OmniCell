using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Proveedor del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Proveedor")]
    public class Proveedor
    {
        public int id { get; set; }
        public string razonSocial { get; set; } = string.Empty;
        public string? pais { get; set; }
        public string? contactoPersona { get; set; }
        public string? telefono { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
