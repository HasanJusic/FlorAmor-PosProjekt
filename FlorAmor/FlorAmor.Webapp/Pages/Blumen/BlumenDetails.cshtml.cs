using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace FlorAmor.Webapp.Pages
{
    public class BlumenDetailsModel : PageModel
    {
        private readonly BlumenRepository _repository;

        public Blume Blume { get; set; }

        public BlumenDetailsModel(BlumenRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet(string blumenId)
        {
            if (blumenId == null || !Guid.TryParse(blumenId, out Guid id))
            {
                return NotFound();
            }

            Blume = _repository.GetById(id);

            if (Blume == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
