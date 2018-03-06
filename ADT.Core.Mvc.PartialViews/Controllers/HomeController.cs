using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.PartialViews.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Models.Home.EmployeeViewModel
            {
                Id = 1,
                Firstname = "Lei",
                Surname = "Li",
                Address = new Models.Home.AddressViewModel
                {
                    Line1 = "Shanghai",
                    Line2 = "PuDong",
                    Line3 = "BiBoRoad"
                }
            };
            return View(model);
        }
    }
}