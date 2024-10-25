namespace CapaDeEntidad.Model
{
    public class PageTodoResponse
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
        public required PageTodo PageTodo { get; set; }
    }
}