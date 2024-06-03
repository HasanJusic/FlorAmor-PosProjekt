using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;

namespace FlorAmor.Webapp.Pages
{
    public class BlumenEditModel : PageModel
    {
        private readonly BlumenRepository _repository;

        public BlumenEditModel(BlumenRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Blume Blume { get; set; }

        public IActionResult OnGet(Guid blumenId)
        {
            Blume = _repository.GetById(blumenId);
            if (Blume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(Guid blumenId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingBlume = _repository.GetById(blumenId);
            if (existingBlume == null)
            {
                return NotFound();
            }

            existingBlume.Art = Blume.Art;
            existingBlume.Preis = Blume.Preis;
            _repository.Update(existingBlume);

            return RedirectToPage("./DetailsPage");
        }
    }
}
