using JewelBO;
using JewelService.ServiceAuth;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
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
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (_authService.AuthenticateUser(loginDto.Username, loginDto.Password))
            {
                var user = _authService.GetUserByUsername(loginDto.Username);
                // Ensure not to return the password
                user.Password = null;
                return Ok(user);
            }
            return Unauthorized(new { message = "Wrong username or password" });
        }
        [HttpPost("logintoken")]
        public IActionResult Logintoken([FromBody] LoginDto loginDto)
        {
            if (_authService.AuthenticateUser(loginDto.Username, loginDto.Password))
            {
                var token = _authService.GenerateJwtToken(loginDto.Username);
                return Ok(new { token });
            }
            return Unauthorized(new { message = "Invalid username or password." });
        }
    }
}
