using JewelSystemBE.Service.ServiceAuth;
using Microsoft.AspNetCore.Mvc;
using JewelSystemBE.Model;

namespace JewelSystemBE.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(_authService.RegisterUser(user))
            {
                return Ok(new { message = "User registerd successfully." });
            }
            return BadRequest(new {message = "Username or email already existed."});
        }
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            
            if(_authService.AuthenticateUser(username, password))
            {
                return Ok(new { message = "User signed in successfully." });
            }
            return Unauthorized(new { message = "Wrong username or password" });
        }
        [HttpPost("logintoken")]
        public IActionResult Logintoken(string username, string password)
        {
            if (_authService.AuthenticateUser(username, password))
            {
                var token = _authService.GenerateJwtToken(username);
                return Ok(new { token });
            }
            return Unauthorized(new { message = "Invalid username or password." });
        }
    }
}
