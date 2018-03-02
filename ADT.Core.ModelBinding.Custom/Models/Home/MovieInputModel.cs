using ADT.Core.ModelBinding.Custom.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.ModelBinding.Custom.Models.Home
{
    public class MovieInputModel
    {
        [ProtectedId]
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
