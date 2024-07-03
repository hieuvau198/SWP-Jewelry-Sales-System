using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pproduct
{
    public class CreateModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly ILogger<CreateModel> _logger;
        private readonly ApiService _apiService;

        public CreateModel(ProductService productService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _productService = productService;
            _logger = logger;
            _apiService = apiService;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public IFormFile ProductImageUpload { get; set; }
        [BindProperty]
        public List<Gem> Gems { get; set; }
        [BindProperty]
        public List<Gold> Golds { get; set; }

        public async Task OnGet()
        {
            // Initialize the Gold with a new ID
            Product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                UnitPrice = 0,
                BuyPrice = 0,
                TotalPrice = 0
            };
            Gems = await _apiService.GetAsync<List<Gem>>("http://localhost:5071/api/gem") ?? new List<Gem>();
            Golds = await _apiService.GetAsync<List<Gold>>("http://localhost:5071/api/gold") ?? new List<Gold>();
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

            if (ProductImageUpload != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ProductImageUpload.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    Product.ProductImages = Convert.ToBase64String(fileBytes);
                }
            }
            else
            {
                Product.ProductImages = "No Image";
            }

            var response = await _productService.CreateProductAsync(Product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pproduct/ProductDetail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");
            _logger.LogError($"Failed to create product. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}
