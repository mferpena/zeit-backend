namespace CapaDeNegocio.Services
{
    public interface IAuthService
    {
        Task<string> SignIn(string username, string password);
        Task SignUp(string username, string password, string email);
    }
}
