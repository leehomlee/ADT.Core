using ADT.Core.Mvc.Filters.Models.Home;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace ADT.Core.Mvc.Filters.Filters
{
    public class AddDeveloperResultFilter : IResultFilter
    {
        private readonly string developer;

        public AddDeveloperResultFilter(string developer)
        {
            this.developer = developer;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(
                "Developer", new StringValues(this.developer));
        }
    }

    public class GreetDeveloperResultFilter : IResultFilter
    {
        private readonly IGreetingService greetingService;

        public GreetDeveloperResultFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(
                "Developer-Msg", new StringValues(this.greetingService.Greet("lilei")));
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {

        }
    }
}
