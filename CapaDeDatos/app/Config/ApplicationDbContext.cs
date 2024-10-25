using Microsoft.EntityFrameworkCore;
using CapaDeDatos.Entity;

namespace CapaDeDatos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoEntity> Todos { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
