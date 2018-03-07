using System.Collections.Generic;

namespace ADT.Core.Mvc.TagHelpers.Components.Models
{
    public class MetaService : IMetaService
    {
        public Dictionary<string, string> GetMetadata()
        {
            return new Dictionary<string, string>
            {
                { "description","This is a post on TagHelperComponent" },
                { "keywords","asp.net core, tag helpers" }
            };
        }
    }
}
