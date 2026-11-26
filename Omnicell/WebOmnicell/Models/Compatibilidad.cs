using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Compatibilidad del script ddl_dml_labomnicell.sql: une una pantalla
    /// con los modelos de celular en los que se puede usar.
    /// </summary>
    [Table("Compatibilidad")]
    public class Compatibilidad
    {
        public int id { get; set; }
        public int idPantalla { get; set; }
        public int idModelo { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
