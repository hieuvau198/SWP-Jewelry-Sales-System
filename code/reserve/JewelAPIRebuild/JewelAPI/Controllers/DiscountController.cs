using JewelBO;
using JewelService.ServiceDiscount;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
{
    [Route("api/discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_discountService.GetDiscounts());
        }

        [HttpGet("{discountId}")]
        public IActionResult Get(string discountId)
        {
            if (string.IsNullOrWhiteSpace(discountId))
            {
                return BadRequest(new { message = "Invalid discount ID." });
            }

            var discount = _discountService.GetDiscount(discountId);
            if (discount == null)
            {
                return NotFound(new { message = "Discount not found." });
            }

            return Ok(discount);
        }

        [HttpPost]
        public IActionResult Post(Discount discount)
        {
            return Ok(_discountService.AddDiscount(discount));
        }

        [HttpPut]
        public IActionResult Put(Discount discount)
        {
            return Ok(_discountService.UpdateDiscount(discount));
        }

        [HttpDelete("{discountId}")]
        public IActionResult Delete(string discountId)
        {
            return Ok(_discountService.RemoveDiscount(discountId));
        }
    }
}
