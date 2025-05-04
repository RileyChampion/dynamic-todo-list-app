using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.Dtos;
using TodoApp.API.Models;

namespace TodoApp.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase {

        private readonly TodoFeatureFactory _factory;

        public TodosController(TodoFeatureFactory factory){
            _factory = factory;
        }

        //  GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos(
            [FromQuery] string provider = "basic",
            [FromQuery] string? searchQuery = null
        ) {
            var todoProvider = _factory.CreateProvider(provider);
            var todos = await todoProvider.GetAllTodos(searchQuery);
            return Ok(todos);
        }

        // GET: api/Todos/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(
            int id,
            [FromQuery] string provider = "basic"
        ) {
            var todoProvider = _factory.CreateProvider(provider);
            var todo = await todoProvider.GetTodoById(id);

            if (todo == null) {
                return NotFound();
            }

            return Ok(todo);
        }

        // POST: api/Todos
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(
            CreateTodoDto todo,
            [FromQuery] string provider = "basic"
        ) {
            var todoProvider = _factory.CreateProvider(provider);
            var result = await todoProvider.CreateTodo(todo);

            return CreatedAtAction(nameof(GetTodo), new {id = result.Id}, result);
        }

        // PUT: api/Todos/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> UpdateTodo(
            int id,
            [FromBody] UpdateTodoDto todo,
            [FromQuery] string provider = "basic"
        ) {
            var todoProvider = _factory.CreateProvider(provider);
            var result = await todoProvider.UpdateTodo(id, todo);
            if (result == null) {
                return NotFound();
            }

            return Ok(result);

        }

        // Delete: api/Todos/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(
            int id,
            [FromQuery] string provider = "basic"
        ) {
            var todoProvider = _factory.CreateProvider(provider);
            var result = await todoProvider.DeleteTodo(id);
            if (!result) {
                return NotFound();
            }

            return NoContent();
        }
    }
}