using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }
        public IActionResult ShowContacts()
        {
            return View(_service.GetAllContacts());
        }
        [HttpGet]
       public IActionResult AddContact()
        {
            ViewBag.Companies = _service.GetCompanies();
            ViewBag.Departments = _service.GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _service.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            ViewBag.Companies = _service.GetCompanies();
            ViewBag.Departments = _service.GetDepartments();
            return View(_service.GetContactById(id));
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            _service.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prodObj = _service.GetContactById(id);
            return View(prodObj);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var prodObj = _service.GetContactById(id);

            if (prodObj != null)
            {
                _service.DeleteContact(id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Requested product does not exists";
                return View();
            }
        }
    }
}
