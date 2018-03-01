using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADT.Core.Mvc.ModelBinding.Models.Home;

namespace ADT.Core.Mvc.ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello Model Binding!");
        }

        #region Simple Type
        public IActionResult Simple(int id)
        {
            return Content($"Simple-Default:{id}");
        }
        public IActionResult SimpleQuery([FromQuery]int id)
        {
            return Content($"Simple-Query:{id}");
        }
        public IActionResult SimpleForm([FromForm]int id)
        {
            return Content($"Simple-Form:{id}");
        }
        public IActionResult SimpleBodyWithOutModel([FromBody]int id)
        {
            return Content($"Simple-Body-With-Out-Model:{id}");
        }
        public IActionResult SimpleBodyWithModel([FromBody]SimpleBodyInputModel model)
        {
            return Content($"Simple-Body-With-Model:{model.Id}");
        }
        public IActionResult SimpleHeader([FromHeader]string host, [FromHeader(Name = "User-Agent")]string userAgent)
        {
            return Content($"Simple-Header:{host},{userAgent}");
        }
        #endregion

        #region Complex Type
        public IActionResult Complex(GreetingInputModel model)
        {
            return Content($"Complex-Default:{model.Type},{model.To}");
        }
        public IActionResult ComplexQuery([FromQuery]GreetingInputModel model)
        {
            return Content($"Complex-Query:{model.Type},{model.To}");
        }
        public IActionResult ComplexForm([FromForm]GreetingInputModel model)
        {
            return Content($"Complex-Form:{model.Type},{model.To}");
        }
        public IActionResult ComplexBody([FromBody]GreetingInputModel model)
        {
            return Content($"Complex-Body:{model.Type},{model.To}");
        }
        public IActionResult ComplexHeader([FromHeader]HeaderInputModel model)
        {
            return Content($"Complex-Header:{model.Host},{model.UserAgent}");
        }
        #endregion

        #region Collections
        public IActionResult Collection(IEnumerable<string> Values)
        {
            return Content($"Collection-Default:{Values.Count()}");
        }
        public IActionResult CollectionComplex([FromBody]CollectionInputModel model)
        {
            return Content($"Collection-Complex:{model.Values.Count()}");
        }
        #endregion

        #region Multiple Sources
        /// <summary>
        /// Order: form > route > query 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Multiple(int id)
        {
            return Content($"Multiple:{id}");
        }
        #endregion
    }
}