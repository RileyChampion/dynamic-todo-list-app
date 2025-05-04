using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TodoApp.API.Data;
using TodoApp.API.Dtos;
using TodoApp.API.Models;
public class AdvancedTodoFeatureProvider : ITodoFeatureProvider {
    private readonly TodoAppDbContext _context;
    public AdvancedTodoFeatureProvider(TodoAppDbContext context) {
        _context = context;
    }
    public async Task<IEnumerable<Todo>> GetAllTodos(string? searchQuery = null){
        var query = _context.Todos.AsQueryable();
        if (!string.IsNullOrEmpty(searchQuery)) {
            query.Where(todo => todo.Title.Contains(searchQuery));
        }
        return await query.OrderBy(todo => todo.Priority ?? int.MaxValue)
            .ThenBy(todo => todo.DueDate ?? DateTime.MaxValue)
            .ToListAsync();
    }
    public async Task<Todo?> GetTodoById(int id){
        return await _context.Todos.FindAsync(id);
    }
    public async Task<Todo> CreateTodo(CreateTodoDto createDto){
        Todo newTodo = new Todo{
            Title = createDto.Title,
            Description = createDto.Description,
            Priority = createDto.Priority,
            DueDate = createDto.DueDate
        };

        _context.Todos.Add(newTodo);

        await _context.SaveChangesAsync();

        return newTodo;
    }
    public async Task<Todo?> UpdateTodo(int id, UpdateTodoDto updateDto){
        var updatedTodo = await _context.Todos.FindAsync(id);
        
        if (updatedTodo == null) {
            return null;
        }

        updatedTodo.Title = updateDto.Title;
        updatedTodo.Description = updateDto.Description;
        updatedTodo.IsCompleted = updateDto.IsCompleted;
        if (updateDto.IsCompleted) {
            updatedTodo.CompletedAt = DateTime.Now;
        } else {
            updatedTodo.CompletedAt = null;
        }
        updatedTodo.Priority = updateDto.Priority;
        updatedTodo.DueDate = updateDto.DueDate;
        updatedTodo.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return updatedTodo;
    }
    public async Task<bool> DeleteTodo(int id){
        var deleteTodo = await _context.Todos.FindAsync(id);

        if (deleteTodo == null)
            return false;
        
        _context.Todos.Remove(deleteTodo);

        await _context.SaveChangesAsync();

        return true;
    }
}