using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.Filters.Filters
{
    public class ParseParameterActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            object param;
            if (context.ActionArguments.TryGetValue("param", out param))
                context.ActionArguments["param"] = param.ToString().ToUpper();
            else
                context.ActionArguments.Add("param", "I come from action filter");
        }
    }

    public class SkipActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new ContentResult
            {
                Content = "I'll skip the action execution"
            };
        }
    }

    public class HelloActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // runs before action method
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // runs after action method
        }
    }

    public class HelloAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // runs before action method
            await next();
            // runs after action method
        }
    }
}
