using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ADT.Core.Middleware.Options
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Instance Type
            //services.AddMessageFormatter(new Service.MessageOptions { format = Service.MessageFormat.Lower });
            //Function Type
            services.AddMessageFormatter(options => { options.format = Service.MessageFormat.Upper; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //Instance Type
            //app.UseGreeting(new GreetingOptions { GreetAt = "Monring", GreetTo = "John" });
            //Function Type
            app.UseGreeting(options => { options.GreetAt = "Afternoon"; options.GreetTo = "Jim"; });
        }
    }
}
