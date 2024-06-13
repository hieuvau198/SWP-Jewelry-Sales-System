using Microsoft.AspNetCore.Mvc;
using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceStall;

namespace JewelSystemBE.Controllers
{
    [Route("api/stall")]
    [ApiController]
    public class StallController : ControllerBase
    {
        private readonly IStallService _stallService;

        public StallController(IStallService stallService)
        {
            _stallService = stallService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_stallService.GetStalls());
        }

        [HttpGet("{stallId}")]
        public IActionResult Get(string stallId)
        {
            if (string.IsNullOrWhiteSpace(stallId))
            {
                return BadRequest(new { message = "Invalid stall ID." });
            }

            var stall = _stallService.GetStall(stallId);
            if (stall == null)
            {
                return NotFound(new { message = "Stall not found." });
            }

            return Ok(stall);
        }

        [HttpPost]
        public IActionResult Post(Stall stall)
        {
            if (stall == null)
            {
                return BadRequest(new { message = "Invalid stall data." });
            }

            var result = _stallService.AddStall(stall);
            if (result==null)
            {
                return StatusCode(500, new { message = "Error adding stall." });
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(Stall stall)
        {
            if (stall == null)
            {
                return BadRequest(new { message = "Invalid stall data." });
            }

            var result = _stallService.UpdateStall(stall);
            if (!result)
            {
                return StatusCode(500, new { message = "Error updating stall." });
            }

            return Ok(new { message = "Stall updated successfully." });
        }

        [HttpDelete("{stallId}")]
        public IActionResult Delete(string stallId)
        {
            if (string.IsNullOrWhiteSpace(stallId))
            {
                return BadRequest(new { message = "Invalid stall ID." });
            }

            var result = _stallService.RemoveStall(stallId);
            if (!result)
            {
                return StatusCode(500, new { message = "Error removing stall." });
            }

            return Ok(new { message = "Stall removed successfully." });
        }
    }
}
