using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CapaDePresentacion.Dtos
{
    public class SignInDto
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public required string Username { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public required string Password { get; set; }
    }
}
