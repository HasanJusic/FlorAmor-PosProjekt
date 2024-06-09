using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using System.ComponentModel.DataAnnotations;

namespace FlorAmor.Webapp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> logger;
        private readonly UserRepository userRepository;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        public RegisterModel(ILogger<RegisterModel> logger, UserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                logger.LogError("Registration form is not valid.");
                return Page();
            }

            if (userRepository.DoesUserExistByEmail(Email))
            {
                logger.LogError($"User with email {Email} already exists.");
                ModelState.AddModelError("Email", "An account with this email already exists.");
                return Page();
            }

            var newUser = new Application.Model.User(Email, Password, FirstName, LastName);
            userRepository.CreateUser(newUser);
            logger.LogInformation($"New user registered: {Email}");

            return RedirectToPage("Login");
        }
    }
}
