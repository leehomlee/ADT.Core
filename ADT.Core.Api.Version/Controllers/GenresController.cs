using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Api.Version.Controllers
{
    // Deprecated
    // via HTTP header
    // e.g. /genres, add api-version header

    [ApiVersion("1.0", Deprecated = true)]
    [Route("genres")]
    public class GenresControllerV1 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 1");
    }

    [ApiVersion("2.0")]
    [Route("genres")]
    public class GenresControllerV2 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 2");
    }
}