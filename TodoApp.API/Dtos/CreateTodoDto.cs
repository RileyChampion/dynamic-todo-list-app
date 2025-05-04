namespace TodoApp.API.Dtos {
    public class CreateTodoDto
    {
        public required string Title {get; set;}
        public required string Description {get; set;}
        public int? Priority {get; set;} = null;
        public DateTime? DueDate {get; set;} = null;
    }
}