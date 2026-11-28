using System.ComponentModel.DataAnnotations;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos del formulario web de clientes. Reproduce las reglas de ClienteCln del
    /// escritorio: el CI/NIT es obligatorio y numérico, se exige nombre o razón social
    /// y el tipo de cliente sale de los que ya existen en la base.
    /// </summary>
    public class ClienteFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Ingrese el CI/NIT del cliente.")]
        [Display(Name = "CI / NIT")]
        public string NitCi { get; set; } = string.Empty;

        [Display(Name = "Nombres")]
        public string? Nombres { get; set; }

        [Display(Name = "Primer apellido")]
        public string? PrimerApellido { get; set; }

        [Display(Name = "Segundo apellido")]
        public string? SegundoApellido { get; set; }

        [Display(Name = "Razón social")]
        public string? RazonSocial { get; set; }

        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [Display(Name = "Tipo de cliente")]
        public string? TipoCliente { get; set; }

        // Texto del buscador por nombre o CI/NIT. Es opcional: si fuera obligatorio,
        // el campo oculto vacío invalidaría el guardado.
        public string? Buscar { get; set; }

        // Tipos de cliente que ya usa la base, para el desplegable.
        public List<string> Tipos { get; set; } = new List<string>();

        // Clientes que coinciden con la búsqueda; al elegir uno se cargan sus datos.
        public List<SugerenciaCliente> Sugerencias { get; set; } = new List<SugerenciaCliente>();
    }

    /// <summary>
    /// Una coincidencia del buscador de clientes.
    /// </summary>
    public class SugerenciaCliente
    {
        public int Id { get; set; }
        public string Texto { get; set; } = string.Empty;
    }
}
