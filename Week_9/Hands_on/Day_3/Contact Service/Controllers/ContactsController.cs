using Contact_Service.Models;
using Contact_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        public ContactsController(IContactService service) => _service = service;

        [HttpGet] public async Task<IActionResult> Get() => Ok(await _service.GetAllContacts());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetContactById(id));
        [HttpPost] public async Task<IActionResult> Post(Contact c) { await _service.CreateContact(c); return Ok(); }
        [HttpPut] public async Task<IActionResult> Put(Contact c) { await _service.UpdateContact(c); return Ok(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.RemoveContact(id); return Ok(); }
    }
}
