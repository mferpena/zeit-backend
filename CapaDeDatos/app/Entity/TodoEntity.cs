using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDeDatos.Entity
{
    [Table("TODOS")]
    public class TodoEntity
    {
        [Key]
        [Column("ID")] 
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("TITLE")] 
        public required string Title { get; set; }

        [MaxLength(255)]
        [Column("DESCRIPTION")] 
        public required string Description { get; set; }
    }
}
