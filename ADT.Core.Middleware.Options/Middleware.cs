using ADT.Core.Middleware.Options.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Middleware.Options
{
    public static class Middleware
    {
        /// <summary>
        /// Instance Type
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGreeting(this IApplicationBuilder app, GreetingOptions options)
        {
            return app.UseMiddleware<GreetingMiddleware>(options);
        }

        /// <summary>
        /// Function Type
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configOptins"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGreeting(this IApplicationBuilder app, Action<GreetingOptions> configOptins)
        {
            var options = new GreetingOptions();
            configOptins(options);
            return app.UseMiddleware<GreetingMiddleware>(options);
        }

        /// <summary>
        /// Instance Type
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageFormatter(this IServiceCollection services, MessageOptions options)
        {
            return services.AddScoped<IMessageService>(factory => 
            {
                return new MessageService(options);
            });
        }
        /// <summary>
        /// Function Type
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageFormatter(this IServiceCollection services, Action<MessageOptions> configOptions)
        {
            var options = new MessageOptions();
            configOptions(options);

            return services.AddScoped<IMessageService>(factory => { return new MessageService(options); });
        }
    }
}
