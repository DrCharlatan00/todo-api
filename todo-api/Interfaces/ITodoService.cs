using Microsoft.AspNetCore.Mvc;
using todo_api.Models;

namespace todo_api.Interfaces
{
    public interface ITodoService
    {
        public Task<TodoItem> Update(int id,TodoItem item);
        public Task<List<TodoItem>> GetAll();
        public Task<TodoItem> Create(TodoItem item);
        public Task<TodoItem> SearchById(int id);
        public Task<(bool IsOk, string? Messange)> RemoveById(int id);
    }
}
