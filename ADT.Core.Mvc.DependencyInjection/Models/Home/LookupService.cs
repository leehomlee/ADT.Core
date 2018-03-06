using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.DependencyInjection.Models.Home
{
    public interface ILookupService
    {
        List<SelectListItem> Genres { get; }
    }

    public class LookupService : ILookupService
    {
        public List<SelectListItem> Genres
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{ Value="1",Text="one"},
                    new SelectListItem{ Value="2",Text="two"},
                    new SelectListItem{ Value="3",Text="three"}
                };
            }
        }
    }
}
