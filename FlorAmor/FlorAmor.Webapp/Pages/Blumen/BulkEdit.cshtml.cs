using System.Collections.Generic;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlorAmor.Webapp.Pages
{
    public class BulkEditPageModel : PageModel
    {
        private readonly BlumenRepository _repository;

        [BindProperty]
        public List<Blume> Blumen { get; set; }

        public BulkEditPageModel(BlumenRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Blumen = _repository.GetAll();
        }

        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var blume in Blumen)
            {
                _repository.Update(blume);
            }

            return RedirectToPage("/DetailsPage");
        }
    }
}