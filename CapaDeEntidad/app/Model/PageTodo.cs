namespace CapaDeEntidad.Model
{
    public class PageTodo
    {
        public required List<TodoItem> Todos { get; set; }
        public required Pagination Pagination { get; set; }
    }

    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }

    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
    }

}