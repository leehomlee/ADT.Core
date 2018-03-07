using ADT.Core.Mvc.TagHelpers.Components.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace ADT.Core.Mvc.TagHelpers.Components.Lib
{
    //public class MetaTagHelperComponent : TagHelperComponent
    //{
    //    public override int Order => 1;

    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {
    //        if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
    //        {
    //            output.PostContent.AppendHtml($"<meta name=\"description\" content=\"This is a post on TagHelperComponent\" /> \r\n");
    //            output.PostContent.AppendHtml($"<meta name=\"keywords\" content=\"asp.net core, mvc, tag helpers\" /> \r\n");
    //        }
    //    }
    //}

    //Dependency Injection
    public class MetaTagHelperComponent : TagHelperComponent
    {
        private readonly IMetaService service;
        public MetaTagHelperComponent(IMetaService _service)
        {
            service = _service;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var item in service.GetMetadata())
                {
                    output.PostContent.AppendHtml($"<meta name=\"{item.Key}\" content=\"{item.Value}\" /> \r\n");
                }
            }
        }
    }
}
