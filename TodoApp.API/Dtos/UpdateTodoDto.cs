namespace TodoApp.API.Dtos {
    public class UpdateTodoDto {
        public required string Title {get; set;}
        public required string Description {get; set;}
        public bool IsCompleted {get; set;}
        public int? Priority {get; set;} = null;
        public DateTime? DueDate{get; set;} = null;
    }
}