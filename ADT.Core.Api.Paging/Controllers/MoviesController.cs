using ADT.Core.Api.Paging.Lib;
using ADT.Core.Api.Paging.Models.Movies;
using ADT.Core.Api.Paging.OtherLayers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADT.Core.Api.Paging.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IUrlHelper urlHelper;

        public MoviesController(IMovieService _movieService, IUrlHelper _urlHelper)
        {
            movieService = _movieService;
            urlHelper = _urlHelper;
        }

        [HttpGet(Name = "GetMovies")]
        public IActionResult Get(PagingParams pagingParams)
        {
            var model = movieService.GetMovies(pagingParams);

            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

            var outputModel = new MovieOutputModel
            {
                Paging = model.GetHeader(),
                Links = GetLinks(model),
                Items = model.List.Select(m => ToMovieInfo(m)).ToList()
            };
            return Ok(outputModel);
        }

        #region Links
        private List<LinkInfo> GetLinks(PagedList<Movie> list)
        {
            var links = new List<LinkInfo>();

            if (list.HasPreviousPage)
                links.Add(CreatedLink("GetMovies", list.PreviousPageNumber, list.PageSize, "previousPage", "Get"));

            links.Add(CreatedLink("GetMovies", list.PageNumber, list.PageSize, "self", "Get"));

            if (list.HasNextPage)
                links.Add(CreatedLink("GetMovies", list.NextPageNumber, list.PageSize, "nextPage", "Get"));

            return links;
        }

        private LinkInfo CreatedLink(string routeName, int pagingNumber, int pagingSize, string rel, string method)
        {
            string url = urlHelper.Link(routeName, new { PageNumber = pagingNumber, PageSize = pagingSize });
            return new LinkInfo
            {
                Href = url,
                Rel = rel,
                Method = method
            };
        }
        #endregion

        #region Mappings
        private MovieInfo ToMovieInfo(Movie model)
        {
            return new MovieInfo
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseYear = model.ReleaseYear,
                Summary = model.Summary,
                LastReadAt = DateTime.Now
            };
        }
        #endregion
}
}