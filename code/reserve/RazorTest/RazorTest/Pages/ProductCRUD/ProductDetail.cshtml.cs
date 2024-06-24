using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Pages.ProductCRUD
{

    public class ProductListModel : PageModel
    {

        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";

        private readonly ApiService _apiService;

        public ProductListModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Product> Products { get; set; }
        public User User { get; set; }

        public async Task OnGetAsync()
        {
            var products = await _apiService.GetAsync<List<Product>>("http://localhost:5071/api/product");

            if (products != null)
            {
                Products = products.OrderBy(p => p.ProductCode).ToList();
            }
     
        }
        public bool VerifyAuth(string role)
        {
            bool result = false;
            if (HttpContext.Session.GetObject<bool>(SessionKeyAuthState)
                && HttpContext.Session.GetObject<User>(SessionKeyUserObject).Role.Equals(role))
            {
                result = true;
            }
            return result;
        }
    }
}
