using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Logging.Serilog
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware2>();
        }
    }

    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HelloWorldMiddleware> logger;
        public HelloWorldMiddleware(RequestDelegate _next, ILogger<HelloWorldMiddleware> _logger)
        {
            next = _next;
            logger = _logger;
        }

        public async Task Invoke(HttpContext context)
        {
            this.logger.LogInformation(101, "Invoke executing...");
            await context.Response.WriteAsync("Hello Logging!");
            this.logger.LogInformation(201, "Invoke executed...");
        }
    }

    //ILoggerFactory
    public class HelloWorldMiddleware2
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        public HelloWorldMiddleware2(RequestDelegate _next, ILoggerFactory factory)
        {
            next = _next;
            logger = factory.CreateLogger("HelloWorldMiddleware2");
        }

        public async Task Invoke(HttpContext context)
        {
            var message = new
            {
                GreetingTo = "James Bond",
                GreetingTime = "Morning",
                GreetingType = "Good"
            };
            this.logger.LogInformation("Inoke executing {@message}", message);


            //this.logger.LogInformation(101, "Invoke2 executing...");
            await context.Response.WriteAsync("Hello Logging2!");
            //this.logger.LogInformation(201, "Invoke2 executed...");

            this.logger.LogInformation(
                "Inoke executed by {developer} at {time}", "lilei", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
