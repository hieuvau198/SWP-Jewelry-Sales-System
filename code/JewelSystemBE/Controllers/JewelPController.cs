using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceJewelP;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/jewelp")]
    [ApiController]
    public class JewelPController : ControllerBase
    {
        private readonly IJewelPService _jewelPService;
        public JewelPController(IJewelPService jewelPService)
        {
            _jewelPService = jewelPService;
        }
        [HttpPost]
        public async Task<IActionResult> AddJewelP([FromForm] JewelModel model)
        {
            if (model == null) { return BadRequest("Null"); }
            var jewelP = new JewelP()
            {
                Name = model.Name
            };
            if(model.Picture != null && model.Picture.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await model.Picture.CopyToAsync(ms);
                    jewelP.Picture = ms.ToArray();
                }
            }

            _jewelPService.AddJewelP(jewelP);
            return Ok(jewelP);
        }
        [HttpGet("name")]
        public async Task<IActionResult> GetJewelP (string name)
        {
            var jewelP =  _jewelPService.GetJewelP(name);
            if (jewelP == null)
            { return BadRequest("Not found"); }
            return File(jewelP.Picture, "image/jpeg");
        }
        [HttpGet("base64")]
        public async Task<IActionResult> GetJewelPBase64 (string name)
        {
            var jewelP = _jewelPService.GetJewelP(name);
            if(jewelP == null)
            { return BadRequest("Null"); }
            var jewelPBase64 = new JewelModel
            {
                Name = jewelP.Name,
                PictureBase64 = Convert.ToBase64String(jewelP.Picture)
            };

            return Ok(jewelPBase64);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_jewelPService.GetAll());
        }
    }
}
