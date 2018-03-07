using System.Collections.Generic;

namespace ADT.Core.Mvc.TagHelpers.Components.Models
{
    public interface IMetaService
    {
        Dictionary<string, string> GetMetadata();
    }
}
