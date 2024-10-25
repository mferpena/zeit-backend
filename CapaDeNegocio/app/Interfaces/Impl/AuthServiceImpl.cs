using CapaDeNegocio.Exceptions;
using CapaDeNegocio.Persistence;
using CapaDeNegocio.Security;

namespace CapaDeNegocio.Services
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly IUserPersistence _userPersistence;
        private readonly ITokenSecurity _tokenSecurity;

        public AuthServiceImpl(IUserPersistence userPersistence, ITokenSecurity tokenSecurity)
        {
            _userPersistence = userPersistence;
            _tokenSecurity = tokenSecurity;
        }

        public async Task<string> SignIn(string username, string password)
        {
            var user = await _userPersistence.GetUserByUsernameAsync(username);
            if (user == null)
            {
                throw new UserNotFoundException($"No se encontró el usuario con el nombre de usuario '{username}'");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new InvalidCredentialsException("La contraseña es incorrecta.");
            }

            return _tokenSecurity.GenerateToken(user, TimeSpan.FromHours(5));
        }

        public async Task SignUp(string username, string password, string email)
        {
            var existingUser = await _userPersistence.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException($"El usuario con el nombre de usuario '{username}' ya existe.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            _userPersistence.CreateUser(username, hashedPassword, email);
        }
    }
}