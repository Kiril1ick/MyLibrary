using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var result = _context.Books.Include(x=>x.Genre).OrderBy(x=>x.Title).ToList();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Searching)
        {
            ViewData["Search"] = Searching;

            var query = from x in _context.Books select x;
            if (!String.IsNullOrEmpty(Searching))
            {
                query = query.Where(x => x.Title.Contains(Searching) || x.Author.Contains(Searching));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Genres = _context.Genres.OrderBy(x => x.GenreName).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = _context.Genres.OrderBy(x => x.GenreName).ToList();
            return View();
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Genres = _context.Genres.OrderBy(x => x.GenreName).ToList();
            var result = _context.Books.Find(id);
            return View("Create",result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = _context.Genres.OrderBy(x => x.GenreName).ToList();
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            var result = _context.Books.Find(id);
            if (result != null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
