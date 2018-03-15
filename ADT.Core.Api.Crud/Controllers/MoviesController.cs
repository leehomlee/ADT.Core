using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADT.Core.Api.Crud.Controllers
{
    [Produces("application/json")]
    [Route("movies")]
    public class MoviesController : Controller
    {
        private readonly OtherLayers.IMovieService service;
        public MoviesController(OtherLayers.IMovieService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = service.GetMovies();
            return Ok(ToOutputMovie(movies));
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get(int id)
        {
            var movie = service.GetMovie(id);
            if (movie == null)
                return NotFound();

            return Ok(ToOutputMovie(movie));
        }

        [HttpPost]
        public IActionResult Create([FromBody]Models.Movies.MovieInputModel model)
        {
            if (model == null)
                return BadRequest();

            var movie = ToDomainModel(model);
            service.AddMovie(movie);

            var outputModel = ToOutputMovie(movie);

            return CreatedAtRoute("GetMovie", new { id = outputModel.Id }, outputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Models.Movies.MovieInputModel model)
        {
            if (model == null || model.Id != id)
                return BadRequest();

            if (!service.MovieExists(id))
                return NotFound();

            var movie = ToDomainModel(model);
            service.UpdateMovie(movie);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.MovieExists(id))
                return NotFound();

            service.DeleteMovie(id);

            return NoContent();
        }

        #region Mappings
        private Models.Movies.MovieOutputModel ToOutputMovie(OtherLayers.Movie movie)
        {
            return new Models.Movies.MovieOutputModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Summary = movie.Summary,
                LastReadAt = DateTime.Now
            };
        }
        private List<Models.Movies.MovieOutputModel> ToOutputMovie(List<OtherLayers.Movie> movies)
        {
            return movies.Select(item => ToOutputMovie(item)).ToList();
        }
        private OtherLayers.Movie ToDomainModel(Models.Movies.MovieInputModel model)
        {
            return new OtherLayers.Movie
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary
            };
        }
        private Models.Movies.MovieInputModel ToInputModel(OtherLayers.Movie model)
        {
            return new Models.Movies.MovieInputModel
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary
            };
        }
        #endregion
    }
}