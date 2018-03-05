using ADT.Core.Mvc.ModelValidation.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace ADT.Core.Mvc.ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello Model Validation!");
        }

        [HttpPost]
        public IActionResult Save([FromBody]EmployeeInputModel model)
        {
            if (model.Id == 1)
            {
                ModelState.AddModelError("Id", "Id already exists");
            }

            if(ModelState.IsValid)
                return Ok(model);
            return BadRequest(ModelState);
        }
    }
}