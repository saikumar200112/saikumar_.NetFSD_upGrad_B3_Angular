using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;
using WebApplication12.Services;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetById(id);
            return contact == null ? NotFound() : Ok(contact);
        }

        
        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _service.Add(contact);
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact updatedContact)
        {
            if (id != updatedContact.Id) return BadRequest("ID Mismatch");

            var result = _service.Update(id, updatedContact);
            return result ? NoContent() : NotFound();
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return result ? Ok(new { message = "Deleted successfully" }) : NotFound();
        }
    }
}
