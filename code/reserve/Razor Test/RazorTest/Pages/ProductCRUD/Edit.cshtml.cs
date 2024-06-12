using JewelBO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.ProductCRUD
{
    public class EditModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ProductService apiService, ILogger<EditModel> logger, ProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Product = await _productService.GetProductByIdAsync(id);

            if (Product == null)
            {
                _logger.LogError($"Discount not found for ID {id}");
                return NotFound();
            }
            return Page();
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

            
            _logger.LogInformation($"Updating product with ID {Product.ProductId}");
            _logger.LogInformation($"Product details: {JsonConvert.SerializeObject(Product)}");

            var response = await _productService.UpdateProductAsync(Product);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update Product. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the Product.");
                return Page();
            }

            _logger.LogInformation("Successfully updated Product");
            return RedirectToPage("./ProductDetail", new { id = Product.ProductId });
        }
    }
}
