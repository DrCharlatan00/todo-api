using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todo_api.Models;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        public List<TodoItem> items = new();
        [HttpGet]
        public async Task<IActionResult> Get() {
            return  Ok(items);
        }
        public async Task<IActionResult> SearchById(int idProd) {
            var item = items.Where(p => p.ID == idProd).FirstOrDefault();
            if (item is null) return NotFound();
            return Ok(item);
        }
        public async Task<IActionResult> RemoveById(int idProd)
        {
            var item = items.Where(p => p.ID == idProd).FirstOrDefault();
            if (item is null) return NotFound();
            try
            {
                items.Remove(item);
            }
            catch
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
