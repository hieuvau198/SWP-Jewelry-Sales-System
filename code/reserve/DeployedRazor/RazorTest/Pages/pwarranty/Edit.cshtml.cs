﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using RazorTest.Utilities;
using System.Threading.Tasks;

namespace RazorTest.Pages.pwarranty
{
    public class EditModel : PageModel
    {
        public const string SessionKeyUserObject = "_UserObject";
        private readonly WarrantyService _warrantyService;
        private readonly ApiService _apiService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(ApiService apiService, ILogger<EditModel> logger, WarrantyService warrantyService)
        {
            _warrantyService = warrantyService;
            _apiService = apiService;
            _logger = logger;
        }
        public User User { get; set; }

        [BindProperty]
        public Warranty Warranty { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
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
            Warranty = await _warrantyService.GetWarrantyByIdAsync(id);
            if (Warranty == null)
            {
                _logger.LogError($"Warranty not found for ID {id}");
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

            _logger.LogInformation($"Updating warranty with ID {Warranty.WarrantyId}");
            _logger.LogInformation($"Warranty details: {JsonConvert.SerializeObject(Warranty)}");
            var response = await _warrantyService.UpdateWarrantyAsync(Warranty);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update warranty. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the warranty.");
                return Page();
            }
            _logger.LogInformation("Successfully updated warranty");
            return RedirectToPage("./WarrantyDetail");
        }
    }
}
