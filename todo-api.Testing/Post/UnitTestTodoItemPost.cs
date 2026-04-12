using Microsoft.AspNetCore.Mvc;
using Moq;
using todo_api.Controllers;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Testing;

public class UnitTestTodoItemPost
{
    [Fact]
    public void TestCreatePost() {
        var mock = new Mock<ITodoService>();

        var newItem = new TodoItem
        {
            ID = 1,
            Title = "Test",
            IsDone = false
        };

        mock.Setup(s => s.Create(It.IsAny<TodoItem>()))
            .ReturnsAsync(newItem);

        var controller = new TodoItemController(mock.Object);
        var result = controller.CreateTodo(newItem);

        var ok = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(newItem, ok.Value);

        mock.Verify(s => s.Create(It.Is<TodoItem>(
                i =>
                i.ID == newItem.ID &&
                i.Title == newItem.Title &&
                i.IsDone == newItem.IsDone
            )
            ),Times.Once);


    }

}
