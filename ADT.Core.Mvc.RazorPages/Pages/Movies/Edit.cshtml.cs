using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADT.Core.Mvc.RazorPages.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly OtherLayers.IMovieService service;
        public EditModel(OtherLayers.IMovieService _service)
        {
            service = _service;
        }

        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public IActionResult OnGet(int id)
        {
            var model = this.service.GetMovie(id);
            if (model == null)
                return RedirectToPage("./Index");
            this.Movie = new MovieInputModel
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var model = new OtherLayers.Movie
            {
                Id = Movie.Id,
                Title = Movie.Title,
                ReleaseYear = Movie.ReleaseYear,
                Summary = Movie.Summary
            };

            this.service.UpdateMovie(model);

            return RedirectToPage("./Index");
        }
    }
}