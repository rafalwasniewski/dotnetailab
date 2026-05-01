using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class TodoListViewModel
    {
        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();
        
        [StringLength(200)]
        public string? NewTodoTitle { get; set; }
        
        public int CompletedCount => Todos.Count(t => t.IsCompleted);
        public int TotalCount => Todos.Count;
    }
}