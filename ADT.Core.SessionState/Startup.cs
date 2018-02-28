using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ADT.Core.SessionState
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options => 
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "ADT.Core.SessionState";//default : .AspNetCore.Session
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.Use(async (context, next) => 
            {
                //context.Session.SetString("GreetingMessage", "Hello Session State!");
                context.Session.SetObject("userinfo", new UserInfo { Name = "lilei", Email = "lilei@adinnet.cn" });
                await next();
            });

            app.Run(async (context) => 
            {
                //var message = context.Session.GetString("GreetingMessage");
                var message = context.Session.GetObject<UserInfo>("userinfo");
                await context.Response.WriteAsync($"{message.Name},{message.Email}");
            });
        }
    }
}
