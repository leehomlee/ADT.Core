using ADT.Core.Mvc.ViewComponents.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.ViewComponents.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new EmployeeViewModel
            {
                Id = 1,
                Firstname = "Lei",
                Surname = "Li"
            };
            return View(model);
        }
    }
}