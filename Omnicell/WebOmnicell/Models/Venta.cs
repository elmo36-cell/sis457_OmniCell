using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Venta del script ddl_dml_labomnicell.sql.
    /// </summary>
    [Table("Venta")]
    public class Venta
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public int idSucursal { get; set; }
        public DateTime fechaVenta { get; set; }
        public string? tipoPago { get; set; }
        public decimal montoTotal { get; set; }
        public string? usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
