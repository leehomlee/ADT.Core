using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ADT.Core.Mvc.TagHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Models.Home.EmployeeViewModel
            {
                Id = 5
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.Home.EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var json = JsonConvert.SerializeObject(model);
            return Content(json);
        }

        public IActionResult Echo(int id)
        {
            return Content(id.ToString());
        }

        public IActionResult NamedRoute(int id)
        {
            return Content(id.ToString());
        }
    }
}