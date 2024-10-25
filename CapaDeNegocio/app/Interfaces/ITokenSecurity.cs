namespace CapaDeNegocio.Security
{
    public interface ITokenSecurity
    {
        string GenerateToken<T>(T payload, TimeSpan expiration);
        void ValidateToken(string token);
    }
}
