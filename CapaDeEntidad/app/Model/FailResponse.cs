namespace CapaDeEntidad.Model
{
    public class FailReponse
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
        public required string Stack { get; set; }
    }
}