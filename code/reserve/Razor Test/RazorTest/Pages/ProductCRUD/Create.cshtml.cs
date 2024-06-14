using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.ProductCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ProductService productService, ILogger<CreateModel> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {
            // Initialize the Gold with a new ID
            Product = new Product
            {
                ProductId = Guid.NewGuid().ToString()

            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        _logger.LogError($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }
            

            // Check if GoldID is still empty and generate it
            if (string.IsNullOrEmpty(Product.ProductId))
            {
                Product.ProductId = Guid.NewGuid().ToString();
            }

            _logger.LogInformation($"Creating product with details: {JsonConvert.SerializeObject(Product)}");

            var response = await _productService.CreateProductAsync(Product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/ProductCRUD/ProductDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");
            _logger.LogError($"Failed to create product. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
