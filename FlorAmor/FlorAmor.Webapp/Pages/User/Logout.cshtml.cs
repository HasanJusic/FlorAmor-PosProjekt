﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

    public class LogoutModel : PageModel {
        public IActionResult OnGet() {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }