using Microsoft.AspNetCore.Mvc;
using ADT.Core.Mvc.Filters.Filters;

namespace ADT.Core.Mvc.Filters.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Action Filters 
        [ParseParameterActionFilter]
        public IActionResult ParseParameter(string param)
        {
            return Content($"Hello ParseParameter, Parameter: {param}");
        }

        [SkipActionFilter]
        public IActionResult SkipAction()
        {
            return Content("Hello SkipAction");
        }
        #endregion

        #region Result Filters
        [SkipResultFilter]
        public IActionResult SkipResult()
        {
            return Content("Hello SkipResult");
        }

        [AddVersionResultFilter("Asp.Net Core MVC 2.0")]
        public IActionResult AddVersion()
        {
            return Content("Hello AddVersion. Check Response Headers for 'MVC-Version'");
        }
        #endregion

        #region Service Filters
        [ServiceFilter(typeof(GreetingServiceFilter))]
        public IActionResult GreetService(string param)
        {
            return Content($"Hello GreetService, Parameter: {param}");
        }
        #endregion

        #region Type Filters
        [TypeFilter(typeof(GreetingTypeFilter))]
        public IActionResult GreetType1(string param)
        {
            return Content($"Hello GreetType1. Parameter: {param}");
        }

        [GreetingTypeFilterWrapper]
        public IActionResult GreetType2(string param)
        {
            return Content($"Hello GreetType2. Parameter: {param}");
        }
        #endregion
    }
}