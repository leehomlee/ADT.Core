using ADT.Core.Dependency.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Dependency.Middleware
{
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;

        public HelloWorldMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext context, IGreetingService service)
        {
            //
            //var service2 = context.RequestServices.GetService<IGreetingService>();

            var message = service.Greet("World (via DI)");
            await context.Response.WriteAsync(message);
        }
    }
}
