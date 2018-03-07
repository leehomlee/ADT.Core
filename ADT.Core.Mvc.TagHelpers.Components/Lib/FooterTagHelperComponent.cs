using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace ADT.Core.Mvc.TagHelpers.Components.Lib
{
    public class FooterTagHelperComponent : TagHelperComponent
    {
        public override int Order => 1;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "footer", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(string.Format($"<p><em>{DateTime.Now.ToString()}</em></p>"));
            }
        }
    }
}
