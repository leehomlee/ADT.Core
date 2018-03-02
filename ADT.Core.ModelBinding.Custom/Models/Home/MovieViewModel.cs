﻿using ADT.Core.Mvc.ModelBinding.Custom.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.Core.Mvc.ModelBinding.Custom.Models.Home
{
    public class MovieViewModel
    {
        [ProtectedId]
        public string Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
    }
}
