namespace todo_api.Models
{
    public class TodoItem
    {
        public TodoItem(int iD, string title, bool isDone)
        {
            ID = iD;
            Title = title;
            IsDone = isDone;
        }

        public TodoItem()
        {
            
        }

        public int ID { get; set; } =  0;
        public string Title { get; set; } = string.Empty;

        public bool IsDone { get; set; } = false;
    }
}
