using System.Collections.Generic;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlorAmor.Webapp.Pages
{
    public class DetailsPageModel : PageModel
    {
        private readonly BlumenRepository _repository;

        [BindProperty]
        public Blume Blume { get; set; }
        public List<Blume> Blumen { get; private set; }

        public DetailsPageModel(BlumenRepository repository)
        {
            _repository = repository;
            Blume = new Blume(); // Initialisierung der Blume-Eigenschaft
        }

        public void OnGet()
        {
            Blumen = _repository.GetAll();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Blumen = _repository.GetAll(); // ensure Blumen list is populated if validation fails
                return Page();
            }

            _repository.Add(Blume);

            return RedirectToPage();
        }
    }
}