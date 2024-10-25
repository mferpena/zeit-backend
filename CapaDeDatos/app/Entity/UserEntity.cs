using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaDeDatos.Entity
{
    [Table("USERS")]
    public class UserEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("USERNAME")]
        public required string UserName { get; set; }

        [Required]
        [Column("PASSWORD")]
        public required string Password { get; set; }

        [Required]
        [Column("EMAIL")]
        public required string Email { get; set; }
    }
}
