using Auth_Service.Models;
using Auth_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public AuthenticateController(ApplicationDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;

        
        }

        [HttpPost]
        public IActionResult Login(UserModel requestUser)
        {
            
            UserModel? userObj = _context.Users.FirstOrDefault(user => user.UserName ==
            requestUser.UserName && user.Password == requestUser.Password);

            if (userObj != null)
            {
              
                string tokenStr = _jwtService.GenerateJSONWebToken(userObj);
                return Ok(new { token = tokenStr });
            }
            else
            {
                return BadRequest("Invalid user id or password");
            }
        }
    }
}
