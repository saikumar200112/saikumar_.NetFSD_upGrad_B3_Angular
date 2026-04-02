using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var MovieObj = _context.Movies.FirstOrDefault(x => x.Id == id);
            return View(MovieObj);
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid movie details.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prodObj = _context.Movies.Find(id);
            return View(prodObj);
        }


        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid movie details.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieObj = _context.Movies.Find(id);
            return View(movieObj);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _context.Movies.Find(id);

            if (prodObj != null)
            {
                _context.Movies.Remove(prodObj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested movie does not exists";
                return View();
            }
        }
    }
}
