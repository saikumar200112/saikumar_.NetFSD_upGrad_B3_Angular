using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var movies = _service.GetMovies();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var MovieObj = _service.GetMovie(id);
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
                _service.CreateMovie(movie);
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
            var prodObj = _service.GetMovie(id);
            return View(prodObj);
        }


        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                _service.UpdateMovie(movie);
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
            var movieObj = _service.GetMovie(id);
            return View(movieObj);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _service.GetMovie(id);

            if (prodObj != null)
            {
                _service.DeleteMovie(id);
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
