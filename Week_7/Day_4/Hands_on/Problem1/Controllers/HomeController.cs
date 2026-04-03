using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _context.Courses.ToList();

            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Student student)
        {       
               
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Details"); 
            
        }
        public IActionResult Courses()
        {
            var courses = _context.Courses.Include(c => c.Students).ToList();
            return View(courses);
        }
        
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
