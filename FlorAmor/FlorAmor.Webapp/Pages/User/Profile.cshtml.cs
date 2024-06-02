using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using User = FlorAmor.Application.Model; 
using FlorAmor.Application.Repository;
using System.ComponentModel.DataAnnotations;
using System;

namespace FlorAmor.Webapp.Pages.User {
    public class ProfileModel : PageModel {
        private readonly UserRepository _userRepository;
        [BindProperty] public Application.Model.User User { get; set; }

        public ProfileModel(UserRepository userRepository) {
            _userRepository = userRepository;
        }

        public void OnGet() {
            string userIdString = HttpContext.Session.GetString("User_Id");
            if (!string.IsNullOrEmpty(userIdString) && Guid.TryParse(userIdString, out Guid userId)) {
                User = _userRepository.GetUserById(userId);
            }
        }
    }
}