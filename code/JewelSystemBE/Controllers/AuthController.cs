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
        public IActionResult Login([FromBody] LoginDto loginDto)
        {

            string verify = _authService.AuthenticateUser(loginDto.Username, loginDto.Password);
            if (verify.Equals("Wrong Username"))
            { return Unauthorized(new { message = "Wrong Username" }); }
            if (verify.Equals("Wrong Password."))
            { return Unauthorized(new { message = "Wrong Password" }); }
            
            
            return Ok(_authService.GetUserByUsername(loginDto.Username));
            
        }
        [HttpPost("logintoken")]
        public IActionResult Logintoken([FromBody] User user)
        {
            string verify = _authService.AuthenticateUser(user.Username, user.Password);
            if (verify.Equals("Wrong Username"))
            { return Unauthorized(new { message = "Wrong Username" }); }
            if (verify.Equals("Wrong Password."))
            { return Unauthorized(new { message = "Wrong Password" }); }

            var token = _authService.GenerateJwtToken(user, verify);
            return Ok(new { token });

        }
    }
}
