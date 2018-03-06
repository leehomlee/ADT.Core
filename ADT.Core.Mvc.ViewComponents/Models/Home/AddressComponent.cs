using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
/// <summary>
/// the ways to create view component
/// 1、Create a class(anywhere in your project) and inherit from ViewComponent abstract class
/// 2、Create a method called InvokeAsync() that returns Task<IViewComponentResult>
/// 3、Create model
/// 4、Call IViewComponentResult by calling the View() method of base ViewComponent
/// 
/// @await Component.InvokeAsync(component, parameters)
/// </summary>
namespace ADT.Core.Mvc.ViewComponents.Models.Home
{
    [ViewComponent(Name = "Address")]
    public class AddressComponent : ViewComponent
    {
        private readonly IAddressFormatter formatter;

        public AddressComponent(IAddressFormatter _formatter)
        {
            this.formatter = _formatter;
        }
        /// <summary>
        /// InvokeAsync() method can take any number of parameters and is passed using anonymous object when invoking the View Component
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(int employeeId)
        {
            var model = new AddressViewModel
            {
                EmployeeId = employeeId,
                Line1 = "Shanghai",
                Line2 = "PuDong",
                Line3 = "BiBo Road"
            };
            model.FormattedValue = formatter.Format(model.Line1, model.Line2, model.Line3);
            return View(model);
        }
    }
}
