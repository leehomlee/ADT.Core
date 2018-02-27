using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics;

namespace ADT.Core.ErrorHandling
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
            else
            {
                app.UseExceptionHandler(appBuilder => 
                {
                    appBuilder.Run(async context => 
                    {
                        var feature = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = feature.Error;
                        await context.Response.WriteAsync($"<b>Oops!</b> {exception.Message}");
                    });
                });
            }

            app.Run(async (context) =>
            {
                throw new ArgumentException("T must be set");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
