using CapaDeEntidad.Model;

namespace CapaDeNegocio.Persistence
{
    public interface IUserPersistence
    {
        Task<User> GetUserByUsernameAsync(string username);
        void CreateUser(string username, string password, string email);
    }
}
