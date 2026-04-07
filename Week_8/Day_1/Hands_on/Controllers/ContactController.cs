using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models;
using WebApplication7.Repositories;

namespace WebApplication7.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        
        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }
        public IActionResult Details(int id)
        {
            var contobj = _repo.GetContactById(id);
            return View(contobj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_repo.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repo.GetDepartments(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _repo.GetContactById(id);
            ViewBag.Companies = new SelectList(_repo.GetCompanies(), "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_repo.GetDepartments(), "DepartmentId", "DepartmentName", contact.DepartmentId);
            return View(contact);
        }
       

        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Contact";
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var contobj = _repo.GetContactById(id);
            return View(contobj);
        }

            [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var contobj = _repo.GetContactById(id);
            if (contobj != null)
            {
                _repo.DeleteContact(id);
                return RedirectToAction("ShowContacts");
            }
            else
            {
                ViewBag.ErrorMessage = "Requird Contact does not exist";
                return View();
            }
        }
    }
}
