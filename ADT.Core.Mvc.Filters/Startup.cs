using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

/*
 * https://tahirnaushad.com/2017/08/28/asp-net-core-2-0-mvc-filters/
 * The Executing methods are called first for Global > Controller > Action filters.
 * Then Executed methods are called for Action > Controller > Global filters.
 * 
 * ActionFilterAttribute
 * ResultFilterAttribute
 * ExceptionFilterAttribute
 * ServiceFilterAttribute
 * TypeFilterAttribute
 */


namespace ADT.Core.Mvc.Filters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Models.Home.IGreetingService, Models.Home.GreetingService>();
            services.AddScoped<Filters.GreetingServiceFilter>();
            services.AddMvc(options =>
            {
                options.Filters.Add(new Filters.AddDeveloperResultFilter("lilei"));
                options.Filters.Add(typeof(Filters.GreetDeveloperResultFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
        }
    }
}
