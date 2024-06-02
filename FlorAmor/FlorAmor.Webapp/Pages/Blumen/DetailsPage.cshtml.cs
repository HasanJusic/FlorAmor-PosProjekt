using System.Collections.Generic;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlorAmor.Webapp.Pages
{
    public class DetailsPageModel : PageModel
    {
        private readonly BlumenRepository _repository;

        public DetailsPageModel(BlumenRepository repository)
        {
            _repository = repository;
        }

        public List<Blume> Blumen { get; private set; }

        public void OnGet()
        {
            Blumen = _repository.GetAll().ToList();
        }
    }
}