using DoStuff.Data;
using DoStuff.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoStuff.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        
        
        [HttpPost]
        public IActionResult Add(string content, int listId)
        {
            if(listId == 0)
            {
                var list = new TodoList { Title = "New List" };
                _context.TodoList.Add(list);
                _context.SaveChanges();
                listId = list.Id;
            }
            var item = new TodoItem { 
                Content = content,
                ListId = listId
            };
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index", new { listId = listId});
        }

        public IActionResult Check(int itemId, int listId)
        {
            var item = _context.Items.First(i => i.Id == itemId);
            item.IsDone = !item.IsDone;
            _context.Items.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index", new { listId });
        }

        public IActionResult Delete(int itemId, int listId)
        {
            var item = _context.Items.First(i => i.Id == itemId);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index", new { listId });
        }

        public IActionResult Index(int listId)
        {
            var list = _context.TodoList.Include(l => l.TodoItems).FirstOrDefault(i => i.Id == listId);

            var model = new TodoViewModel
            {
                ListId = list?.Id ?? -1,
                Title = list?.Title ?? "Title",
                Items = list?.TodoItems.OrderByDescending(i => i.CreatedDate).ToList() ?? new List<TodoItem>()
            };
            return View(model);
        }
    }
}
