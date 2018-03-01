using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Linq;

namespace ADT.Core.UrlRewriting
{
    public class MoviesRedirectRule : IRule
    {
        private readonly string[] matchPaths;
        private readonly PathString newPath;
        private string HeaderName;

        public MoviesRedirectRule(string[] _matchPaths, string _newPath)
        {
            matchPaths = _matchPaths;
            newPath = _newPath;
        }

        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Path.StartsWithSegments(newPath))
            {
                return;
            }

            if (matchPaths.Contains(request.Path.Value))
            {
                var newLocation = $"{newPath}{request.QueryString}";
                var response = request.HttpContext.Response;
                response.StatusCode = StatusCodes.Status302Found;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = newLocation;
            }
        }
    }
}
