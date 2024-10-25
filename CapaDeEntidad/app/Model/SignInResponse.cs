namespace CapaDeEntidad.Model
{
    public class SignInResponse
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
        public required string AccessToken { get; set; }
    }
}