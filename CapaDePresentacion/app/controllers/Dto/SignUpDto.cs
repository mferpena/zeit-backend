using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CapaDePresentacion.Dtos
{
    public class SignUpDto
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public required string Username { get; set; }

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public required string Email { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public required string Password { get; set; }
    }
}
