using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using WebApplication10.Repositories;

namespace WebApplication10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;
        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await _repo.GetByIdAsync(id);
            return contact == null ? NotFound("contact not found") : Ok(contact);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(ContactInfo contact)
        {
            await _repo.AddAsync(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.ContactId }, contact);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ContactInfo contact)
        {
            if (id != contact.ContactId)
            {
                return NotFound("Contact not found");
            }
            await _repo.UpdateAsync(contact);
            return Ok(new {message="contact update successfully"});
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            await _repo.DeleteAsync(id);
            return Ok(new { message = "contact deleted successfully" });
        }
    }
}
