using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.TagHelpers.Custom.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            var model = new Models.Home.EmployeesViewModel
            {
                Employees = new List<Models.Home.Employee>
                {
                    new Models.Home.Employee
                    {
                        Name = "Employee1",
                        JobTitle = "developer",
                        Profile = "C#",
                        Friends = new List<Models.Home.Friend>
                        {
                            new Models.Home.Friend{ Name = "friend11" },
                            new Models.Home.Friend{ Name = "friend12" }
                        }
                    },
                    new Models.Home.Employee
                    {
                        Name = "Employee2",
                        JobTitle = "actor",
                        Profile = "music",
                        Friends = new List<Models.Home.Friend>
                        {
                            new Models.Home.Friend{ Name = "friend21" },
                            new Models.Home.Friend{ Name = "friend22" }
                        }
                    }
                }
            };
            return View(model);
        }

        public IActionResult Movie()
        {
            var model = new Models.Home.MovieViewModel
            {
                Title = "Diamonds Are Forever",
                ReleaseYear = "1971",
                Director = "Guy Hamilton",
                Summary = "A diamond smuggling investigation leads James Bond to Las Vegas, where he uncovers an evil plot involving a rich business tycoon.",
                Stars = new List<string> { "Sean Connery", "Jill St. John", "Charles Gray" }
            };
            return View(model);
        }

        public IActionResult Context()
        {
            ViewBag.Greeting = "Hello Context Tag Helper";
            return View();
        }

        public IActionResult Greet()
        {
            return View();
        }
    }
}