using Category_Service.Models;
using Category_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Category_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service) => _service = service;

        [HttpGet] public async Task<IActionResult> Get() => Ok(await _service.GetAllCategories());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id) => Ok(await _service.GetCategoryById(id));
        [HttpPost] public async Task<IActionResult> Post(Category cat) { await _service.CreateCategory(cat); return Ok(); }
        [HttpPut] public async Task<IActionResult> Put(Category cat) { await _service.UpdateCategory(cat); return Ok(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.RemoveCategory(id); return Ok(); }
    }
}
