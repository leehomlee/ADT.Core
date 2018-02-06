using ADT.Core.Middleware.Options.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Middleware.Options
{
    public class GreetingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly GreetingOptions options;

        public GreetingMiddleware(RequestDelegate _next, GreetingOptions _options)
        {
            this.next = _next;
            this.options = _options;
        }

        public async Task Invoke(HttpContext context, IMessageService service)
        {
            var message = $"Good {this.options.GreetAt} {this.options.GreetTo}";
            await context.Response.WriteAsync(service.FormatMessage(message));
        }
    }
}
