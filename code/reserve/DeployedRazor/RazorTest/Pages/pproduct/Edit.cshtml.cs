using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pproduct
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly ProductService _productService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, ProductService productService)
        {
            _productService = productService;
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                // Verify auth
                List<string> roles = new List<string>
                {
                    "Admin"
                };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
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

            } catch (Exception ex)
            {
                return RedirectToPage("/Error");
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
