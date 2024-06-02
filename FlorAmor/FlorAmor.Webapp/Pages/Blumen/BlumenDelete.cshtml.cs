using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using FlorAmor.Application.Repository;

namespace TaskManager.WebApp.Pages;

public class BlumenDeleteModel : PageModel {
    private readonly ILogger<BlumenDeleteModel> _logger;
    private readonly BlumenRepository _blumenRepository;

    public BlumenDeleteModel(BlumenRepository blumenRepository, ILogger<BlumenDeleteModel> logger) {
        _blumenRepository = blumenRepository;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync(string blumenId) {
        
        if (string.IsNullOrEmpty(blumenId)) {
            _logger.LogError("Blumen ID is null or empty");
            return NotFound("Blumen ID is not specified");
        }

        try {
            var blumenGuid = Guid.Parse(blumenId);
            bool isDeleted = await _blumenRepository.DeleteBlumenById(blumenGuid);

            if (!isDeleted) {
                _logger.LogError("No Blumen found with ID {SubjectId}", blumenId);
                return NotFound($"No Blumen found with ID {blumenId}");
            }

            TempData["SuccessMessage"] = "Blumen deleted successfully.";
        
            return RedirectToPage("DetailsPage");
        
        } catch (Exception ex) {
            _logger.LogError(ex, "Error deleting Blumen with ID {SubjectId}", blumenId);
            return StatusCode(500, "Internal server error");
        }

        // It's good practice to have a default return, even though logically unreachable
        return StatusCode(500, "Unexpected error");
    }

}