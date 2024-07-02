using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RazorTest.Models;
using RazorTest.Services;
using System.Threading.Tasks;

namespace RazorTest.Pages.pgold
{
    public class EditModel : PageModel
    {
        private readonly GoldService _goldService;
        private readonly ILogger<EditModel> _logger;
        public EditModel(GemService apiService, ILogger<EditModel> logger, GoldService goldService)
        {
            _goldService = goldService;
            _logger = logger;
        }

        [BindProperty]
        public Gold Gold { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                _logger.LogError("ID is null");
                return NotFound();
            }

            Gold = await _goldService.GetGoldByIdAsync(id);

            if (Gold == null)
            {
                _logger.LogError($"Gold not found for ID {id}");
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

            _logger.LogInformation($"Updating gold with ID {Gold.GoldId}");
            _logger.LogInformation($"Gold details: {JsonConvert.SerializeObject(Gold)}");

            var response = await _goldService.UpdateGoldAsync(Gold);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Failed to update gold. Status Code: {response.StatusCode}");
                ModelState.AddModelError(string.Empty, "An error occurred while updating the gold.");
                return Page();
            }

            _logger.LogInformation("Successfully updated gold");
            return RedirectToPage("./GoldDetail");
        }
    }
}
