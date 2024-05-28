using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlorAmor.Application.Repository;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FlorAmor.Webapp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> logger;
        private readonly UserRepository userRepository;

        [BindProperty]
        [Required, EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(ILogger<LoginModel> logger, UserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
            var loggedIn = HttpContext.Session.GetString("Logged_in");
            var userId = HttpContext.Session.GetString("User_Id");

            if (loggedIn == "true")
            {
                logger.LogInformation("User {UserId} is currently logged in.", userId);
                RedirectToPage("/Index");
            }
            else
            {
                logger.LogInformation("No user is currently logged in.");
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userRepository.DoesUserExistByEmail(Email))
            {
                var user = userRepository.GetUserByEmail(Email);
                if (userRepository.ValidatePassword(Password, user.Password))
                {
                    HttpContext.Session.SetString("Logged_in", "true");
                    HttpContext.Session.SetString("User_Id", user.Id.ToString());

                    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Email),
            new Claim("UserId", user.Id.ToString())
        };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    logger.LogInformation("Session created: Logged_in = {LoggedIn}, User_Id = {UserId}",
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
                ModelState.AddModelError(string.Empty, "No user found with this email address.");
            }

            return Page();
        }
    }
    }
