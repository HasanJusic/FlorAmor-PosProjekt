using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using FlorAmor.Application.Repository;

namespace FlorAmor.WebApp.Pages.Tasks;

public class UserDeleteModel : PageModel {
    private readonly ILogger<UserDeleteModel> _logger;
    private readonly UserRepository _userRepository;

    public UserDeleteModel(UserRepository userRepository, ILogger<UserDeleteModel> logger) {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<IActionResult> OnGetAsync() {
        string userIdString = HttpContext.Session.GetString("User_Id");
        string userProfileIdString = HttpContext.Session.GetString("UserProfile_Id");

        if (Guid.TryParse(userIdString, out Guid userguid))
        {
            bool isDeleted = await _userRepository.DeleteUserbyid(userguid);

            if (!isDeleted) {
                _logger.LogError("No User found with ID {UserId}", userguid);

                return NotFound($"No User found with ID {userguid}");
            }

            return RedirectToPage("Logout");
        } else {
            _logger.LogError("Invalid GUID for profile: {ProfileGUID}", userProfileIdString);
            return StatusCode(500, "Internal server error due to invalid profile GUID.");
        }
    }
}
