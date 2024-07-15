using JewelBO;
using JewelService.ServiceStallEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
{
    [Route("api/stallemployee")]
    [ApiController]
    public class StallEmployeeController : ControllerBase
    {
        private readonly IStallEmployeeService _stallEmployeeService;

        public StallEmployeeController(IStallEmployeeService stallEmployeeService)
        {
            _stallEmployeeService = stallEmployeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_stallEmployeeService.GetStallEmployees());
        }

        [HttpGet("{stallEmployeeId}")]
        public IActionResult Get(string stallEmployeeId)
        {
            if (string.IsNullOrWhiteSpace(stallEmployeeId))
            {
                return BadRequest(new { message = "Invalid stall employee ID." });
            }

            var stallEmployee = _stallEmployeeService.GetStallEmployee(stallEmployeeId);
            if (stallEmployee == null)
            {
                return NotFound(new { message = "Stall employee not found." });
            }

            return Ok(stallEmployee);
        }

        [HttpPost]
        public IActionResult Post(StallEmployee stallEmployee)
        {
            if (stallEmployee == null)
            {
                return BadRequest(new { message = "Invalid stall employee data." });
            }

            var result = _stallEmployeeService.AddStallEmployee(stallEmployee);
            if (result == null)
            {
                return StatusCode(500, new { message = "Error adding stall employee." });
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(StallEmployee stallEmployee)
        {
            if (stallEmployee == null)
            {
                return BadRequest(new { message = "Invalid stall employee data." });
            }

            var result = _stallEmployeeService.UpdateStallEmployee(stallEmployee);
            if (!result)
            {
                return StatusCode(500, new { message = "Error updating stall employee." });
            }

            return Ok(new { message = "Stall employee updated successfully." });
        }

        [HttpDelete("{stallEmployeeId}")]
        public IActionResult Delete(string stallEmployeeId)
        {
            if (string.IsNullOrWhiteSpace(stallEmployeeId))
            {
                return BadRequest(new { message = "Invalid stall employee ID." });
            }

            var result = _stallEmployeeService.RemoveStallEmployee(stallEmployeeId);
            if (!result)
            {
                return StatusCode(500, new { message = "Error removing stall employee." });
            }

            return Ok(new { message = "Stall employee removed successfully." });
        }
    }
}
