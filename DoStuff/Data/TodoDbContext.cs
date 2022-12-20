using DoStuff.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DoStuff.Data
{
    public class TodoDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ToDoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .HasOne(i => i.TodoList)
                .WithMany(l => l.TodoItems)
                .HasForeignKey(i => i.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<TodoList> TodoList { get; set; }

        public DbSet<TodoItem> Items { get; set; }
    }
}
