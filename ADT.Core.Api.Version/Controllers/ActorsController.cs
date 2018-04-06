using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Api.Version.Controllers
{
    // via URL
    // e.g. actors/v2.0

    [ApiVersion("1.0")]
    [Route("actors/v{ver:apiVersion}")]
    public class ActorsControllerV1 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 1");
    }

    [ApiVersion("2.0")]
    [Route("actors/v{ver:apiVersion}")]
    public class ActorsControllerV2 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 2");
    }
}