using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetTodosAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> AddTodoAsync(string title)
        {
            var todo = new TodoItem
            {
                Title = title,
                IsCompleted = false
            };
            
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<TodoItem?> GetTodoAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task UpdateTodoAsync(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo != null)
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}