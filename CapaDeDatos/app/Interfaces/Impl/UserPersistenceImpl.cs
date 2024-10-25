using Microsoft.EntityFrameworkCore;
using CapaDeEntidad.Model;
using CapaDeDatos;
using CapaDeDatos.Entity;

namespace CapaDeNegocio.Persistence
{
    public class UserPersistenceImpl : IUserPersistence
    {
        private readonly ApplicationDbContext _context;

        public UserPersistenceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (userEntity != null)
            {
                return new User { Id = userEntity.Id, UserName = userEntity.UserName, Email = userEntity.Email, Password = userEntity.Password };
            }

            #pragma warning disable CS8603
            return null;
            #pragma warning restore CS8603
        }

        public void CreateUser(string username, string password, string email)
        {
            var newUser = new UserEntity
            {
                UserName = username,
                Email = email,
                Password = password
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();
        }

    }
}
