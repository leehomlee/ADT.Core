using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.TagHelpers.Cache.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}