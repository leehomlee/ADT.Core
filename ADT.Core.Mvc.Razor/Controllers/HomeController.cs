using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.Razor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            var model = new Models.Home.AboutViewModel
            {
                Firstname = "lei",
                Surname = "li"
            };
            return View("Bio", model);
        }
    }
}