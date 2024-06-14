using RazorTest.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using RazorTest.Utilities;



namespace RazorTest.Pages.Sale
{
    public class SaleHomePageModel : PageModel
    {

        public const string SessionKeyMessage = "_Message";
        public const string SessionKeyCart = "_Cart";
        public const string SessionKeyProductId = "_ProductId";


        private readonly ApiService _apiService;
        private readonly ILogger<IndexModel> _logger;

        public SaleHomePageModel(ApiService apiService, ILogger<IndexModel> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Product> Cart { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }
        public List<Discount> Discounts { get; set; }
        public Invoice Invoice { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public string Message { get; set; } = "No Nut November";



        //Call Data for List Products
        public async Task OnGetAsync()
        {
            Products = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyMessage)))
            {
                HttpContext.Session.SetString(SessionKeyMessage, "No Message");
            }
            var message = HttpContext.Session.GetString(SessionKeyMessage);
            _logger.LogInformation("Session Message: {Name}", message);
            if (HttpContext.Session.GetObject<List<Product>>(SessionKeyCart) == null)
            {
                Cart = new List<Product>();
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
            }
            else
            { Cart = (HttpContext.Session.GetObject<List<Product>>(SessionKeyCart)); }

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyProductId)))
            {
                HttpContext.Session.SetString(SessionKeyMessage, "No Id");
            }
            var id = HttpContext.Session.GetString(SessionKeyProductId);
            Product product = Products.Find(x => x.ProductId == id);

            if (product != null && Cart.Find(x => x.ProductId == product.ProductId) == null)
            {
                Cart.Add(product);
                HttpContext.Session.SetObject(SessionKeyCart, Cart);
                HttpContext.Session.SetString(SessionKeyMessage, "Add Success");
            }

        }
        //Test button

        public IActionResult OnPostA2(IFormCollection form)
        {
            string id = form["data"];

            Product product = Products.Find(x => x.ProductId == id);

            HttpContext.Session.SetString(SessionKeyMessage, "Still Fail");

            HttpContext.Session.SetString(SessionKeyProductId, id);

            return RedirectToPage();
        }
    }
}
