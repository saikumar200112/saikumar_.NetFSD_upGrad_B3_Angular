using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
    
{
    [Route("Admin")]
    public class ProductEntryController : Controller
    {
        public static List<ProductList> _allProducts = new List<ProductList>();
        [HttpGet("Manage")]
        public IActionResult Index()
        {
            ViewBag.MyList = _allProducts;
            return View();
        }
        [HttpPost("Manage")]
        public IActionResult Index(ProductList p)
        {
            _allProducts.Add(p); 
            ViewBag.MyList = _allProducts; 
            return View();
        }
    }
}
