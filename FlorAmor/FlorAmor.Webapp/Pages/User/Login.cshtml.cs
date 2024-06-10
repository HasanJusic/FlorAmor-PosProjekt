using FlorAmor.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    private readonly UserRepository _userRepository;

    [BindProperty]
    [Required(ErrorMessage = "Email address is required."), EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Password is required."), DataType(DataType.Password)]
    public string Password { get; set; }

    public LoginModel(ILogger<LoginModel> logger, UserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public void OnGet()
    {
        var loggedIn = HttpContext.Session.GetString("Logged_in");
        var userId = HttpContext.Session.GetString("User_Id");

        if (loggedIn == "true")
        {
            _logger.LogInformation("User {UserId} is currently logged in.", userId);
        }
        else
        {
            _logger.LogInformation("No user is currently logged in.");
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (_userRepository.DoesUserExistByEmail(Email))
        {
            var user = _userRepository.GetUserByEmail(Email);
            if (_userRepository.ValidatePassword(Password, user.Password))
            {
                HttpContext.Session.SetString("Logged_in", "true");
                HttpContext.Session.SetString("US_vorname", user.Vorname);
                HttpContext.Session.SetString("User_Id", user._id.ToString());

                _logger.LogInformation("Session created: Logged_in = {LoggedIn}, User_Id = {UserId}",
                    HttpContext.Session.GetString("Logged_in"),
                    HttpContext.Session.GetString("User_Id"));

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid password.");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "No user found with that email address.");
        }

        return Page();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToPage("Login");
    }
}
