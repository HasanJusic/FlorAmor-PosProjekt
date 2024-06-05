using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;

namespace FlorAmor.Webapp.Pages
{
    public class BlumenEditModel : PageModel
    {
        private readonly BlumenRepository _repository;

        [BindProperty]
        public Blume Blume { get; set; }

        public BlumenEditModel(BlumenRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet(Guid blumenId)
        {
            Blume = _repository.GetById(blumenId);
            if (Blume == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Update(Blume);

            return RedirectToPage("./DetailsPage");
        }
    }
}
