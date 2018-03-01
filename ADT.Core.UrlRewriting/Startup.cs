using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
/// <summary>
/// https://docs.microsoft.com/en-gb/aspnet/core/fundamentals/url-rewriting
/// </summary>
namespace ADT.Core.UrlRewriting
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //var rewrite = new RewriteOptions()
            //    .AddRedirect("files", "movies")
            //    .AddRewrite("actors", "stars", true);

            var rewrite = new RewriteOptions().Add(
                    new MoviesRedirectRule(new string[] { "/films", "/features", "/albums" },"/movies")
                );

            app.UseRewriter(rewrite);

            app.Run(async (context) =>
            {
                var path = context.Request.Path;
                var query = context.Request.QueryString;
                await context.Response.WriteAsync($"New Url: {path}{query}");
            });
        }
    }
}
