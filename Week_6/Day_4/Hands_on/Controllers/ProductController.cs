using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
       public List<Products> GetProducts()
        {
            List<Products> Prodlist = new List<Products>();
            Products p1 = new Products {PId=1,Pname="samsung",    Price=40000, Category="Electronics",Stock=10};
            Products p2 = new Products { PId = 2, Pname = "sony", Price = 35000, Category = "Electronics", Stock = 10 };
            Products p3 = new Products { PId = 3, Pname = "vivo", Price = 30000, Category = "Electronics", Stock = 10 };
            Products p4 = new Products { PId = 4, Pname = "oppo", Price = 20000, Category = "Electronics", Stock = 10 };
            Prodlist.Add(p1);
            Prodlist.Add(p2);
            Prodlist.Add(p3);
            Prodlist.Add(p4);
            return Prodlist;
        }
        public IActionResult Index()
        {
            List<Products> products = GetProducts();
       
            return View(products);
        }
       
        public IActionResult Details(int id)
        {
            List<Products> products = GetProducts();
           
            Products Product = products.FirstOrDefault(p => p.PId == id);
          
            return View(Product);
        }
    }
}
