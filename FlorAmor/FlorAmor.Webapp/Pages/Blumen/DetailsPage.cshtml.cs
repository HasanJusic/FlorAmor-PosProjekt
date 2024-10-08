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
        [BindProperty]
        public List<Blume> Blumen { get; set; }

        public DetailsPageModel(BlumenRepository repository)
        {
            _repository = repository;
            Blume = new Blume();
        }

        public void OnGet()
        {
            Blumen = _repository.GetAll();
        }

        public IActionResult OnPostCreate()
        {
            if (!ModelState.IsValid)
            {
                Blumen = _repository.GetAll();
                return Page();
            }

            _repository.Add(Blume);

            return RedirectToPage();
        }
    }
}