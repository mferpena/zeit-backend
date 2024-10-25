using Microsoft.AspNetCore.Mvc;
using CapaDePresentacion.Dtos;
using CapaDeNegocio.Services;
using CapaDeEntidad.Model;

namespace CapaDePresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos([FromQuery] string? title)
        {
            try
            {
                var todos = await _todoService.GetTodosByTitleAsync(title);

                var response = new PageTodoResponse
                {
                    StatusCode = 200,
                    Message = "Tareas obtenidas correctamente",
                    PageTodo = todos
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            try
            {
                var todo = await _todoService.GetTodoByIdAsync(id);

                if (todo == null)
                {
                    var responseNotFound = new Response
                    {
                        StatusCode = 404,
                        Message = "Tarea no encontrada"
                    };
                    return NotFound(responseNotFound);
                }

                var response = new TodoResponse
                {
                    StatusCode = 200,
                    Message = "Tarea obtenida correctamente",
                    Todo = todo
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] TodoDto todoDto)
        {
            try
            {
                var todo = new Todo
                {
                    Title = todoDto.Title,
                    Description = todoDto.Description
                };

                await _todoService.CreateTodoAsync(todo);

                var response = new Success
                {
                    StatusCode = 201,
                    Message = "Tarea creada correctamente"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
        {
            try
            {
                var todo = new Todo
                {
                    Title = todoDto.Title,
                    Description = todoDto.Description
                };

                await _todoService.UpdateTodoAsync(id, todo);

                var response = new Success
                {
                    StatusCode = 200,
                    Message = "Tarea actualizada correctamente"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {
                await _todoService.DeleteTodoAsync(id);

                var response = new Success
                {
                    StatusCode = 200,
                    Message = "Tarea eliminada correctamente"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}
