using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FlorAmor.Application.DTO;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using System;


namespace FlorAmor.Webapp.Pages
{
    public class BlumenEditModel : PageModel
    {
        private readonly BlumenRepository _repository;
        private readonly IMapper _mapper;

        public BlumenEditModel(BlumenRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [BindProperty]
        public BlumeDTO Blume { get; set; }

        public IActionResult OnGet(Guid blumenId)
        {
            var blume = _repository.GetById(blumenId);
            if (blume == null)
            {
                return NotFound();
            }
            Blume = _mapper.Map<BlumeDTO>(blume);
            return Page();
        }

        public IActionResult OnPost(Guid blumenId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var blume = _repository.GetById(blumenId);
            if (blume == null)
            {
                return NotFound();
            }

            _mapper.Map(Blume, blume);
            _repository.Update(blume);

            return RedirectToPage("./DetailsPage");
        }
    }
}
