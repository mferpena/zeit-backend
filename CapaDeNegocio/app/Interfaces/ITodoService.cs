using CapaDeEntidad.Model;

namespace CapaDeNegocio.Services
{
    public interface ITodoService
    {
        Task<PageTodo> GetTodosByTitleAsync(string title);
        Task<Todo> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(int id, Todo todo);
        Task DeleteTodoAsync(int id);
    }
}
