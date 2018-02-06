using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Middleware
{
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;

        public HelloWorldMiddleware(RequestDelegate _next)
        {
            this.next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Hello World!(Use in Class)\n");
            await next(context);
        }
    }
}
