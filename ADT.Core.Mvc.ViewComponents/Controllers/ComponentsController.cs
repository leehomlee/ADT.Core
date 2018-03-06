using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.ViewComponents.Controllers
{
    public class ComponentsController : Controller
    {
        public IActionResult Index()
        {
            return Content("Use /Address or /UserInfo");
        }
        /// <summary>
        /// MVC will search for the razor page for View Component in the following sequence:
        /// Views/[controller]/Components/[component]/[view].cshtml
        /// Views/Shared/Components/[component]/[view].cshtml
        /// </summary>
        /// <returns></returns>
        public IActionResult UserInfo()
        {
            // works: this component's view is in Views/Shared
            return ViewComponent("UserInfo");
        }

        public IActionResult Address()
        {
            // doesn't works: this component's view is NOT in Views/<controller>
            return ViewComponent("Address", new { employeeId = 5 });
        }
    }
}