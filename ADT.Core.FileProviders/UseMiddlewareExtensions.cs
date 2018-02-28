using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Core.FileProviders
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseFileProvider(this IApplicationBuilder app)
        {
            return app.UseMiddleware<FileProviderMiddleware>();
        }
    }

    //public class FileProviderMiddleware
    //{
    //    private readonly RequestDelegate next;
    //    private readonly IFileProvider fileProvider;

    //    public FileProviderMiddleware(RequestDelegate _next, IFileProvider _fileProvider)
    //    {
    //        next = _next;
    //        fileProvider = _fileProvider;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        var output = new StringBuilder("");
    //        IDirectoryContents dir = this.fileProvider.GetDirectoryContents("");
    //        foreach (IFileInfo file in dir)
    //        {
    //            output.AppendLine(file.Name);
    //        }

    //        await context.Response.WriteAsync(output.ToString());
    //    }
    //}

    //读取单个文件的内容
    public class FileProviderMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IFileProvider fileProvider;

        public FileProviderMiddleware(RequestDelegate _next, IFileProvider _fileProvider)
        {
            next = _next;
            fileProvider = _fileProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            IFileInfo fileinfo = this.fileProvider.GetFileInfo("Startup.cs");
            using (var stream = fileinfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var output = await reader.ReadToEndAsync();
                    await context.Response.WriteAsync(output.ToString());
                }
            }
        }
    }
}
