using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace WebApplication1.Controllers
{
    [Route("Calculator")]
    public class CalculatorController : Controller
    {
        
        [HttpGet]
        [Route("Add")]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [Route("Add")]
        public IActionResult Add()
        {
            
            string num1 = Request.Form["number1"];
            string num2 = Request.Form["number2"];

            double result = 0;

            
            if (double.TryParse(num1, out double n1) && double.TryParse(num2, out double n2))
            {
                result = n1 + n2;
                ViewData["Result"] = "The total is: " + result;
            }
            else
            {
                ViewData["Result"] = "Please enter valid numbers!";
            }

            return View("Index");
        }

    }
}
