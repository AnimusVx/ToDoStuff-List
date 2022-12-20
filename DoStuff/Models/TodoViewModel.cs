using DoStuff.Entities;

namespace DoStuff
{
    public class TodoViewModel
    {
        public string Title { get; set; }
        public List<TodoItem> Items { get; set; }
        public int ListId { get; internal set; }
    }
}