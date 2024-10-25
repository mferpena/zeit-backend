using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CapaDePresentacion.Dtos
{
    public class TodoDto
    {
        [JsonPropertyName("title")]
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no debe exceder los 100 caracteres.")]
        public required string Title { get; set; }

        [JsonPropertyName("description")]
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(255, ErrorMessage = "La descripción no debe exceder los 255 caracteres.")]
        public required string Description { get; set; }
    }
}
