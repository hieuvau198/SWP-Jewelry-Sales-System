using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceUser;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest(new { message = "Invalid User ID." });
            }

            var user = _userService.GetUser(userId);
            if (user == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            user.UserId = Guid.NewGuid().ToString();
            return Ok(_userService.AddUser(user));
        }
        [HttpPut]
        public IActionResult Put(User user)
        {
            return Ok(_userService.UpdateUser(user));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_userService.RemoveUser(id));
        }


    }
}
