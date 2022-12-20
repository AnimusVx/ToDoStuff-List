using DoStuff.Data;
using DoStuff.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Controllers
{
    public class HomeController : Controller
    {
        private readonly TodoDbContext _context;

        public HomeController(TodoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new TodoListViewModel
            {
                Lists = _context.TodoList
            };
            return View(model);
        }

        public IActionResult Add(string title)
        {
            var list = new TodoList { Title = title };
            _context.TodoList.Add(list);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int listId)
        {
            var list = _context.TodoList.FirstOrDefault(l => l.Id == listId);
            _context.TodoList.Remove(list);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
