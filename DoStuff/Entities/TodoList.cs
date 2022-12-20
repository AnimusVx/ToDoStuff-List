using System.ComponentModel.DataAnnotations.Schema;

namespace DoStuff.Entities
{
    [Table("TodoList")]
    public class TodoList
    {

        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
