using todo_api.Controllers;

namespace todo_api.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void TestTodoItemController()
        {
            var controller = new TodoItemController();

            var result = controller.GetAllTodo();

            Assert.IsType<TodoItemController>(result);
        }
    }
}
