using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Middleware
{
    public static class Middleware
    {
        public static void RunHelloWorld(this IApplicationBuilder app)
        {
            app.Run(async (context) => 
            {
                await context.Response.WriteAsync("Hello World! (Run)");
            });
        }

        public static void UseHelloWorld(this IApplicationBuilder app)
        {
            app.Use(async (context, next) => 
            {
                await context.Response.WriteAsync("Hello World! (Use)\n");
                await next();
            });
        }

        public static IApplicationBuilder UseHelloWorldInClass(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware>();
        }
    }
}
