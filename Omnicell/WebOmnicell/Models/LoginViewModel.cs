using System.ComponentModel.DataAnnotations;

namespace WebOmnicell.Models
{
    /// <summary>
    /// Datos que envía el formulario de inicio de sesión.
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ingrese su nombre de usuario.")]
        [StringLength(20, ErrorMessage = "El usuario no puede pasar de 20 caracteres.")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese su contraseña.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; } = string.Empty;
    }
}
