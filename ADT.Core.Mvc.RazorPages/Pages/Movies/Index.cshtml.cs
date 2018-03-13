using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADT.Core.Mvc.RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly OtherLayers.IMovieService service;
        public IndexModel(OtherLayers.IMovieService _service)
        {
            service = _service;
        }

        public List<MovieOutputModel> Movies { get; set; }

        public void OnGet()
        {
            this.Movies = service.GetMovies()
                .Select(item => new MovieOutputModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    ReleaseYear = item.ReleaseYear,
                    Summary = item.Summary,
                    LastReadAt = DateTime.Now
                })
                .ToList();
        }

        public IActionResult OnGetDeleteMovie(int id)
        {
            if (!service.ExistsMovie(id))
                return RedirectToPage("./Index");

            service.DeleteMovie(id);

            return RedirectToPage("./Index");
        }
    }
}