using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RazorTest.Services;
using RazorTest.Models;

public class LoginModel : PageModel
{
    private readonly ApiService _apiService;

    public LoginModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    [BindProperty]
    public Login Input { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Call the login API endpoint using the apiService
        var response = await _apiService.Login(Input);

        if (response.IsSuccessStatusCode)
        {
            // Login successful, redirect to the home page
            return RedirectToPage("/Index");
        }
        else
        {
            // Login failed, add model error
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}


public class LoginInputModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
