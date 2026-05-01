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

        public TodoListViewModel Model { get; set; } = new TodoListViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            Model.Todos = await _todoService.GetTodosAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!string.IsNullOrWhiteSpace(Model.NewTodoTitle))
            {
                await _todoService.AddTodoAsync(Model.NewTodoTitle);
                Model.NewTodoTitle = string.Empty;
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