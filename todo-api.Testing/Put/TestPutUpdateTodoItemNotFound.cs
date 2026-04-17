using Microsoft.AspNetCore.Mvc;
using Moq;
using todo_api.Controllers;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Testing;

public class TestPutUpdateTodoItemNotFound
{
    [Fact]
    public async Task TestUpdateNotFound() {
        var mock = new Mock<ITodoService>();

        int id = 999;
        var Todo = new TodoItem
        {
            ID = id,
            IsDone = true,
            Title = "dsf"
        };

        mock.Setup(s => s.Update(id,It.IsAny<TodoItem>())).ReturnsAsync((TodoItem)null);

        var controller = new TodoItemController(mock.Object);

        var ans = await controller.UpdateTodo(id,Todo);

        Assert.IsType<NotFoundResult>(ans);
        mock.Verify(s => s.Update(id, Todo), Times.Once);
    }
}
