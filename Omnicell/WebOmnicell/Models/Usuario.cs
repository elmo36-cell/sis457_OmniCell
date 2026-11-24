using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Tabla Usuario del script ddl_dml_labomnicell.sql. Solo los campos que usa el login.
    /// </summary>
    [Table("Usuario")]
    public class Usuario
    {
        public int id { get; set; }
        public int idEmpleado { get; set; }
        public int idRol { get; set; }
        public string nombreUsuario { get; set; } = string.Empty;
        public string clave { get; set; } = string.Empty;
        public string usuarioRegistro { get; set; } = string.Empty;
        public DateTime fechaRegistro { get; set; }
        public short estado { get; set; }
    }
}
