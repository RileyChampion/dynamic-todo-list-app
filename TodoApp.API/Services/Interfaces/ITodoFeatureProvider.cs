using TodoApp.API.Dtos;
using TodoApp.API.Models;

public interface ITodoFeatureProvider {
    Task<IEnumerable<Todo>> GetAllTodos(string? searchQuery = null);
    Task<Todo?> GetTodoById(int id);
    Task<Todo> CreateTodo(CreateTodoDto todo);
    Task<Todo?> UpdateTodo(int id, UpdateTodoDto todo);
    Task<bool> DeleteTodo(int id);
}