using DoStuff.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoStuff
{
    public class TodoListViewModel
    {
        public DbSet<TodoList> Lists { get; set; }
    }
}