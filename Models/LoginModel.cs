
using System.ComponentModel.DataAnnotations;



namespace RegistroHoras.Models
{
    public class LoginModel
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}

}