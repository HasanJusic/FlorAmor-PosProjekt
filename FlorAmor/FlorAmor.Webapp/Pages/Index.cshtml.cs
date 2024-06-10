using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlorAmor.Application.Repository;
using FlorAmor.Application.Model;
using Microsoft.AspNetCore.Authorization;

namespace FlorAmor.Webapp.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly LadenRepository _repository;

        public IndexModel(LadenRepository repository)
        {
            _repository = repository;
        }

        public List<Laden> Laeden { get; private set; }

        public void OnGet()
        {
            Laeden = _repository.GetAll().ToList();
        }
    }
}