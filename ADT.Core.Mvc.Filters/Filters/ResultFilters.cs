using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.Filters.Filters
{
    public class SkipResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.Cancel = true;
            context.HttpContext.Response.WriteAsync("I'll skip the result execution");
        }
    }

    public class AddVersionResultFilter : Attribute, IResultFilter
    {
        private readonly string version;
        public AddVersionResultFilter(string _version)
        {
            version = _version;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("MVC-Version", new StringValues(version));
        }
    }

    public class HelloResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // runs before result execution
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // runs after result execution
        }
    }

    public class HelloAsyncResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            // runs before result execution
            await next();
            // runs after result execution
        }
    }
}
