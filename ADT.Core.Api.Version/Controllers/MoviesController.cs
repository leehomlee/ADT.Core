using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Api.Version.Controllers
{
    // via query string 
    // e.g. /movies?api-version=2.0

    [ApiVersion("1.0")]
    [Route("movies")]
    public class MoviesControllerV1 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 1");
    }

    [ApiVersion("2.0")]
    [Route("movies")]
    public class MoviesControllerV2 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 2");
    }
}