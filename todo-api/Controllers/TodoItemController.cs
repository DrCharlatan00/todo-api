using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoItemController(ITodoService service)
        {
            _service = service;
        }

        
        
        public List<TodoItem> items = new();
        [HttpGet]
        public async Task<IActionResult> GetAllTodo() {
            return  Ok(await _service.GetAll());
        }

        public async Task<IActionResult> CreateTodo(TodoItem item) {
            try
            {
                var answer = await _service.Create(item);
            }
            catch {
                return BadRequest();
            }
            return Ok();
        }
        public async Task<IActionResult> SearchById(int idProd) {
            var data = await _service.GetAll();
            var item = data.Where(p => p.ID == idProd).FirstOrDefault();
            if (item is null) return NotFound();
            return Ok(item);
        }
        public async Task<IActionResult> RemoveById(int idProd)
        {
            var data = await _service.RemoveById(idProd);
            if (!data.IsOk) return NotFound();
            return Ok();
        }
    }
}
