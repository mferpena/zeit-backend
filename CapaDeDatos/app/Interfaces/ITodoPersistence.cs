using CapaDeEntidad.Model;

namespace CapaDeNegocio.Persistence
{
    public interface ITodoPersistence
    {
        Task<PageTodo> GetTodosByTitleAsync(string title);
        Task<Todo> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(int id, Todo todo);
        Task DeleteTodoAsync(int id);
    }
}
