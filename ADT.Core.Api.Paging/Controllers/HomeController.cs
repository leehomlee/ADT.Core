using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Api.Paging.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Get", "Movies");
        }
    }
}