using Microsoft.AspNetCore.Mvc;
using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceStallItem;

namespace JewelSystemBE.Controllers
{
    [Route("api/stallitem")]
    [ApiController]
    public class StallItemController : ControllerBase
    {
        private readonly IStallItemService _stallItemService;

        public StallItemController(IStallItemService stallItemService)
        {
            _stallItemService = stallItemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_stallItemService.GetStallItems());
        }

        [HttpGet("{stallItemId}")]
        public IActionResult Get(string stallItemId)
        {
            if (string.IsNullOrWhiteSpace(stallItemId))
            {
                return BadRequest(new { message = "Invalid stall item ID." });
            }

            var stallItem = _stallItemService.GetStallItem(stallItemId);
            if (stallItem == null)
            {
                return NotFound(new { message = "Stall item not found." });
            }

            return Ok(stallItem);
        }

        [HttpPost]
        public IActionResult Post(StallItem stallItem)
        {
            if (stallItem == null)
            {
                return BadRequest(new { message = "Invalid stall item data." });
            }

            var result = _stallItemService.AddStallItem(stallItem);
            if (result==null)
            {
                return StatusCode(500, new { message = "Error adding stall item." });
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(StallItem stallItem)
        {
            if (stallItem == null)
            {
                return BadRequest(new { message = "Invalid stall item data." });
            }

            var result = _stallItemService.UpdateStallItem(stallItem);
            if (!result)
            {
                return StatusCode(500, new { message = "Error updating stall item." });
            }

            return Ok(new { message = "Stall item updated successfully." });
        }

        [HttpDelete("{stallItemId}")]
        public IActionResult Delete(string stallItemId)
        {
            if (string.IsNullOrWhiteSpace(stallItemId))
            {
                return BadRequest(new { message = "Invalid stall item ID." });
            }

            var result = _stallItemService.RemoveStallItem(stallItemId);
            if (!result)
            {
                return StatusCode(500, new { message = "Error removing stall item." });
            }

            return Ok(new { message = "Stall item removed successfully." });
        }
    }
}
