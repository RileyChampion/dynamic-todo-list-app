using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.API.Models {
    public class Todo {
        public int Id {get; set;}
        public required string Title {get; set;}
        public required string Description {get; set;}
        public bool IsCompleted {get;set;} = false;
        public DateTime? CompletedAt {get; set;} = null;
        [Editable(false)]
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt{get; set;} = DateTime.Now;

        //Advanced Features
        public int? Priority {get; set;} = null;
        public DateTime? DueDate {get; set;} = null;
    }
}