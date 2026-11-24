using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Pantalla del script ddl_dml_labomnicell.sql. Es lo que lista el catálogo.
    /// </summary>
    [Table("Pantalla")]
    public class Pantalla
    {
        public int id { get; set; }
        public string sku { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string calidad { get; set; } = string.Empty;
        public string tecnologia { get; set; } = string.Empty;
        public decimal precioVenta { get; set; }
        public decimal stockTotal { get; set; }
        public string usuarioRegistro { get; set; } = string.Empty;
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
