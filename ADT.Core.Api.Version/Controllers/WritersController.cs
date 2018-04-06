using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Api.Version.Controllers
{
    // Conventions specified in Startup
    // via HTTP header
    // e.g. /writers, add api-version header

    [Route("writers")]
    public class WritersControllerV1 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 1");
    }

    [Route("writers")]
    public class WritersControllerV2 : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 2");
    }
}