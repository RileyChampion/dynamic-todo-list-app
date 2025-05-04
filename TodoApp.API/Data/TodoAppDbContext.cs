using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using TodoApp.API.Models;

namespace TodoApp.API.Data {
    public class TodoAppDbContext : DbContext {
        public DbSet<Todo> Todos {get; set;}

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>()
                .Property(todo => todo.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Todo>()
                .Property(todo => todo.Description)
                .HasMaxLength(500);
        }
    }
}