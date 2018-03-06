using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.Layout.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Models.Home.UserViewModel
            {
                Firstname = "Lei",
                Surname = "Li"
            };
            return View(model);
        }
    }
}