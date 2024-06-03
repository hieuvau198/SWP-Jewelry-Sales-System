using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceWarranty;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/warranty")]
    [ApiController]
    public class WarrantyController : ControllerBase
    {
        private readonly IWarrantyService _warrantyService;

        public WarrantyController(IWarrantyService warrantyService)
        {
            _warrantyService = warrantyService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_warrantyService.GetWarranties());
        }

        [HttpGet("{warrantyId}")]
        public IActionResult Get(string warrantyId)
        {
            if (string.IsNullOrWhiteSpace(warrantyId))
            {
                return BadRequest(new { message = "Invalid warranty ID." });
            }

            var warranty = _warrantyService.GetWarranty(warrantyId);
            if (warranty == null)
            {
                return NotFound(new { message = "Warranty not found." });
            }

            return Ok(warranty);
        }

        [HttpPost]
        public IActionResult Post(Warranty warranty)
        {
            try
            {
                return Ok(_warrantyService.AddWarranty(warranty));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpPut]
        public IActionResult Put(Warranty warranty)
        {
            try
            {
                return Ok(_warrantyService.UpdateWarranty(warranty));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpDelete("{warrantyId}")]
        public IActionResult Delete(string warrantyId)
        {
            try
            {
                return Ok(_warrantyService.RemoveWarranty(warrantyId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred: {ex.Message}" });
            }
        }
    }
}
