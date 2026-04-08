using Microsoft.AspNetCore.Mvc;
using WebApplication8.Repositories;

namespace WebApplication8.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        
        public IActionResult Students()
        {
            var data = _repo.GetStudentsWithCourse();
            return View(data);
        }

     
        public IActionResult Courses()
        {
            var data = _repo.GetCoursesWithStudents();
            return View(data);
        }
    }
}
