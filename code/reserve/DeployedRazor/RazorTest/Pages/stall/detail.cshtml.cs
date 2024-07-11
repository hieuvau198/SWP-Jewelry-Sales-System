using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;

namespace RazorTest.Pages.stall
{
    public class detailModel : PageModel
    {
        public const string SessionKeyAuthState = "_AuthState";
        public const string SessionKeyUserObject = "_UserObject";
        public const string SessionKeyStallObject = "_StallObject";

        public const string UrlStall = "https://hvjewel.azurewebsites.net/api/stall";
        public const string UrlStallEmployee = "https://hvjewel.azurewebsites.net/api/stallemployee";
        public const string UrlStallItem = "https://hvjewel.azurewebsites.net/api/stallitem";
        public const string UrlProduct = "https://hvjewel.azurewebsites.net/api/product";

        private readonly ApiService _apiService;

        public detailModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public User User { get; set; }
        public Stall Stall { get; set; }
        public List<Stall> Stalls { get; set; }
        public List<StallEmployee> StallEmployees { get; set; }
        public List<StallItem> StallItems { get; set; }
        public List<StallEmployee> DetailStallEmployees { get; set; }
        public List<StallItem> DetailStallItems { get; set; }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                // Verify Auth
                List<string> roles = new List<string> { "Admin", "Manager" };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/Accessdenied");
                }

                // Process data
                User = HttpContext.Session.GetObject<User>(SessionKeyUserObject);
                Stalls = await _apiService.GetAsync<List<Stall>>(UrlStall);
                StallEmployees = await _apiService.GetAsync<List<StallEmployee>>(UrlStallEmployee);
                StallItems = await _apiService.GetAsync<List<StallItem>>(UrlStallItem);
                if(Stalls.IsNullOrEmpty() || StallEmployees.IsNullOrEmpty() || StallItems.IsNullOrEmpty())
                {
                    return RedirectToPage("/Error");
                }
                Stall = HttpContext.Session.GetObject<Stall>(SessionKeyStallObject);
                if (Stalls.IsNullOrEmpty()) 
                {
                    return RedirectToPage("/NotFound");
                }
                DetailStallEmployees = StallEmployees.Where(x => x.StallId == Stall.StallId).ToList();
                if(DetailStallEmployees.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
                DetailStallItems = StallItems.Where(x => x.StallId == Stall.StallId).ToList();
                if(DetailStallItems.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostEditEmployee(string stallEmployeeId, string stallName, string role)
        {
            try
            {
                if (stallEmployeeId.IsNullOrEmpty() || stallName.IsNullOrEmpty() || role.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
                StallEmployees = await _apiService.GetAsync<List<StallEmployee>>(UrlStallEmployee);
                Stalls = await _apiService.GetAsync<List<Stall>>(UrlStall);
                if (StallEmployees.IsNullOrEmpty() || Stalls.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
                StallEmployee stallEmployee = StallEmployees.Find(x => x.StallEmployeeId == stallEmployeeId);
                Stall stall = Stalls.Find(x => x.StallName == stallName);
                if (stallEmployee == null || stall == null)
                {
                    return RedirectToPage("/NotFound");
                }
                stallEmployee.StallName = stall.StallName;
                stallEmployee.Role = role;
                stallEmployee.StallId = stall.StallId;
                var response = await _apiService.PutAsJsonAsync(UrlStallEmployee, stallEmployee);
                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Error");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEditItem(string stallItemId, int quantity, string stallName)
        {
            try
            {
                if (stallItemId.IsNullOrEmpty() || quantity == 0 || stallName.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
                Stalls = await _apiService.GetAsync<List<Stall>>(UrlStall);
                StallItems = await _apiService.GetAsync<List<StallItem>>(UrlStallItem);
                List<Product> products = await _apiService.GetAsync<List<Product>>(UrlProduct);
                if (Stalls.IsNullOrEmpty() || StallItems.IsNullOrEmpty() || products.IsNullOrEmpty())
                {
                    return RedirectToPage("/NotFound");
                }
                Stall stall = Stalls.Find(x => x.StallName == stallName);
                StallItem stallItem = StallItems.Find(x => x.StallItemId == stallItemId);
                Product product = products.Find(x => x.ProductId == stallItem.ProductId);
                if (stall == null || stallItem == null || product == null)
                {
                    return RedirectToPage("NotFound");
                }
                product.ProductQuantity = quantity;
                
                stallItem.StallId = stall.StallId;
                var response = await _apiService.PutAsJsonAsync(UrlStallItem, stallItem);
                if(!response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Error");
                }
                response = await _apiService.PutAsJsonAsync(UrlProduct, product);
                if (!response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Error");
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage();
        }
    }
}
