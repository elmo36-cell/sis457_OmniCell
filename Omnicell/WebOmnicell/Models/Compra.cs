using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Compra del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Compra")]
    public class Compra
    {
        public int id { get; set; }
        public int idProveedor { get; set; }
        public int idEmpleado { get; set; }
        public DateTime fechaCompra { get; set; }
        public string? factura { get; set; }
        public decimal costoTotal { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
