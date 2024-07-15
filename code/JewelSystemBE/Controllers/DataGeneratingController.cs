using JewelSystemBE.Data;
using JewelSystemBE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/datagenerating")]
    [ApiController]
    public class DataGeneratingController : ControllerBase
    {
        private readonly DataGenerating _dataGenerating;

        public DataGeneratingController(DataGenerating dataGenerating)
        {
            _dataGenerating = dataGenerating;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok( await _dataGenerating.GetNewProducts());
        }
        [HttpGet("string")]
        public async Task<ActionResult<string>> GetString()
        {
            return Ok(await _dataGenerating.GetNewProductsToString());
        }
        [HttpGet("StringSI")]
        public async Task<ActionResult<string>> GetStringSI()
        {
            return Ok(await _dataGenerating.GetNewStallItemsToString());
        }
        [HttpGet("StringSE")]
        public async Task<ActionResult<string>> GetStringSE()
        {
            return Ok(await _dataGenerating.GetNewStallEmployeesToString());
        }
    }
}
