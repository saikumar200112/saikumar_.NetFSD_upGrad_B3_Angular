using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("form")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("form")]
        public IActionResult Index(Feedback feedback) 
        {
           
            if (feedback.Rating >= 4)
            {
                ViewData["Message"] = "Thank You!";
            }
            else
            {
                ViewData["Message"] = "We will improve.";
            }

            return View(feedback);
        }
    }
}
