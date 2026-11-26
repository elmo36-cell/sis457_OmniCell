using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Empleado del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Empleado")]
    public class Empleado
    {
        public int id { get; set; }
        public int idSucursal { get; set; }
        public string nombres { get; set; } = string.Empty;
        public string primerApellido { get; set; } = string.Empty;
        public string? segundoApellido { get; set; }
        public string? ci { get; set; }
        // En el script la columna es BIGINT, no texto.
        public long? celular { get; set; }
        public string? direccion { get; set; }
        public string? cargo { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
