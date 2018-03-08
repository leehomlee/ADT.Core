using ADT.Core.Mvc.Filters.Models.Home;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ADT.Core.Mvc.Filters.Filters
{
    public class GreetingServiceFilter : IActionFilter
    {
        private readonly IGreetingService service;
        public GreetingServiceFilter(IGreetingService _service)
        {
            service = _service;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            object param;
            if (context.ActionArguments.TryGetValue("param", out param))
                context.ActionArguments["param"] = param.ToString().ToUpper();
            else
                context.ActionArguments.Add("param", service.Greet("lilei"));
        }
    }
}
