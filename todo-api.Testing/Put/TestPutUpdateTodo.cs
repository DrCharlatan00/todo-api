using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Cryptography.X509Certificates;
using todo_api.Controllers;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Testing;

public class TestPutUpdateTodo
{
    [Fact]
    public async Task TestPutUpdateTodoFunc() {
        var mock = new Mock<ITodoService>();
        int id = 1;
        var updateTodo = new TodoItem
        {
            ID = id,
            IsDone = true,
            Title = "Update"
        };
        mock.Setup(s=> s.Update(id,It.IsAny<TodoItem>())).ReturnsAsync(updateTodo);
        var contoroller = new TodoItemController(mock.Object);
        
        
        var result = await contoroller.UpdateTodo(id,updateTodo);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(updateTodo,ok.Value);
        mock.Verify(s => s.Update(id,updateTodo),Times.Once);
    }

}
