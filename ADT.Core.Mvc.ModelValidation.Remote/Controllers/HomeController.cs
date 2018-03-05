using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ADT.Core.Mvc.ModelValidation.Remote.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.Home.EmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var json = JsonConvert.SerializeObject(model);
            return Content(json);
        }

        public IActionResult ValidateEmployeeNo(string EmployeeNo)
        {
            if (EmployeeNo == "007")
            {
                return Json(data: "007 is already assigned to James Bond!");
            }
            return Json(data: true);
        }
    }
}