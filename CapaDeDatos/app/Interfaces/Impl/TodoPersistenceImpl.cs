using Microsoft.EntityFrameworkCore;
using CapaDeEntidad.Model;
using CapaDeDatos.Entity;
using CapaDeDatos;

namespace CapaDeNegocio.Persistence
{
    public class TodoPersistenceImpl : ITodoPersistence
    {
        private readonly ApplicationDbContext _context;

        public TodoPersistenceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            var todoEntity = await _context.Todos.FindAsync(id);
            if (todoEntity != null)
            {
                return new Todo
                {
                    Id = todoEntity.Id,
                    Title = todoEntity.Title,
                    Description = todoEntity.Description
                };
            }

            throw new Exception($"No se encontró un Todo con el ID {id}.");
        }

        public async Task CreateTodoAsync(Todo todo)
        {
            var newTodoEntity = new TodoEntity
            {
                Title = todo.Title,
                Description = todo.Description
            };

            _context.Todos.Add(newTodoEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(int id, Todo todo)
        {
            var existingTodoEntity = await _context.Todos.FindAsync(id);
            if (existingTodoEntity == null)
            {
                throw new Exception("Todo no encontrado");
            }

            existingTodoEntity.Title = todo.Title;
            existingTodoEntity.Description = todo.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todoEntity = await _context.Todos.FindAsync(id);
            if (todoEntity == null)
            {
                throw new Exception("Todo no encontrado");
            }

            _context.Todos.Remove(todoEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<PageTodo> GetTodosByTitleAsync(string? title)
        {
            int pageNumber = 1;
            int pageSize = 10;
            IQueryable<TodoEntity> query = _context.Todos;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(t => t.Title.Contains(title));
            }

            int totalRecords = await query.CountAsync();

            var todoEntities = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var todos = todoEntities
                .Select(entity => new TodoItem
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description
                })
                .ToList();

            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var pagination = new Pagination
            {
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                PageSize = pageSize,
                Total = totalRecords
            };

            var result = new PageTodo
            {
                Todos = todos,
                Pagination = pagination
            };

            return result;
        }
    }
}
