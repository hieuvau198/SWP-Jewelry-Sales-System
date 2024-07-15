﻿using JewelBO;
using JewelService.ServiceGold;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
{
    [Route("api/gold")]
    [ApiController]
    public class GoldController : ControllerBase
    {
        private readonly IGoldService _goldService;
        public GoldController(IGoldService goldService)
        {
            _goldService = goldService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Gold>>> Get()
        {
            var golds = await _goldService.GetGolds();
            return Ok(golds);
        }
        [HttpGet("{goldid}")]
        public IActionResult Get(string goldid)
        {
            if (string.IsNullOrWhiteSpace(goldid))
            {
                return BadRequest(new { message = "Invalid gold ID." });
            }

            var gold = _goldService.GetGold(goldid);
            if (gold == null)
            {
                return NotFound(new { message = "Gold not found." });
            }

            return Ok(gold);
        }
        [HttpPost]
        public IActionResult Post(Gold gold)
        {
            return Ok(_goldService.AddGold(gold));
        }
        [HttpPut]
        public IActionResult Put(Gold gold)
        {
            return Ok(_goldService.UpdateGold(gold));
        }
        [HttpDelete]
        public IActionResult Delete(string goldId)
        {
            return Ok(_goldService.RemoveGold(goldId));
        }
    }
}
