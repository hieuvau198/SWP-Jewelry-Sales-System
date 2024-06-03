using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceProduct;
using Microsoft.AspNetCore.Mvc;

namespace JewelSystemBE.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{productId}")]
        public IActionResult Get(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                return BadRequest(new { message = "Invalid product ID." });
            }

            var product = _productService.GetProduct(productId);
            if (product == null)
            {
                return NotFound(new { message = "Product not found." });
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            return Ok(_productService.AddProduct(product));
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            return Ok(_productService.UpdateProduct(product));
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(string productId)
        {
            return Ok(_productService.RemoveProduct(productId));
        }
    }
}
