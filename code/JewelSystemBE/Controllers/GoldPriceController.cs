using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/goldprice")]
    [ApiController]
    public class GoldPriceController : ControllerBase
    {
        private readonly GoldPriceService _goldPriceService;

        public GoldPriceController(GoldPriceService goldPriceService)
        {
            _goldPriceService = goldPriceService;
        }
        [HttpGet]
        public async Task<ActionResult<List<GoldPrice>>> GetGoldPrices()
        {
            var goldPrices = await _goldPriceService.GetGoldPricesAsync();
            return Ok(goldPrices);
        }
    }
}
