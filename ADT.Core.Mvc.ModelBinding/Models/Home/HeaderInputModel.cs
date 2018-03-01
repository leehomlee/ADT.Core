using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.ModelBinding.Models.Home
{
    public class HeaderInputModel
    {
        [FromHeader]
        public string Host { get; set; }
        [FromHeader(Name = "User-Agent")]
        public string UserAgent { get; set; }
    }
}
