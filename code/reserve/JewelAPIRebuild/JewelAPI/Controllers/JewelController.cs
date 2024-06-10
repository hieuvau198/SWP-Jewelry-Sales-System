using JewelBO;
using JewelService.ServiceJewel;
using Microsoft.AspNetCore.Mvc;

namespace JewelAPI.Controllers
{
    [Route("api/jewel")]
    [ApiController]
    public class JewelController : ControllerBase
    {
        private readonly IJewelService _jewelService;
        public JewelController(IJewelService jewelService)
        {
            _jewelService = jewelService;
        }


        // GET: api/<JewelController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jewelService.GetJewels());
        }

        // GET api/jewel/id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/<JewelController>
        [HttpPost]
        public IActionResult Post(Jewel jewel)
        {
            return Ok(_jewelService.AddJewel(jewel));
        }

        // PUT api/<JewelController>/5
        [HttpPut()]
        public IActionResult Put(Jewel jewel)
        {
            return Ok(_jewelService.UpdateJewel(jewel));
        }

        // DELETE api/<JewelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_jewelService.RemoveJewel(id));
        }
    }
}
