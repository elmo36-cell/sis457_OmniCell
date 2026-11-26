using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Modelo del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Modelo")]
    public class Modelo
    {
        public int id { get; set; }
        public int idMarca { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
