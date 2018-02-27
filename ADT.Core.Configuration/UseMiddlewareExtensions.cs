using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Configuration
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware>();
        }
    }

    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;
        private readonly AppSettings settings;
        public HelloWorldMiddleware(RequestDelegate _next, IOptions<AppSettings> options)
        {
            next = _next;
            this.settings = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var message = JsonConvert.SerializeObject(settings);
            await context.Response.WriteAsync(message);
        }
    }
}
