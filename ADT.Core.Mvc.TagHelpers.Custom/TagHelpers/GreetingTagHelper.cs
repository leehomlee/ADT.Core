using ADT.Core.Mvc.TagHelpers.Custom.Models.Home;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ADT.Core.Mvc.TagHelpers.Custom.TagHelpers
{
    [HtmlTargetElement("greeting")]
    public class GreetingTagHelper : TagHelper
    {
        private readonly IGreetingService service;
        public GreetingTagHelper(IGreetingService _service)
        {
            service = _service;
        }

        [HtmlAttributeName("name")]
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Content.SetContent(this.service.Greet(this.Name));
        }
    }
}
