using System.ComponentModel.DataAnnotations.Schema;

namespace DoStuff.Entities
{
    [Table("TodoItems")]
    public class TodoItem
    {
        public int Id { get; set; }

        public bool IsDone { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public int ListId { get; set; }

        public TodoList TodoList { get; set; }
    }
}
