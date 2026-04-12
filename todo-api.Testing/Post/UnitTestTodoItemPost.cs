using Moq;
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
            .Returns(Task.CompletedTask);


    }

}
