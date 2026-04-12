using Microsoft.AspNetCore.Mvc;
using Moq;
using todo_api.Controllers;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Testing.TestGet
{
    public class UnitTestTodoItemControllerGet
    {
        [Fact]
        public void TestTodoItemController()
        {
            var mock = new Mock<ITodoService>();

            mock.Setup(s => s.GetAll())
                .ReturnsAsync(new List<TodoItem> { new TodoItem { ID = 1, IsDone = false ,Title = "Testing" } }

                );

            var controller = new TodoItemController(mock.Object);


            var result = controller.GetAllTodo();

            //Assert.IsType<TodoItemController>(result);
            var ok = Assert.IsType<OkObjectResult>(result);
            var items = Assert.IsAssignableFrom<IEnumerable<TodoItem>>(ok.Value);

            Assert.Single(items);

        }
    }
}
