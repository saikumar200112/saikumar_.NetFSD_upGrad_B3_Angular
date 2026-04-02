using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null) return NotFound();

            return View(contact);
        }

     
        public IActionResult AddContact()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contactInfo);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Data";
                return View();
            }
        }
    }
}
