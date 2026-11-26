using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Cliente del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Cliente")]
    public class Cliente
    {
        public int id { get; set; }
        public string? nitCi { get; set; }
        public string? nombres { get; set; }
        public string? primerApellido { get; set; }
        public string? segundoApellido { get; set; }
        public string? razonSocial { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public string? tipoCliente { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
