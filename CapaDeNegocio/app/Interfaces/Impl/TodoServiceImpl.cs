using CapaDeEntidad.Model;
using CapaDeNegocio.Persistence;

namespace CapaDeNegocio.Services
{
    public class TodoServiceImpl : ITodoService
    {
        private readonly ITodoPersistence _todoPersistence;

        public TodoServiceImpl(ITodoPersistence todoPersistence)
        {
            _todoPersistence = todoPersistence;
        }

        public async Task<PageTodo> GetTodosByTitleAsync(string title)
        {
            return await _todoPersistence.GetTodosByTitleAsync(title);
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _todoPersistence.GetTodoByIdAsync(id);
        }

        public async Task CreateTodoAsync(Todo todo)
        {
            await _todoPersistence.CreateTodoAsync(todo);
        }

        public async Task UpdateTodoAsync(int id, Todo todo)
        {
            await _todoPersistence.UpdateTodoAsync(id, todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoPersistence.DeleteTodoAsync(id);
        }
    }
}
