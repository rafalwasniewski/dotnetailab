using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TodoService _todoService;

        public IndexModel(TodoService todoService)
        {
            _todoService = todoService;
        }

        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();
        
        [BindProperty]
        public string? NewTodoTitle { get; set; }

        public int CompletedCount => Todos.Count(t => t.IsCompleted);
        public int TotalCount => Todos.Count;

        public async Task<IActionResult> OnGetAsync()
        {
            Todos = await _todoService.GetTodosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoTitle))
            {
                await _todoService.AddTodoAsync(NewTodoTitle);
                NewTodoTitle = string.Empty;
            }
            
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleAsync(int id)
        {
            var todo = await _todoService.GetTodoAsync(id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                await _todoService.UpdateTodoAsync(todo);
            }
            
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return RedirectToPage();
        }
    }
}