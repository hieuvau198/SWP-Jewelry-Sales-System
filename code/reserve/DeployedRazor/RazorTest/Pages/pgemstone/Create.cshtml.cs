﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgemstone
{
    public class CreateModel : PageModel
    {
        private readonly GemService _gemService;
        private readonly ApiService _apiService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(GemService gemService, ILogger<CreateModel> logger, ApiService apiService)
        {
            _gemService = gemService;
            _logger = logger;
            _apiService = apiService;
        }

        [BindProperty]
        public Gem Gem { get; set; }

        public IActionResult OnGet()
        {
            // Verify auth
                List<string> roles = new List<string>
                    {
                        "Manager",
                        "Admin"
                    };
                if (!_apiService.VerifyAuth(HttpContext, roles))
                {
                    return RedirectToPage("/Authentication/AccessDenied");
                }

            // Initialize the Gem with a new ID
            Gem = new Gem
            {
                GemId = Guid.NewGuid().ToString()
            };

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

            // Check if GemID is still empty and generate it
            if (string.IsNullOrEmpty(Gem.GemId))
            {
                Gem.GemId = Guid.NewGuid().ToString();
            }

            var response = await _gemService.CreateGemAsync(Gem);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/pgemstone/Detail");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the gem.");
            _logger.LogError($"Failed to create gem. Status Code: {response.StatusCode}");
            return Page();
        }
    }
}