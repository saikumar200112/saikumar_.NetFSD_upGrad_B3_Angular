using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("student-portal")]
    public class StudentController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            return RedirectToAction("Display", new {name=studentName,age=age,course=course});
        }
        [HttpGet("details")]
        public IActionResult Display(string name, int age, string course)
        {
           
            ViewBag.StudentName = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
