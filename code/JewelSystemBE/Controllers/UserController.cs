using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceUser;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("v1/api/user")]
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
        [HttpPost]
        public IActionResult Post(User user)
        {
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
