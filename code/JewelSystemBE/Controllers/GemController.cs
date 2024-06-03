using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceGem;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/gem")]
    [ApiController]
    public class GemController : ControllerBase
    {
        private readonly IGemService _gemService;
        public GemController(IGemService gemService)
        {
            _gemService = gemService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gemService.GetGems());
        }
        [HttpGet("{gemid}")]
        public IActionResult Get(string gemid)
        {
            if (string.IsNullOrWhiteSpace(gemid))
            {
                return BadRequest(new { message = "Invalid gem ID." });
            }

            var gem = _gemService.GetGem(gemid);
            if (gem == null)
            {
                return NotFound(new { message = "Gem not found." });
            }

            return Ok(gem);
        }
        [HttpPost]
        public IActionResult Post(Gem gem)
        {
            return Ok(_gemService.AddGem(gem));
        }
        [HttpPut]
        public IActionResult Put(Gem gem)
        {
            return Ok(_gemService.UpdateGem(gem));
        }
        [HttpDelete]
        public IActionResult Delete(string gemId)
        {
            return Ok(_gemService.RemoveGem(gemId));
        }
    }
}
