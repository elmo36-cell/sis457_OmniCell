using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Inventario del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Inventario")]
    public class Inventario
    {
        public int id { get; set; }
        public int idSucursal { get; set; }
        public int idPantalla { get; set; }
        public decimal stockActual { get; set; }
        public decimal stockMinimo { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
