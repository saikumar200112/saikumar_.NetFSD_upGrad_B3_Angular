using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        public static List<ContactInfo>contacts = new List<ContactInfo>
          {
             new ContactInfo {ContactId=1,FirstName="saikumar",   LastName="kagithala", CompanyName="Cognizent",EmailId="sai123@gmail.com", MobileNo=7543865439,Designation="Developer"},
             new ContactInfo { ContactId = 2,FirstName = "vamsi", LastName = "royal", CompanyName = "TCS", EmailId = "vamsi20@gmail.com",MobileNo=9543865437,Designation="Analyst" },
             new ContactInfo { ContactId = 3,FirstName = "jaswanth", LastName = "kagithala", CompanyName = "Deloitee", EmailId = "jash10@gamil.com",MobileNo=9543865539,Designation="Web Developer" },
             new ContactInfo { ContactId = 4,FirstName = "vinod", LastName = "kagithala", CompanyName = "Wipro", EmailId ="vindo19@gmail.com",MobileNo=8533865439,Designation="Android Developer"}

          };
        public IActionResult ShowContacts()
        {
            return View(contacts);
        }
        public IActionResult GetContactById(int id)
        {
            ContactInfo contact = contacts.FirstOrDefault(c=>c.ContactId == id);
            
            return View(contact);
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactInfo obj)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(obj);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid data some fields are missing";
                return View();
            }

        }
        

    }
}
