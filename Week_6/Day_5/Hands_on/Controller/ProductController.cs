using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {


        public static List<Products> products = new List<Products>
          {
             new Products {PId=1,Pname="samsung",    Price=40000, Category="Electronics",Stock=10},
             new Products { PId = 2, Pname = "sony", Price = 35000, Category = "Electronics", Stock = 10 },
             new Products { PId = 3, Pname = "vivo", Price = 30000, Category = "Electronics", Stock = 10 },
             new Products { PId = 4, Pname = "oppo", Price = 20000, Category = "Electronics", Stock = 10 }

          };
        public IActionResult Index()
        { 
       
            return View(products);
        }
       
        public IActionResult Details(int id)
        {
            
           
            Products Product = products.FirstOrDefault(p => p.PId == id);
          
            return View(Product);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Products obj)
        {
            products.Add(obj);

            return RedirectToAction("Index");
       
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Products obj = products.FirstOrDefault(item => item.PId == id);

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Products prod)
        {
            var exitProd = products.FirstOrDefault(x => x.PId == prod.PId);
            exitProd.Pname = prod.Pname;
            exitProd.Price = prod.Price;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Products Obj = products.FirstOrDefault(item => item.PId == id);
            return View(Obj);
        }

        [HttpPost]
        [ActionName("Delete")]      
        public IActionResult DeleteConfirm(int id)
        {
            Products empObj = products.FirstOrDefault(item => item.PId == id);
            products.Remove(empObj);

            return RedirectToAction("Index");
        }



    }
}
