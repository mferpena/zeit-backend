namespace CapaDeEntidad.Model
{
    public class TodoResponse
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
        public required Todo Todo { get; set; }
    }
}